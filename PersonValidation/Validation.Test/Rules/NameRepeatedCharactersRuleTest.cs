using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class NameRepeatedCharactersRuleTest
    {
        [TestMethod]
        public void DoubleНyphen_NotPassed()
        {
            var target = new NameRepeatedCharactersRule("Петров--Водкин");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DoubleSpace_NotPassed()
        {
            var target = new NameRepeatedCharactersRule("Петров  Водкин");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TripleLetter_NotPassed()
        {
            var target = new NameRepeatedCharactersRule("Петроффф");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DoubleLetter_Passed()
        {
            var target = new NameRepeatedCharactersRule("Петрофф");
            var result = target.Passed();
            Assert.IsTrue(result);
        }
    }
}
