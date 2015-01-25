using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Rules;

namespace Validation.Test.Rules
{
    [TestClass]
    public class PhoneCodeRuleTest
    {
        [TestMethod]
        public void CorrectPhoneCode_Passed()
        {
            var target = new PhoneCodeRule("4951231212");
            var result = target.Passed();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WrongPhoneCode_NotPassed()
        {
            var target = new PhoneCodeRule("1111231212");
            var result = target.Passed();
            Assert.IsFalse(result);
        }
    }
}
