using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class PassportNumberRangeRuleTest
    {
        [TestMethod]
        public void LessThan101_NotPassed()
        {
            var target = new PassportNumberRangeRule("000100");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GreaterThan999999_NotPassed()
        {
            var target = new PassportNumberRangeRule("9999990");
            var result = target.Passed();
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void Between101And999999_Passed()
        {
            var target = new PassportNumberRangeRule("008880");
            var result = target.Passed();
            Assert.IsTrue(result);
        }
    }
}
