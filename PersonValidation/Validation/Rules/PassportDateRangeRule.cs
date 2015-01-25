using System;
using System.Globalization;

namespace Validation.Rules
{
    public class PassportDateRangeRule : IRule
    {
        private readonly string _checkingValue;

        public int ViolationCode { get { return 16; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public PassportDateRangeRule(string value)
        {
            _checkingValue = value != null ? value.Trim() : string.Empty;
        }

        public bool Passed()
        {
            var currentDate = DateTime.Now;
            DateTime date;
            if (DateTime.TryParseExact(_checkingValue, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                if (date > currentDate)
                {
                    ViolationMessage = string.Format("Дата выдачи паспорта {0} должна быть меньше текущей даты", _checkingValue);
                    return false;
                }
                if (date < new DateTime(1997, 1, 1))
                {
                    ViolationMessage = string.Format("Год даты выдачи паспорта {0} должен быть больше или равен 1997 ", _checkingValue);
                    return false;
                }
                return true;                    
            }
            ViolationMessage = string.Format("Дата выдачи паспорта {0} не соответствует формату даты", _checkingValue);
            return false;
        }
    }
}
