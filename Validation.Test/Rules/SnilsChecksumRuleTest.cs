using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class SnilsChecksumRuleTest
    {
        [TestMethod]
        public void ValueIsLessThan001001998_Passed()
        {
            var target = new SnilsChecksumRule("001-001-997 99");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ChecksumLessThan100AndEqualsToLast2Digits_Passed()
        {
            var target = new SnilsChecksumRule("112-233-445 95");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ChecksumLessThan100AndNotEqualsToLast2Digits_NotPassed()
        {
            var target = new SnilsChecksumRule("112-233-445 96");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ChecksumEquals100AndLast2Digits00_Passed()
        {
            var target = new SnilsChecksumRule("112-233-547 00");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ChecksumEquals100AndLast2DigitsNot00_NotPassed()
        {
            var target = new SnilsChecksumRule("112-233-547 55");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ChecksumEquals101AndLast2Digits00_Passed()
        {
            var target = new SnilsChecksumRule("112-233-548 00");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ChecksumEquals101AndLast2DigitsNot00_NotPassed()
        {
            var target = new SnilsChecksumRule("112-233-548 01");
            var result = target.Passed();
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void ChecksumGreaterThan101AndReminderEqualsToLast2Digits_Passed()
        {
            var target = new SnilsChecksumRule("112-233-549 01");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ChecksumGreaterThan101AndReminderNotEqualsToLast2Digits_NotPassed()
        {
            var target = new SnilsChecksumRule("112-233-549 02");
            var result = target.Passed();
            Assert.IsFalse(result);
        }
    }
}
