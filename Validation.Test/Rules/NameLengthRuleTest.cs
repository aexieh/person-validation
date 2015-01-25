using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class NameLengthRuleTest
    {
        [TestMethod]
        public void LessThan2_Passed_NotPassed()
        {
            var target = new NameLengthRule("Х");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MoreThan100_NotPassed()
        {
            var arr = new short[101];
            var name = string.Join("", arr);
            var target = new NameLengthRule(name);
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Between2And100_Passed()
        {
            var arr = new short[50];
            var name = string.Join("", arr);
            var target = new NameLengthRule(name);
            var result = target.Passed();
            Assert.IsTrue(result);
        }
    }
}
