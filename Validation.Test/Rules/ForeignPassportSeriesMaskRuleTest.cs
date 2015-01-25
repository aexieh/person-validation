using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class ForeignPassportSeriesMaskRuleTest
    {
        [TestMethod]
        public void HasLetter_NotPassed()
        {
            var target = new ForeignPassportSeriesMaskRule("1a");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WrongLength_NotPassed()
        {
            var target = new ForeignPassportSeriesMaskRule("123");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OnlyDigitsCorrectLength_Passed()
        {
            var target = new ForeignPassportSeriesMaskRule("12");
            var result = target.Passed();
            Assert.IsTrue(result);
        }
    }
}
