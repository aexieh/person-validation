using System;
using System.Globalization;

namespace Validation.Rules
{
    public class BirthDateRangeRule : IRule
    {
        private readonly string _checkingValue;

        public int ViolationCode { get { return 1; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public BirthDateRangeRule(string value)
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
                    ViolationMessage = string.Format("Значение даты рождения {0} больше текущей даты", _checkingValue);
                    return false;
                }
                if (date < currentDate.AddYears(-100))
                {
                    ViolationMessage = string.Format("Значение даты рождения {0} меньше текущей даты на 100 лет", _checkingValue);
                    return false;
                }
                return true;
            }
            ViolationMessage = string.Format("Дата рождения {0} не соответствует формату даты", _checkingValue);
            return false;
        }
    }
}
