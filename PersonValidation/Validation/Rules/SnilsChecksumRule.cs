using System;

namespace Validation.Rules
{
    public class SnilsChecksumRule : IRule
    {
        private readonly string _checkingValue;

        public int ViolationCode { get { return 24; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public SnilsChecksumRule(string value)
        {
            _checkingValue = value != null ? value.Trim() : string.Empty;
        }

        public bool Passed()
        {
            try
            {
                var snils = _checkingValue.Replace("-", "").Replace(" ", "");
                var checksum = int.Parse(snils.Substring(9, 2));
                snils = snils.Substring(0, 9);
                if (int.Parse(snils.TrimStart('0')) < 1001998)
                {
                    return true;
                }
                var calculatedChecksum = CalculateChecksum(snils);
                if (checksum == calculatedChecksum)
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

        private static int CalculateChecksum(string snils)
        {
            var calculatedChecksum = 0;
            for (int i = 0, j = 9; i < 9; i++, j--)
            {
                calculatedChecksum += (int)Char.GetNumericValue(snils[i]) * j;
            }
            if (calculatedChecksum == 100 || calculatedChecksum == 101)
            {
                calculatedChecksum = 0;
            }
            else if (calculatedChecksum > 101)
            {
                calculatedChecksum = calculatedChecksum % 101;
            }
            return calculatedChecksum;
        }

        private void SetViolationMessage()
        {
            ViolationMessage = string.Format("Значение СНИЛС {0} некорректно. Не выполнена проверка по контрольной сумме", _checkingValue);            
        }
    }
}
