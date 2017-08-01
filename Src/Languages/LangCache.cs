/* *********************************************************************************
 * TNValidate Fluent Validation Library
 * https://github.com/edumentab/TNValidate
 * Copyright (C) Edument AB 2010
 * http://www.edument.se
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 * *********************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Xml.Linq;

namespace TNValidate
{
    /// ********************************************************************
    /// <summary>
    /// We do not use the built-in resource XML file for internationalization
    /// because they create a lot of small separate satellite assemblies. Instead
    /// we use a home-grown system instead.
    /// 
    /// Our Languge string lookup/caching class. The cache is loaded on the first
    /// reqeuest per language.
    /// </summary>
    internal class LangCache
    {
        /// <summary>
        /// A cache that contains all the words in the system
        /// </summary>
        private static Dictionary<string, string> WordCache = new Dictionary<string, string>();

        /// <summary>
        /// A cache that keeps track of what languages that we have loaded into our static cache.
        /// </summary>
        private static Dictionary<ValidationLanguageEnum, bool> LoadedLanguagesCache = new Dictionary<ValidationLanguageEnum, bool>();

        /// <summary>
        /// Our lock that we use to make this class thread safe
        /// </summary>
        private static ReaderWriterLock RWLock = new ReaderWriterLock();

        /// ******************************************************************
        /// <summary>
        /// Fetch an item from the language defintion XML files.
        /// 
        /// Also caches the result
        /// </summary>
        /// <param name="ValidationLanguage">The desired language to retrieve from</param>
        /// <param name="StringKey">The string identifier</param>
        /// <returns>Returns "" if not found</returns>
        public static string FetchItem(ValidationLanguageEnum ValidationLanguage, string StringKey)
        {
            string CacheKey = ValidationLanguage.ToString() + ":" + StringKey;
            string CacheEntry;

            // First, see if the item already exists in the cache
            RWLock.AcquireReaderLock(Timeout.Infinite);
            try
            {
                if (LoadedLanguagesCache.Keys.Contains(ValidationLanguage))
                {
                    // The requested language has been loaded, lets get it from the words cache
                    WordCache.TryGetValue(CacheKey, out CacheEntry);
                    return CacheEntry;
                }
            }
            finally
            {
                RWLock.ReleaseReaderLock();
            }

            // Not found in the cache; parse the XML document and insert the records into
            // the cache
            RWLock.UpgradeToWriterLock(Timeout.Infinite);
            try
            {
                // Extra check to avoid threading issues.
                if (LoadedLanguagesCache.Keys.Contains(ValidationLanguage))
                {
                    //The requested language has been loaded, lets get it from the word cache
                    WordCache.TryGetValue(CacheKey, out CacheEntry);
                    return CacheEntry;
                }

                //Populate the WordCache with the words from the XML document
                LoadLanguageDefinition(ValidationLanguage);

                //Now try to get the desired word. 
                WordCache.TryGetValue(CacheKey, out CacheEntry);
                return CacheEntry;
            }
            finally
            {
                RWLock.ReleaseLock();
            }
        }

        /// *****************************************************************
        /// <summary>
        /// Load the entire language definition XML file into the LanguageDict 
        /// dictionary. LanguageDict acts like a cache/lookup-table for all the 
        /// language strings.
        /// </summary>
        /// <param name="ValidationLanguage"></param>
        private static void LoadLanguageDefinition(ValidationLanguageEnum ValidationLanguage)
        {
            // Grab value of resource file name attribute.
            var Type = ValidationLanguage.GetType();
            var FieldInfo = Type.GetField(ValidationLanguage.ToString());
            var Attribs = FieldInfo.GetCustomAttributes(typeof(LanguageResourceFile), false) as LanguageResourceFile[];
            if (Attribs.Length != 1)
                throw new Exception("No language specified for Validation Language " + ValidationLanguage.ToString());
            var ResourceFileName = Attribs[0].ResourceFile;

            // Load the language defintion file into an XML document
            Assembly a = Assembly.GetExecutingAssembly();
            using (Stream LanguageStream = a.GetManifestResourceStream(ResourceFileName))
            {
                if (LanguageStream != null)
                {
                    StreamReader sr = new StreamReader(LanguageStream);
                    XDocument LangDefXMLDoc = XDocument.Load(sr);

                    //Populate the LanguageDict with all the language definitions found in the XML file
                    var Entries = (from E in LangDefXMLDoc.Elements().Elements()
                                   select E).ToList();

                    foreach (var entry in Entries)
                    {
                        string EntryName = entry.Attribute("name").Value.ToString().Trim();
                        string CacheKey = ValidationLanguage.ToString() + ":" + EntryName;
                        if (!WordCache.Keys.Contains(CacheKey))
                            WordCache.Add(CacheKey, entry.Value.Trim());
                        else
                            throw new ApplicationException("Duplicate '" + EntryName +
                                                           "' entry in the language definition xml file '" +
                                                           ResourceFileName + "'");
                    }

                    //Mark this language as loaded
                    LoadedLanguagesCache.Add(ValidationLanguage, true);
                }
            }
        }
    }
}
