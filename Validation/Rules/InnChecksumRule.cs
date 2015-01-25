using System;
using System.Linq;

namespace Validation.Rules
{
    public class InnChecksumRule : IRule
    {
        private readonly string _checkingValue;

        public int ViolationCode { get { return 10; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public InnChecksumRule(string value)
        {
            _checkingValue = value != null ? value.Trim() : string.Empty;
        }

        public bool Passed()
        {
            try
            {
                var inn = _checkingValue.Select(c => (int)Char.GetNumericValue(c)).ToArray();
                var multipliersFirst = new[] { 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };
                var multipliersSecond = new[] { 3, 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };
                var sum = 0;
                for (var j = 0; j <= 9; j++) {
                    sum += (inn[j] * multipliersFirst[j]);
                }
                if (sum == 0)
                {
                    return false;
                }
                var resultFirst = (sum % 11) % 10;
                sum = 0;
                for (var i = 0; i <= 10; i++) {
                    sum += (inn[i] * multipliersSecond[i]);
                }
                var resultSecond = (sum % 11) % 10;
                if (resultFirst == inn[10] && resultSecond == inn[11])
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
            ViolationMessage = string.Format("Значение ИНН {0} некорректно. Не выполнена проверка контрольной суммы", _checkingValue);
        }
    }
}
