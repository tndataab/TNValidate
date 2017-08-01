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
    /// Numerical_Tests
    /// ===============
    /// 2009-04-08 Created by Tore Nestenius, http://www.edument.se
    /// 
    /// Class that contains all of our numerical validation unit tests.
    /// </summary>
    [TestFixture]
    public class Integer_Tests
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsZero_1()
        {
            Validator Validate = new Validator();

            int Amount = 0;

            Validate.That(Amount, "Amount").IsZero();

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsZero_2()
        {
            Validator Validate = new Validator();

            int Amount = 5;

            Validate.That(Amount, "Amount").IsZero();

            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsZero_3()
        {
            Validator Validate = new Validator();

            int Amount = -5;

            Validate.That(Amount, "Amount").IsZero();

            Assert.IsTrue(Validate.HasErrors());
        }


        //----------------------------------------------------------------------
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_Equals_1()
        {
            Validator Validate = new Validator();

            int Amount = 5;

            Validate.That(Amount, "Amount").Equals(10);

            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_Equals_2()
        {
            Validator Validate = new Validator();

            int Amount = 10;

            Validate.That(Amount, "Amount").Equals(10);

            Assert.IsFalse(Validate.HasErrors());
        }

        //----------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsGreaterThanOrEqual_1()
        {
            Validator Validate = new Validator();

            int Amount = 10;

            Validate.That(Amount, "Amount").IsGreaterThanOrEqual(10);

            Assert.IsFalse(Validate.HasErrors());
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsGreaterThanOrEqual_2()
        {
            Validator Validate = new Validator();

            int Amount = 15;

            Validate.That(Amount, "Amount").IsGreaterThanOrEqual(10);

            Assert.IsFalse(Validate.HasErrors());
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsGreaterThanOrEqual_3()
        {
            Validator Validate = new Validator();

            int Amount = 5;

            Validate.That(Amount, "Amount").IsGreaterThanOrEqual(10);

            Assert.IsTrue(Validate.HasErrors());
        }

        //----------------------------------------------------------------------
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsLessThan_1()
        {
            Validator Validate = new Validator();

            int Amount = 5;

            Validate.That(Amount, "Amount").IsLessThan(10);

            Assert.IsFalse(Validate.HasErrors());
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsLessThan_2()
        {
            Validator Validate = new Validator();

            int Amount = 10;

            Validate.That(Amount, "Amount").IsLessThan(10);

            Assert.IsTrue(Validate.HasErrors());
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsLessThan_3()
        {
            Validator Validate = new Validator();

            int Amount = 15;

            Validate.That(Amount, "Amount").IsLessThan(10);

            Assert.IsTrue(Validate.HasErrors());
        }


        //----------------------------------------------------------------------
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsGreaterThan_1()
        {
            Validator Validate = new Validator();

            int Amount = 5;

            Validate.That(Amount, "Amount").IsGreaterThan(10);

            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsGreaterThan_2()
        {
            Validator Validate = new Validator();

            int Amount = 10;

            Validate.That(Amount, "Amount").IsGreaterThan(10);

            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsGreaterThan_3()
        {
            Validator Validate = new Validator();

            int Amount = 15;

            Validate.That(Amount, "Amount").IsGreaterThan(10);

            Assert.IsFalse(Validate.HasErrors());
        }

        //----------------------------------------------------------------------
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsLessThanOrEqual_1()
        {
            Validator Validate = new Validator();

            int Amount = 10;

            Validate.That(Amount, "Amount").IsLessThanOrEqual(10);

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsLessThanOrEqual_2()
        {
            Validator Validate = new Validator();

            int Amount = 5;

            Validate.That(Amount, "Amount").IsLessThanOrEqual(10);

            Assert.IsFalse(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsLessThanOrEqual_3()
        {
            Validator Validate = new Validator();

            int Amount = 15;

            Validate.That(Amount, "Amount").IsLessThanOrEqual(10);

            Assert.IsTrue(Validate.HasErrors());
        }

        //---------------------------------------------------------------------------
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsGreaterThan_IsLessThan_1()
        {
            Validator Validate = new Validator(ValidationLanguageEnum.English, ErrorMode.AllErrors);

            int Amount = 2;

            Validate.That(Amount, "Amount").IsGreaterThan(5).IsLessThan(15);

            Assert.IsTrue(Validate.ErrorCount()==1);
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsGreaterThan_IsLessThan_2()
        {
            Validator Validate = new Validator(ValidationLanguageEnum.English, ErrorMode.AllErrors);

            int Amount = 10;

            Validate.That(Amount, "Amount").IsGreaterThan(5).IsLessThan(15);

            Assert.IsTrue(Validate.ErrorCount() == 0);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsGreaterThan_IsLessThan_3()
        {
            Validator Validate = new Validator(ValidationLanguageEnum.English, ErrorMode.AllErrors);

            int Amount = 20;

            Validate.That(Amount, "Amount").IsGreaterThan(5).IsLessThan(15);

            Assert.IsTrue(Validate.ErrorCount() == 1);
        }

        //---------------------------------------------------------------------------
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsNotZero_IsLessThan_1()
        {
            Validator Validate = new Validator(ValidationLanguageEnum.English, ErrorMode.AllErrors);

            int Amount = 0;

            Validate.That(Amount, "Amount").Not().IsZero().IsLessThan(15);

            Assert.IsTrue(Validate.ErrorCount() == 1);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsNotZero_IsLessThan_2()
        {
            Validator Validate = new Validator(ValidationLanguageEnum.English, ErrorMode.AllErrors);

            int Amount = 15;

            Validate.That(Amount, "Amount").Not().IsZero().IsLessThan(15);

            Assert.IsTrue(Validate.ErrorCount() == 1);
        }


        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsNotZero_IsGreaterThan_IsGreaterThan_1()
        {
            Validator Validate = new Validator(ValidationLanguageEnum.English, ErrorMode.AllErrors);

            int Amount = 0;

            Validate.That(Amount, "Amount").Not().IsZero().IsGreaterThan(15).IsGreaterThan(20);

            Assert.IsTrue(Validate.ErrorCount() == 3);
        }


        //---------------------------------------------------------------------------
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_Between_1()
        {
            Validator Validate = new Validator();

            int Amount = 5;

            Validate.That(Amount, "Amount").Between(10, 20);

            Assert.IsTrue(Validate.ErrorCount() == 1);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_Between_2()
        {
            Validator Validate = new Validator();

            int Amount = 10;

            Validate.That(Amount, "Amount").Between(10, 20);

            Assert.IsTrue(Validate.ErrorCount() == 0);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_Between_3()
        {
            Validator Validate = new Validator();

            int Amount = 15;

            Validate.That(Amount, "Amount").Between(10, 20);

            Assert.IsTrue(Validate.ErrorCount() == 0);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_Between_4()
        {
            Validator Validate = new Validator();

            int Amount = 20;

            Validate.That(Amount, "Amount").Between(10, 20);

            Assert.IsTrue(Validate.ErrorCount() == 0);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_Between_5()
        {
            Validator Validate = new Validator();

            int Amount = 25;

            Validate.That(Amount, "Amount").Between(10, 20);

            Assert.IsTrue(Validate.ErrorCount() == 1);
        }


        //---------------------------------------------------------------------------
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsGreaterThan_IsGreaterThan_IsGreaterThan_1()
        {
            Validator Validate = new Validator(ValidationLanguageEnum.English, ErrorMode.AllErrors);

            int Amount = 5;

            Validate.That(Amount, "Amount").IsGreaterThan(10).IsGreaterThan(20).IsGreaterThan(30);

            Assert.IsTrue(Validate.ErrorCount() == 3);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsGreaterThan_IsGreaterThan_IsGreaterThan_2()
        {
            Validator Validate = new Validator(ValidationLanguageEnum.English, ErrorMode.AllErrors);

            int Amount = 35;

            Validate.That(Amount, "Amount").IsGreaterThan(10).IsGreaterThan(20).IsGreaterThan(30);

            Assert.IsTrue(Validate.ErrorCount() == 0);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_Int_IsGreaterThan_IsGreaterThan_IsGreaterThan_3()
        {
            Validator Validate = new Validator(ValidationLanguageEnum.English, ErrorMode.OneErrorPerField);

            int Amount = 5;

            Validate.That(Amount, "Amount").IsGreaterThan(10);
            Validate.That(Amount, "Amount").IsGreaterThan(20);
            Validate.That(Amount, "Amount").IsGreaterThan(30);

            Assert.IsTrue(Validate.ErrorCount() == 1);
        }

        //-------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_uint_IsGreaterThan_1()
        {
            Validator Validate = new Validator();

            uint Amount = 4294967290;

            Validate.That(Amount, "Amount").IsGreaterThan(10);

            Assert.IsFalse(Validate.HasErrors());
        }


        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_short_IsGreaterThan_1()
        {
            Validator Validate = new Validator();

            short Amount = 30000;

            Validate.That(Amount, "Amount").IsGreaterThan(29000);

            Assert.IsFalse(Validate.HasErrors());
        }


        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_ushort_IsGreaterThan_1()
        {
            Validator Validate = new Validator();

            ushort Amount = 60000;

            Validate.That(Amount, "Amount").IsGreaterThan(50000);

            Assert.IsFalse(Validate.HasErrors());
        }


        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_long_IsGreaterThan_1()
        {
            Validator Validate = new Validator();

            long Amount = 9223372036854775000;

            Validate.That(Amount, "Amount").Not().IsLessThan(1000);

            Assert.IsFalse(Validate.HasErrors());
        }


        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_ulong_IsGreaterThan_1()
        {
            Validator Validate = new Validator();

            ulong Amount = 18446744073709551615;

            Validate.That(Amount, "Amount").Not().IsGreaterThan(1000);

            Assert.IsTrue(Validate.HasErrors());
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_byte_IsGreaterThan_1()
        {
            Validator Validate = new Validator();

            byte Amount = 244;

            Validate.That(Amount, "Amount").Not().IsGreaterThan(200);

            Assert.IsTrue(Validate.HasErrors());
        }


        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_sbyte_IsGreaterThan_1()
        {
            Validator Validate = new Validator();

            sbyte Amount = -120;

            Validate.That(Amount, "Amount").Not().IsGreaterThan(-100);

            Assert.IsFalse(Validate.HasErrors());
        }


        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_decimal_IsGreaterThan_1()
        {
            Validator Validate = new Validator();

            decimal Amount = -12.0m;

            Validate.That(Amount, "Amount").Not().IsGreaterThan(-4.4m);

            Assert.IsFalse(Validate.HasErrors());
        }


        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_float_IsGreaterThan_1()
        {
            Validator Validate = new Validator();

            float Amount = -12.0F;

            Validate.That(Amount, "Amount").Not().IsGreaterThan(-4.4F);

            Assert.IsFalse(Validate.HasErrors());
        }

        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test_double_IsGreaterThan_1()
        {
            Validator Validate = new Validator(ValidationLanguageEnum.Swedish);

            double Amount = -12.0D;

            Validate.That(Amount, "Amount").Not().IsGreaterThan(-4.4D);

            Assert.IsFalse(Validate.HasErrors());
        }
    }
}
