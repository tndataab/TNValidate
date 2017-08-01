using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Xml;
using NUnit.Framework;

namespace TNValidate
{
    /// ***********************************************************************
    /// <summary>
    /// Date_Tests
    /// ==========
    /// 2009-04-08 Created by Tore Nestenius, http://www.edument.se
    /// Class that contains all of our DateTime validation unit tests.
    /// </summary>
    [TestFixture]
    public class Date_Tests
    {
        // ----------------------------------------------------------------
        /// <summary>
        /// </summary>
        [Test]
        public void Test_Date_IsNotAFutureDate_1()
        {
            Validator Validate = new Validator();

            DateTime BirthDate = new DateTime(1990, 11, 20);

            // Generate one validation violation
            Validate.That(BirthDate, "BirthDate").IsNotAFutureDate();

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// </summary>
        [Test]
        public void Test_Date_IsNotAFutureDate_2()
        {
            Validator Validate = new Validator();

            DateTime BirthDate = DateTime.MaxValue;

            // Generate one validation violation
            Validate.That(BirthDate, "BirthDate").IsNotAFutureDate();

            Assert.IsTrue(Validate.HasErrors());
        }

        // ----------------------------------------------------------------
        /// <summary>
        /// </summary>
        [Test]
        public void Test_Date_IsNotAPastDate_1()
        {
            Validator Validate = new Validator();

            DateTime BirthDate = DateTime.MaxValue;

            // Generate one validation violation
            Validate.That(BirthDate, "BirthDate").IsNotAPastDate();

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// </summary>
        [Test]
        public void Test_Date_IsNotAPastDate_2()
        {
            Validator Validate = new Validator();

            DateTime BirthDate = DateTime.MinValue;

            // Generate one validation violation
            Validate.That(BirthDate, "BirthDate").IsNotAPastDate();

            Assert.IsTrue(Validate.HasErrors());
        }

        // ----------------------------------------------------------------
        /// <summary>
        /// </summary>
        [Test]
        public void Test_Date_IsNotMinMaxValue_1()
        {
            Validator Validate = new Validator();

            DateTime BirthDate = DateTime.MinValue;

            // Generate one validation violation
            Validate.That(BirthDate, "BirthDate").IsNotMinMaxValue();

            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// </summary>
        [Test]
        public void Test_Date_IsNotMinMaxValue_2()
        {
            Validator Validate = new Validator();

            DateTime BirthDate = DateTime.MaxValue;

            // Generate one validation violation
            Validate.That(BirthDate, "BirthDate").IsNotMinMaxValue();

            Assert.IsTrue(Validate.HasErrors());
        }

        // ----------------------------------------------------------------
        /// <summary>
        /// </summary>
        [Test]
        public void Test_Date_IsLaterThan_1()
        {
            Validator Validate = new Validator();

            DateTime BirthDate = new DateTime(2009, 11, 20);

            // Generate one validation violation
            Validate.That(BirthDate, "BirthDate").IsLaterThan(new DateTime(1990, 6, 24));

            Assert.IsFalse(Validate.HasErrors());
        }


        /// <summary>
        /// </summary>
        [Test]
        public void Test_Date_IsLaterThan_2()
        {
            Validator Validate = new Validator();

            DateTime BirthDate = new DateTime(1990, 11, 20);

            // Generate one validation violation
            Validate.That(BirthDate, "BirthDate").IsLaterThan(new DateTime(1990, 11, 20));

            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// </summary>
        [Test]
        public void Test_Date_IsLaterThan_3()
        {
            Validator Validate = new Validator();

            DateTime BirthDate = new DateTime(1980, 11, 20);

            // Generate one validation violation
            Validate.That(BirthDate, "BirthDate").IsLaterThan(new DateTime(1990, 6, 24));

            Assert.IsTrue(Validate.HasErrors());
        }

        // ----------------------------------------------------------------
        /// <summary>
        /// </summary>
        [Test]
        public void Test_Date_IsEarlierThan_1()
        {
            Validator Validate = new Validator();

            DateTime BirthDate = new DateTime(1980, 11, 20);

            // Generate one validation violation
            Validate.That(BirthDate, "BirthDate").IsEarlierThan(new DateTime(1990, 6, 24));

            Assert.IsFalse(Validate.HasErrors());
        }


        /// <summary>
        /// </summary>
        [Test]
        public void Test_Date_IsEarlierThan_2()
        {
            Validator Validate = new Validator();

            DateTime BirthDate = new DateTime(1990, 11, 20);

            // Generate one validation violation
            Validate.That(BirthDate, "BirthDate").IsEarlierThan(new DateTime(1990, 11, 20));

            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// </summary>
        [Test]
        public void Test_Date_IsEarlierThan_3()
        {
            Validator Validate = new Validator();

            DateTime BirthDate = new DateTime(2002, 4, 2);

            // Generate one validation violation
            Validate.That(BirthDate, "BirthDate").IsEarlierThan(new DateTime(1990, 6, 24));

            Assert.IsTrue(Validate.HasErrors());
        }
    }
}