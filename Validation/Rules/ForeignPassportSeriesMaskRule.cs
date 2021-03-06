﻿using System.Linq;

namespace Validation.Rules
{
    public class ForeignPassportSeriesMaskRule : IRule
    {
        private readonly string _checkingValue;

        public int ViolationCode { get { return 8; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public ForeignPassportSeriesMaskRule(string value)
        {
            _checkingValue = value != null ? value.Trim() : string.Empty;
        }

        public bool Passed()
        {
            if (_checkingValue.Length == 2 && _checkingValue.All(char.IsDigit))
            {
                return true;
            }
            ViolationMessage = string.Format("Серия загранпаспорта {0} должна состоять из двух цифр", _checkingValue);
            return false;
        }
    }
}
