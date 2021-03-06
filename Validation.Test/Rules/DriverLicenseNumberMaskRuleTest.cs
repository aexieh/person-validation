﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class DriverLicenseNumberMaskRuleTest
    {
        [TestMethod]
        public void HasLetter_NotPassed()
        {
            var target = new DriverLicenseNumberMaskRule("12345a");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WrongLength_NotPassed()
        {
            var target = new DriverLicenseNumberMaskRule("12345");
            var result = target.Passed();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OnlyDigitsCorrectLength_Passed()
        {
            var target = new DriverLicenseNumberMaskRule("123456");
            var result = target.Passed();
            Assert.IsTrue(result);
        }
    }
}
