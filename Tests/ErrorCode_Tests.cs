using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TNValidate
{
    /// <summary>
    /// Contains tests for the Error Codes functionality.
    /// </summary>
    [TestFixture]
    public class ErrorCode_Tests
    {
        [Test]
        public void ErrorCodesSetCorrectly_Numeric()
        {
            var Validate = new Validator();
            Validate.That(42, "The Answer").IsGreaterThan(100);
            Assert.IsTrue(Validate.HasErrors());
            Assert.AreEqual(ValidationErrorCode.NumericIsGreaterThan, Validate.ValidatorResults[0].ErrorCode);
        }

        [Test]
        public void ErrorCodesSetCorrectly_String()
        {
            var Validate = new Validator();
            Validate.That("blah", "Name").IsLongerThan(10);
            Assert.IsTrue(Validate.HasErrors());
            Assert.AreEqual(ValidationErrorCode.StringIsLongerThan, Validate.ValidatorResults[0].ErrorCode);
        }

        [Test]
        public void ErrorCodesSetCorrectly_Date()
        {
            var Validate = new Validator();
            Validate.That(DateTime.Now.AddDays(-10), "Expires").IsNotAPastDate();
            Assert.IsTrue(Validate.HasErrors());
            Assert.AreEqual(ValidationErrorCode.DateIsNotAPastDate, Validate.ValidatorResults[0].ErrorCode);
        }

        [Test]
        public void CustomErrorCode_Simple()
        {
            var Validate = new Validator();
            Validate.That(42, "The Answer").WithErrorCode(666).IsGreaterThan(100);
            Assert.IsTrue(Validate.HasErrors());
            Assert.AreEqual(666, Validate.ValidatorResults[0].ErrorCode);
        }

        [Test]
        public void CustomErrorCode_WithNot()
        {
            var Validate = new Validator();
            Validate.That(42, "The Answer").WithErrorCode(999).Not().IsLessThan(100);
            Assert.IsTrue(Validate.HasErrors());
            Assert.AreEqual(999, Validate.ValidatorResults[0].ErrorCode);
        }
    }
}

