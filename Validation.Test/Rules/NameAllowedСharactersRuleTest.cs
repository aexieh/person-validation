using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class NameAllowedСharactersRuleTest
    {
        [TestMethod]
        public void AllLatin_Passed()
        {
            var target = new NameAllowedСharactersRule("Petrov");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AllCyrillic_Passed()
        {
            var target = new NameAllowedСharactersRule("Петров");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Mixed_NotPassed()
        {
            var target = new NameAllowedСharactersRule("Петроv");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WithSpace_Passed()
        {
            var target = new NameAllowedСharactersRule("Петров Водкин");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WithНyphen_Passed()
        {
            var target = new NameAllowedСharactersRule("Петров-Водкин");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WithНyphenFirst_NotPassed()
        {
            var target = new NameAllowedСharactersRule("-Петров");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WithНyphenLast_NotPassed()
        {
            var target = new NameAllowedСharactersRule("Петров-");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WithNumeric_NotPassed()
        {
            var target = new NameAllowedСharactersRule("Петров 1");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WithNonLetter_NotPassed()
        {
            var target = new NameAllowedСharactersRule("Петров~");
            var result = target.Passed();
            Assert.IsFalse(result);
        }
    }
}
