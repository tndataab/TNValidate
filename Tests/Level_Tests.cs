using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TNValidate
{
    /// <summary>
    /// Tests for .WarnIf() and the level of a validation result.
    /// </summary>
    [TestFixture]
    public class Level_Tests
    {
        [Test]
        public void DefaultIsError()
        {
            var Validate = new Validator();
            int Answer = 69;
            Validate.That(Answer, "The Answer").Equals(42);
            Assert.AreEqual(1, Validate.ErrorCount());
            Assert.AreEqual(ValidatorResultLevel.Error, Validate.ValidatorResults[0].Level);
        }

        [Test]
        public void LevelSetCorrectly()
        {
            var Validate = new Validator();
            int Age = 15;
            Validate.That(Age, "Age").IsGreaterThanOrEqual(13)
                                     .WarnUnless().IsGreaterThanOrEqual(18);
            Assert.AreEqual(1, Validate.ValidatorResults.Count);
            Assert.AreEqual(ValidatorResultLevel.Warning, Validate.ValidatorResults[0].Level);
        }

        [Test]
        public void CountsSetCorrectly()
        {
            var Validate = new Validator();
            int Age = 15;
            Validate.That(Age, "Age").IsGreaterThanOrEqual(13)
                                     .WarnUnless().IsGreaterThanOrEqual(18);
            Assert.AreEqual(0, Validate.ErrorCount());
            Assert.IsFalse(Validate.HasErrors());
            Assert.AreEqual(1, Validate.WarningCount());
            Assert.IsTrue(Validate.HasWarnings());
        }
    }
}
