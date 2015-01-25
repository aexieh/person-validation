﻿using System.Collections.Generic;
using System.Linq;

namespace Validation.Rules
{
    public class PhoneCodeRule : IRule
    {
        private readonly string _checkingValue;
        private readonly IEnumerable<int> _phoneCodes;

        public int ViolationCode { get { return 22; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public PhoneCodeRule(string value)
        {
            _checkingValue = value != null ? value.Trim() : string.Empty;
            _phoneCodes = new List<int> { 
                301,302,336,341,342,343,345,346,347,349,351,352,353,381,382,383,384,385,388,390,391,
                394,395,401,411,413,415,416,421,423,424,426,427,471,472,473,474,475,478,481,482,483,
                484,485,486,487,491,492,493,494,495,496,498,499,800,801,802,803,804,805,806,807,808,
                809,811,812,813,814,815,816,817,818,820,821,831,833,834,835,836,841,842,843,844,845,
                846,847,848,851,855,861,862,863,865,866,867,871,872,873,877,878,879,900,901,902,903,
                904,905,906,908,909,910,911,912,913,914,915,916,917,918,919,920,921,922,923,924,925,
                926,927,928,929,930,931,932,933,934,936,937,938,939,941,950,951,952,953,955,956,958,
                960,961,962,963,964,965,966,967,968,970,971,980,981,982,983,984,985,987,988,989,992,
                993,994,995,996,997,999
            };
        }

        public bool Passed()
        {
            try
            {
                var phone = _checkingValue.Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "");
                phone = phone.StartsWith("+7") ? phone.Substring(2) : phone;
                var code = int.Parse(phone.Substring(0,3));
                if (_phoneCodes.Contains(code))
                {
                    return true;
                }
                SetViolationMessage();
                return false;
            }
            catch
            {
                SetViolationMessage();
                return false;
            }
        }

        private void SetViolationMessage()
        {
            ViolationMessage = string.Format("Код телефона {0} некорректен", _checkingValue);
        }
    }
}
