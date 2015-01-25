using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class SnilsMaskRuleTest
    {
        [TestMethod]
        public void MoreThan11Digits_NotPassed()
        {
            var target = new SnilsMaskRule("123456789123");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LessThan11Digits_NotPassed()
        {
            var target = new SnilsMaskRule("123456789");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LessThan11DigitsWithSpace_NotPassed()
        {
            var target = new SnilsMaskRule(" 123456789");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void HasLetterCorrectLength_NotPassed()
        {
            var target = new SnilsMaskRule("1a3-456-789-12");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void HyphensAnd11Digits_Passed()
        {
            var target = new SnilsMaskRule("123-456-789-12");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HyphensAndSpacesAnd11Digits_Passed()
        {
            var target = new SnilsMaskRule(" 123-456-789 12");
            var result = target.Passed();
            Assert.IsTrue(result);
        }
    }
}
