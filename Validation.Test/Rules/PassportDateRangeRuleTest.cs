using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class PassportDateRangeRuleTest
    {
        [TestMethod]
        public void GreatedThanToday_NotPassed()
        {
            var target = new PassportDateRangeRule(DateTime.Now.AddDays(1).ToString("dd.MM.yyyy"));
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LessThan1997_NotPassed()
        {
            var target = new PassportDateRangeRule(new DateTime(1990, 1, 1).ToString("dd.MM.yyyy"));
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GreaterThan1997AndLessThanToday_Passed()
        {
            var target = new PassportDateRangeRule(DateTime.Now.AddYears(-1).ToString("dd.MM.yyyy"));
            var result = target.Passed();
            Assert.IsTrue(result);
        }
    }
}
