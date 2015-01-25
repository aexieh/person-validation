using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class ForeignPassportSeriesValueRuleTest
    {
        [TestMethod]
        public void CorrectOkatoCode_Passed()
        {
            var target = new ForeignPassportSeriesValueRule("10");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WrongOkatoCode_NotPassed()
        {
            var target = new ForeignPassportSeriesValueRule("11");
            var result = target.Passed();
            Assert.IsFalse(result);
        }
    }
}
