using System.Linq;

namespace Validation.Rules
{
    public class DriverLicenseSeriesMaskRule : IRule
    {
        private readonly string _checkingValue;

        public int ViolationCode { get { return 4; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public DriverLicenseSeriesMaskRule(string value)
        {
            _checkingValue = value != null ? value.Trim() : string.Empty;
        }

        public bool Passed()
        {
            var series = _checkingValue.ToLower();
            if (series.Length == 4 &&
                (series.All(char.IsDigit) ||
                 (char.IsDigit(series[0]) && char.IsDigit(series[1]) &&
                  series.Substring(2, 2).All(c => (c >= 'а' && c <= 'я')))))
            {
                return true;
            }
            ViolationMessage = string.Format("Серия водительского удостоверения {0} должна состоять из 4 цифр или 2 цифр и 2 кириллических букв", _checkingValue);
            return false;
        }
    }
}
