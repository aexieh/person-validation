using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class BirthDateRangeRuleTest
    {
        [TestMethod]
        public void GreatedThanToday_NotPassed()
        {
            var target = new BirthDateRangeRule(DateTime.Now.AddDays(1).ToString("dd.MM.yyyy"));
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LessThan100YearsAgo_NotPassed()
        {
            var target = new BirthDateRangeRule(DateTime.Now.AddYears(-101).ToString("dd.MM.yyyy"));
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FiftyYearsAgo_Passed()
        {
            var target = new BirthDateRangeRule(DateTime.Now.AddYears(-50).ToString("dd.MM.yyyy"));
            var result = target.Passed();
            Assert.IsTrue(result);
        }
    }
}
