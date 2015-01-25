using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class PhoneMaskRuleTest
    {
        [TestMethod]
        public void MoreThan10Digits_NotPassed()
        {
            var target = new PhoneMaskRule("49512312121");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LessThan10Digits_NotPassed()
        {
            var target = new PhoneMaskRule("49");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MoreThan10DigitsWithSimbols_NotPassed()
        {
            var target = new PhoneMaskRule("(495)123-12-121");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LessThan10DigitsWithSimbols_NotPassed()
        {
            var target = new PhoneMaskRule("(495)123-1-12");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MoreThan10DigitsWithSimbolsAndCode_NotPassed()
        {
            var target = new PhoneMaskRule("+7 (495)123-12-121");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LessThan10DigitsWithSimbolsAndCode_NotPassed()
        {
            var target = new PhoneMaskRule("+7 (495)123-12-1");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WrongCode_NotPassed()
        {
            var target = new PhoneMaskRule("+84951231212");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void HasLetter_NotPassed()
        {
            var target = new PhoneMaskRule("495123121a");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SimbolsAnd10Digits_Passed()
        {
            var target = new PhoneMaskRule("(495) 123-12-12");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SimbolsAndCodeAnd10Digits_Passed()
        {
            var target = new PhoneMaskRule("+7 (495) 123-12-12");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Only10Digits_Passed()
        {
            var target = new PhoneMaskRule("4951231212");
            var result = target.Passed();
            Assert.IsTrue(result);
        }
    }
}
