using System;

namespace Validation.Rules
{
    public class PassportSeriesYearRule : IRule
    {
        private readonly string _checkingValue;

        public int ViolationCode { get { return 19; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public PassportSeriesYearRule(string value)
        {
            _checkingValue = value != null ? value.Trim() : string.Empty;
        }

        public bool Passed()
        {
            int seriesYear;
            if (_checkingValue.Length >= 4 && int.TryParse(_checkingValue.Substring(2, 2).TrimStart(new[] {'0'}), out seriesYear))
            {
                int currentYear;
                if (int.TryParse(DateTime.Now.ToString("yy").TrimStart(new[] {'0'}), out currentYear))
                {
                    if (!(seriesYear > currentYear + 5 && seriesYear < 97))
                    {
                        return true;
                    }
                }
            }
            ViolationMessage = string.Format("Значение серии паспорта {0} некорректно, проверьте наличие ошибок", _checkingValue);
            return false;
        }
    }
}
