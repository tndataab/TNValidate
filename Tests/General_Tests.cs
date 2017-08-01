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
    /// General_Tests
    /// =============
    /// 2009-04-08 Created by Tore Nestenius, http://www.edument.se
    /// 
    /// Class that contains all of our general validation unit tests.
    /// </summary>
    [TestFixture]
    public class General_Tests
    {
        /// <summary>
        /// Test Validator Clear
        /// </summary>
        [Test]
        public void Test_Validator_Clear()
        {
            Validator Validate = new Validator();

            int Amount = 5;

            //Generate one validation violation
            Validate.That(Amount, "Amount").IsZero();

            //After clear there should be no validation violations anymore.
            Assert.IsTrue(Validate.HasErrors());

            Validate.Clear();

            //After clear there should be no validation violations anymore.
            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// Tests the .Is method on all validators that allows a lambda
        /// to be supplied.
        /// </summary>
        [Test]
        public void Test_Is_1()
        {
            var Validate = new Validator();
            Validate.That(25, "Square").Is(x => (int)Math.Pow(Math.Floor(Math.Sqrt((double)x)), 2) == x, "Must be a square number");
            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// Tests the .Is method on all validators that allows a lambda
        /// to be supplied.
        /// </summary>
        [Test]
        public void Test_Is_2()
        {
            var Validate = new Validator();
            Validate.That(26, "Square").Is(x => (int)Math.Pow(Math.Floor(Math.Sqrt((double)x)), 2) == x, "Must be a square number");
            Assert.IsTrue(Validate.HasErrors());
        }
    }
}
