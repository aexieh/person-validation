using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class PassportSeriesMaskRuleTest
    {
        [TestMethod]
        public void HasLetter_NotPassed()
        {
            var target = new PassportSeriesMaskRule("123a");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WrongLength_NotPassed()
        {
            var target = new PassportSeriesMaskRule("12345");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OnlyDigitsCorrectLength_Passed()
        {
            var target = new PassportSeriesMaskRule("1234");
            var result = target.Passed();
            Assert.IsTrue(result);
        }
    }
}
