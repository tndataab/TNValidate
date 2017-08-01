using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Resources;
using System.Threading;
using System.Xml;
using NUnit.Framework;

namespace TNValidate
{
    /// ***********************************************************************
    /// <summary>
    /// String_Tests
    /// =============
    /// 2009-04-08 Created by Tore Nestenius, http://www.edument.se
    /// 
    /// Class that contains all of our string validation unit tests.
    /// </summary>
    [TestFixture]
    public class String_Tests
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsEmpty_1()
        {
            Validator Validate = new Validator();

            string Name="";

            //Generate one validation violation
            Validate.That(Name, "Name").IsEmpty();

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsEmpty_2()
        {
            Validator Validate = new Validator();

            string Name = "George";

            Validate.That(Name, "Name").IsEmpty();

            Assert.IsTrue(Validate.HasErrors());
        }

        //----------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsLongerThan_1()
        {
            Validator Validate = new Validator();

            string Name = "Lenny";


            Validate.That(Name, "Name").IsLongerThan(5);

            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsLongerThan_2()
        {
            Validator Validate = new Validator();

            string Name = "Joe";

            Validate.That(Name, "Name").IsLongerThan(5);

            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsLongerThan_3()
        {
            Validator Validate = new Validator();

            string Name = "George";

            Validate.That(Name, "Name").IsLongerThan(5);

            Assert.IsFalse(Validate.HasErrors());
        }

        //----------------------------------------------------------------
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsShorterThan_1()
        {
            Validator Validate = new Validator();

            string Name = "Jonathan";

            Validate.That(Name, "Name").IsShorterThan(5);

            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsShorterThan_2()
        {
            Validator Validate = new Validator();

            string Name = "Benny";

            Validate.That(Name, "Name").IsShorterThan(5);

            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsShorterThan_3()
        {
            Validator Validate = new Validator();

            string Name = "Joe";

            Validate.That(Name, "Name").IsShorterThan(5);

            Assert.IsFalse(Validate.HasErrors());
        }


        //----------------------------------------------------------------
        
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_MatchRegex_1()
        {
            Validator Validate = new Validator();

            string AgeString = "12345";

            Validate.That(AgeString, "Age").MatchRegex("(\\d+)","Age is not valid");

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_MatchRegex_2()
        {
            Validator Validate = new Validator();

            string AgeString = "Joe";

            Validate.That(AgeString, "Age").MatchRegex("(\\d+)", "Age is not valid");

            Assert.IsTrue(Validate.HasErrors());
        }

        [Test]
        public void Test_String_MatchRegex_3()
        {
            Validator Validate = new Validator();

            string TestString = "OMG IT'S A MONKEY!!!";

            Validate.That(TestString, "Monkey").MatchRegex("(monkey)", System.Text.RegularExpressions.RegexOptions.IgnoreCase, "No monkey :-O");

            Assert.IsFalse(Validate.HasErrors());
        }


        //----------------------------------------------------------------
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsEmail_1()
        {
            Validator Validate = new Validator();

            string Email = "info@tn-data.se";

            Validate.That(Email, "Email").IsEmail();

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsEmail_2()
        {
            Validator Validate = new Validator();

            string Email = "info#tn-data.se";

            Validate.That(Email, "Email").IsEmail();

            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsEmail_3()
        {
            Validator Validate = new Validator();

            string Email = "my email is info@tn-data.se";

            Validate.That(Email, "Email").IsEmail();

            Assert.IsTrue(Validate.HasErrors());
        }

        //----------------------------------------------------------------
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsURL_1()
        {
            Validator Validate = new Validator();

            string URL = "http://www.tn-data.se";

            Validate.That(URL, "URL").IsURL();

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsURL_2()
        {
            Validator Validate = new Validator();

            string URL = "www.tn-data.se";

            Validate.That(URL, "URL").IsURL();

            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsURL_3()
        {
            Validator Validate = new Validator();

            string URL = "ftp://user:pass@ftp.tn-data.se";

            Validate.That(URL, "URL").IsURL();

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsURL_4()
        {
            Validator Validate = new Validator();

            string URL = "ftp://user@ftp.tn-data.se";

            Validate.That(URL, "URL").IsURL();

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsURL_5()
        {
            Validator Validate = new Validator();

            string URL = "http://foo.bar.b-z.ftp.tn-data.se/x/y/z.aspx?y=a%40b+c&z=";

            Validate.That(URL, "URL").IsURL();

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsURL_6()
        {
            Validator Validate = new Validator();

            string URL = "visit http://foo.bar.b-z.ftp.tn-data.se/x/y/z.aspx?y=a%40b+c&z=";

            Validate.That(URL, "URL").IsURL();

            Assert.IsTrue(Validate.HasErrors());
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsURL_7()
        {
            Validator Validate = new Validator();

            string URL = "http://foo.bar.b-z.ftp.tn-data.se:8080/x/y/z.aspx?y=a%40b+c&z=";

            Validate.That(URL, "URL").IsURL();

            Assert.IsFalse(Validate.HasErrors());
        }

        //----------------------------------------------------------------
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsDate_1()
        {
            Validator Validate = new Validator();

            string DateStr = "2009-02-20 12:23";

            Validate.That(DateStr, "SalesDate").IsDate();

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsDate_2()
        {
            Validator Validate = new Validator();

            string DateStr = "20090120 12:23";

            Validate.That(DateStr, "SalesDate").IsDate();

            Assert.IsTrue(Validate.HasErrors());
        }

        //----------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsInteger_1()
        {
            Validator Validate = new Validator();

            string AmountStr = "1234";

            Validate.That(AmountStr, "Amount").IsInteger();

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsInteger_2()
        {
            Validator Validate = new Validator();

            string AmountStr = "Hello";

            Validate.That(AmountStr, "Amount").IsInteger();

            Assert.IsTrue(Validate.HasErrors());
        }


        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsInteger_3()
        {
            Validator Validate = new Validator();

            string AmountStr = "123,456";

            Validate.That(AmountStr, "Amount").IsInteger();

            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsInteger_4()
        {
            Validator Validate = new Validator();

            string AmountStr = "123.456";

            Validate.That(AmountStr, "Amount").IsInteger();

            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsInteger_5()
        {
            Validator Validate = new Validator();

            string AmountStr = "";

            Validate.That(AmountStr, "Amount").IsInteger();

            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsInteger_6()
        {
            Validator Validate = new Validator();

            string AmountStr = "-12345";

            Validate.That(AmountStr, "Amount").IsInteger();

            Assert.IsFalse(Validate.HasErrors());
        }


        //----------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsDecimal_1()
        {
            Validator Validate = new Validator();

            string WeightStr = "12,34";

            Validate.That(WeightStr, "Weight").IsDecimal();

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsDecimal_2()
        {
            Validator Validate = new Validator();

            string WeightStr = "1234";

            Validate.That(WeightStr, "Weight").IsDecimal();

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsDecimal_3()
        {
            Validator Validate = new Validator();

            string WeightStr = "-12,34";

            Validate.That(WeightStr, "Weight").IsDecimal();

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsDecimal_4()
        {
            Validator Validate = new Validator();

            string WeightStr = "Hello";

            Validate.That(WeightStr, "Weight").IsDecimal();

            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsDecimal_5()
        {
            // Need a culture where . is allowed.
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            Validator Validate = new Validator();

            string WeightStr = "12.34";

            Validate.That(WeightStr, "Weight").IsDecimal();

            Assert.IsFalse(Validate.HasErrors());
        }


        //----------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_HasALengthBetween_1()
        {
            Validator Validate = new Validator();

            string Password = "f3x0x22";

            Validate.That(Password, "Password").HasALengthBetween(3, 10);

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_HasALengthBetween_2()
        {
            Validator Validate = new Validator();

            string Password = "sx";

            Validate.That(Password, "Password").HasALengthBetween(3, 10);

            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_HasALengthBetween_3()
        {
            Validator Validate = new Validator();

            string Password = "qwea98c98989893489zx89d821";

            Validate.That(Password, "Password").HasALengthBetween(3, 10);

            Assert.IsTrue(Validate.HasErrors());
        }



        //----------------------------------------------------------------
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_StartsWith_1()
        {
            Validator Validate = new Validator();

            string URL = "http://www.tn-data.se";

            Validate.That(URL, "URL").StartsWith("http://");

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_StartsWith_2()
        {
            Validator Validate = new Validator();

            string URL = "htp://www.tn-data.se";

            Validate.That(URL, "URL").StartsWith("http://");

            Assert.IsTrue(Validate.HasErrors());
        }

        //----------------------------------------------------------------
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_EndsWith_1()
        {
            Validator Validate = new Validator();

            string URL = "http://www.tn-data.se";

            Validate.That(URL, "URL").EndsWith(".se");

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_EndsWith_2()
        {
            Validator Validate = new Validator();

            string URL = "htp://www.tn-data.se";

            Validate.That(URL, "URL").EndsWith(".com");

            Assert.IsTrue(Validate.HasErrors());
        }


        //----------------------------------------------------------------
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_Contains_1()
        {
            Validator Validate = new Validator();

            string URL = "http://www.tn-data.se";

            Validate.That(URL, "URL").Contains("://");

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_Contains_2()
        {
            Validator Validate = new Validator();

            string URL = "www.tn-data.se";

            Validate.That(URL, "URL").Contains("://");

            Assert.IsTrue(Validate.HasErrors());
        }


        //----------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsLength_1()
        {
            Validator Validate = new Validator();

            string AccountNumber = "5334243";

            Validate.That(AccountNumber, "Account Number").IsLength(10);

            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsLength_2()
        {
            Validator Validate = new Validator();

            string AccountNumber = "0123456789";

            Validate.That(AccountNumber, "Account Number").IsLength(10);

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_IsLength_3()
        {
            Validator Validate = new Validator();

            string AccountNumber = "01234567890";

            Validate.That(AccountNumber, "Account Number").IsLength(10);

            Assert.IsTrue(Validate.HasErrors());
        }

    }
}
