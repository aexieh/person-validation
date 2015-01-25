using System.Linq;

namespace Validation.Rules
{
    public class PassportSeriesMaskRule : IRule
    {
        private readonly string _checkingValue;

        public int ViolationCode { get { return 20; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public PassportSeriesMaskRule(string value)
        {
            _checkingValue = value != null ? value.Trim() : string.Empty;
        }

        public bool Passed()
        {
            if (_checkingValue.Length == 4 && _checkingValue.All(char.IsDigit))
            {
                return true;
            }
            ViolationMessage = string.Format("Значение серии паспорта {0} должна состоять из 4 цифр", _checkingValue);
            return false;
        }
    }
}
