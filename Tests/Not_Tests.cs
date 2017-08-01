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
    /// Integer_Tests
    /// =============
    /// 2009-04-15 Created by Tore Nestenius, http://www.edument.se
    /// 
    /// Class that contains all of our Negative .Not() unit tests.
    /// </summary>
    [TestFixture]
    public class Not_Tests
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_Not_1()
        {
            Validator Validate = new Validator();

            int Amount = 0;

            Validate.That(Amount, "Amount").Not().IsZero();

            Assert.IsTrue(Validate.HasErrors());
            Assert.AreEqual(Validate.ValidatorResults[0].ValidationMessage, "Amount must not be zero");
        }

        //------------------------------------------------------------------
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_Not_2()
        {
            Validator Validate = new Validator();

            int Amount = 0;

            Validate.That(Amount, "Amount").Not().IsLessThan(10);

            //Error
            Assert.IsTrue(Validate.HasErrors());
            Assert.AreEqual(Validate.ValidatorResults[0].ValidationMessage, "Amount must not be less than 10");
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_Not_3()
        {
            Validator Validate = new Validator();

            int Amount = 5;

            Validate.That(Amount, "Amount").Not().IsZero().Not().IsLessThan(10);

            //Error
            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_Not_4()
        {
            Validator Validate = new Validator();

            int Amount = 10;

            Validate.That(Amount, "Amount").Not().IsZero().Not().IsLessThan(10);

            //Ok
            Assert.IsFalse(Validate.HasErrors());
        }


        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_Not_5()
        {
            Validator Validate = new Validator();

            int Amount = 15;

            Validate.That(Amount, "Amount").Not().IsZero().Not().IsLessThan(10);

            //OK
            Assert.IsFalse(Validate.HasErrors());
        }
            
        //------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_Not_1()
        {
            Validator Validate = new Validator();

            string Name="";

            Validate.That(Name, "Name").Not().IsEmpty().Not().IsLongerThan(5);

            //error
            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_Not_2()
        {
            Validator Validate = new Validator();

            string Name = "Joe";

            Validate.That(Name, "Name").Not().IsEmpty().Not().IsLongerThan(5);

            //OK
            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_Not_3()
        {
            Validator Validate = new Validator();

            string Name = "John";

            Validate.That(Name, "Name").Not().IsEmpty().Not().IsLongerThan(5);

            //OK
            Assert.IsFalse(Validate.HasErrors());
        }


        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_String_Not_4()
        {
            Validator Validate = new Validator();

            string Name = "Johnny";

            Validate.That(Name, "Name").Not().IsEmpty().Not().IsLongerThan(5);

            //Error
            Assert.IsTrue(Validate.HasErrors());
        }

        //------------------------------------------------------------------
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Not_Date_IsEarlierThan_1()
        {
            Validator Validate = new Validator();

            DateTime BirthDate = new DateTime(2002, 4, 2);

            //Generate one validation violation
            Validate.That(BirthDate, "BirthDate").Not().IsEarlierThan(new DateTime(1990, 6, 24));

            Assert.IsFalse(Validate.HasErrors());
        }
    }
}
