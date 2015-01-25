using System;
using System.Globalization;

namespace Validation.Rules
{
    public class DriverLicenseDateRangeRule : IRule
    {
        private readonly string _checkingValue;

        public int ViolationCode { get { return 2; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public DriverLicenseDateRangeRule(string value)
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
                    ViolationMessage = string.Format("Дата выдачи водительского удостоверения {0} не может быть больше текущей даты", _checkingValue);
                    return false;
                }
                if (date < currentDate.AddYears(-85))
                {
                    ViolationMessage = string.Format("Дата выдачи водительского удостоверения {0} не соответствует допустимому значению", _checkingValue);
                    return false;
                }
                return true;                    
            }
            ViolationMessage = string.Format("Дата выдачи водительского удостоверения {0} не соответствует формату даты", _checkingValue);
            return false;
        }
    }
}
