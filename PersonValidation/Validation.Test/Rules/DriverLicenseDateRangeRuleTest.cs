using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class DriverLicenseDateRangeRuleTest
    {
        [TestMethod]
        public void GreatedThanToday_NotPassed()
        {
            var target = new DriverLicenseDateRangeRule(DateTime.Now.AddDays(1).ToString("dd.MM.yyyy"));
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LessThan85YearsAgo_NotPassed()
        {
            var target = new DriverLicenseDateRangeRule(DateTime.Now.AddYears(-90).ToString("dd.MM.yyyy"));
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GreaterThan85YearsAgoAndLessThanToday_Passed()
        {
            var target = new DriverLicenseDateRangeRule(DateTime.Now.AddYears(-1).ToString("dd.MM.yyyy"));
            var result = target.Passed();
            Assert.IsTrue(result);
        }
    }
}
