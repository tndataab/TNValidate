using System;
using NUnit.Framework;

namespace TNValidate
{
    /// ***********************************************************************
    /// <summary>
    /// Tests for Boolean validation.
    /// </summary>
    [TestFixture]
    public class Bool_Tests
    {
        [Test]
        public void Test_Bool_True_1()
        {
            Validator Validate = new Validator();
            Validate.That(true, "Bool Value").IsTrue();
            Assert.IsFalse(Validate.HasErrors());
        }

        [Test]
        public void Test_Bool_True_2()
        {
            Validator Validate = new Validator();
            Validate.That(false, "Bool Value").IsTrue();
            Assert.IsTrue(Validate.HasErrors());
        }

        [Test]
        public void Test_Bool_False_1()
        {
            Validator Validate = new Validator();
            Validate.That(false, "Bool Value").IsFalse();
            Assert.IsFalse(Validate.HasErrors());
        }

        [Test]
        public void Test_Bool_False_2()
        {
            Validator Validate = new Validator();
            Validate.That(true, "Bool Value").IsFalse();
            Assert.IsTrue(Validate.HasErrors());
        }
    }
}
