using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class PassportSeriesOkatoRuleTest
    {
        [TestMethod]
        public void CorrectOkatoCode97_Passed()
        {
            var target = new PassportSeriesOkatoRule("1297");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CorrectOkatoCode03_Passed()
        {
            var target = new PassportSeriesOkatoRule("1203");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WrongOkatoCode02_NotPassed()
        {
            var target = new PassportSeriesOkatoRule("1202");
            var result = target.Passed();
            Assert.IsFalse(result);
        }
    }
}
