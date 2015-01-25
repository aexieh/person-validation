using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class EmailMaskRuleTest
    {
        [TestMethod]
        public void WrongEmail1_NotPassed()
        {
            var target = new EmailMaskRule("foo@bar.c");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WrongEmail2_NotPassed()
        {
            var target = new EmailMaskRule("foobar.com");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WrongEmail3_NotPassed()
        {
            var target = new EmailMaskRule("@bar.com");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WrongEmail4_NotPassed()
        {
            var target = new EmailMaskRule("foo@barcom");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CorrectEmail_Passed()
        {
            var target = new EmailMaskRule("foo@bar.com");
            var result = target.Passed();
            Assert.IsTrue(result);
        }
    }
}
