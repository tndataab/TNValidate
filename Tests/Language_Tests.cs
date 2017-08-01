using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TNValidate
{
    /// <summary>
    /// Tests for making sure all languages in the enum work.
    /// </summary>
    [TestFixture]
    public class Language_Tests
    {
        [Test]
        public void Check_Languages_Usable()
        {
            foreach (ValidationLanguageEnum Lang in Enum.GetValues(typeof(ValidationLanguageEnum)))
            {
                var Validate = new Validator(Lang);
                Validate.That(42, "The Answer").IsGreaterThan(100);
                Assert.IsTrue(Validate.HasErrors());
                Assert.IsFalse(string.IsNullOrEmpty(Validate.ValidatorResults[0].ValidationMessage));
            }
        }
    }
}

