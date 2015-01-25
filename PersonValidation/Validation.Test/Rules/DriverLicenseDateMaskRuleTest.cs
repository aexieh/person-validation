using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class DriverLicenseDateMaskRuleTest
    {
        [TestMethod]
        public void WrongDateFormat1_NotPassed()
        {
            var target = new DateMaskRule("12.12.12345");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WrongDateFormat2_NotPassed()
        {
            var target = new DateMaskRule("12.121234");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WrongDateFormat3_NotPassed()
        {
            var target = new DateMaskRule("12.12.12.3");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CorrectDateFormat_Passed()
        {
            var target = new DateMaskRule("12.12.1234");
            var result = target.Passed();
            Assert.IsTrue(result);
        }
    }
}
