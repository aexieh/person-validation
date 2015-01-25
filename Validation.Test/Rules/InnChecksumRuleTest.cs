using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class InnChecksumRuleTest
    {
        [TestMethod]
        public void CorrectInn_Passed()
        {
            var target = new InnChecksumRule("500100732259");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WrongInn_NotPassed()
        {
            var target = new InnChecksumRule("500100732258");
            var result = target.Passed();
            Assert.IsFalse(result);
        }
    }
}
