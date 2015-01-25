using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class InnMaskRuleTest
    {
        [TestMethod]
        public void MoreThan12Digits_NotPassed()
        {
            var target = new InnMaskRule("1234567891234");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LessThan12Digits_NotPassed()
        {
            var target = new InnMaskRule("123456789");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LessThan12DigitsWithSpace_NotPassed()
        {
            var target = new InnMaskRule(" 123456789");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void HasLetterCorrectLength_NotPassed()
        {
            var target = new InnMaskRule("1a3456789123");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod] 
        public void AllDigitsCorrectLength_Passed()
        {
            var target = new InnMaskRule("123456789123");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LeadingSpaceAndCorrectLength_Passed()
        {
            var target = new InnMaskRule(" 123456789123");
            var result = target.Passed();
            Assert.IsTrue(result);
        }
    }
}
