using System;
using System.Globalization;

namespace Validation.Rules
{
    public class DateMaskRule : IRule
    {
        private readonly string _checkingValue;
        private readonly string _subject;

        public int ViolationCode { get { return 25; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public DateMaskRule(string value, string subject = "")
        {
            _checkingValue = value != null ? value.Trim() : string.Empty;
            _subject = subject;
        }

        public bool Passed()
        {
            DateTime date;
            if (DateTime.TryParseExact(_checkingValue, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                return true;
            }
            ViolationMessage = string.Format("Дата {0} {1} не соответствует формату даты", _subject, _checkingValue);
            return false;
        }
    }
}
