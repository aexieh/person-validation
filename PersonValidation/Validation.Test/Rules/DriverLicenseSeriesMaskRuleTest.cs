using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class DriverLicenseSeriesMaskRuleTest
    {
        [TestMethod]
        public void WrongLength_NotPassed()
        {
            var target = new DriverLicenseSeriesMaskRule("12345");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CorrectLength1Letter_NotPassed()
        {
            var target = new DriverLicenseSeriesMaskRule("111ц");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CorrectLength1Digit_NotPassed()
        {
            var target = new DriverLicenseSeriesMaskRule("1ццц");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CorrectLength2DigitsLetterFirst_NotPassed()
        {
            var target = new DriverLicenseSeriesMaskRule("цц11");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CorrectLength2Digits2Letters_Passed()
        {
            var target = new DriverLicenseSeriesMaskRule("12Цц");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CorrectLengthAllDigits_Passed()
        {
            var target = new DriverLicenseSeriesMaskRule("1234");
            var result = target.Passed();
            Assert.IsTrue(result);
        }
    }
}
