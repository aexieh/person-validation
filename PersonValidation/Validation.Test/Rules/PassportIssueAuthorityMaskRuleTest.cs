using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class PassportIssueAuthorityMaskRuleTest
    {
        [TestMethod]
        public void MoreThan6Digits_NotPassed()
        {
            var target = new PassportIssueAuthorityMaskRule("1234567");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LessThan6Digits_NotPassed()
        {
            var target = new PassportIssueAuthorityMaskRule("12345");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LessThan6DigitsWithSpace_NotPassed()
        {
            var target = new PassportIssueAuthorityMaskRule(" 12345");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void HasLetterCorrectLength_NotPassed()
        {
            var target = new PassportIssueAuthorityMaskRule("1a3-456");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void HyphenAnd6Digits_Passed()
        {
            var target = new PassportIssueAuthorityMaskRule("123-456");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TwoHyphensAnd6Digits_NotPassed()
        {
            var target = new PassportIssueAuthorityMaskRule("123--456");
            var result = target.Passed();
            Assert.IsFalse(result);
        }
    }
}
