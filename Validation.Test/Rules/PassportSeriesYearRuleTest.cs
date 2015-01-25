using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class PassportSeriesYearRuleTest
    {
        [TestMethod]
        //Этот тест упадет в 2097.
        public void Last2DigitsIs97AndGreaterThanCurrentYear_Passed()
        {
            var target = new PassportSeriesYearRule("1297");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        //Этот тест упадет в 2097.
        public void Last2DigitsGreaterThan97AndGreaterThanCurrentYear_Passed()
        {
            var target = new PassportSeriesYearRule("1298");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        //Этот тест упадет в 2113.
        public void Last2DigitsLessThan97AndLessThanCurrentYear_Passed()
        {
            var target = new PassportSeriesYearRule("1213");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Last2DigitsLessThan97AndGreaterThanCurrentYearPlus5_NotPassed()
        {
            var target = new PassportSeriesYearRule("1230");
            var result = target.Passed();
            Assert.IsFalse(result);
        }
    }
}
