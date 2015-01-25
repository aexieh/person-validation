using System.Linq;

namespace Validation.Rules
{
    public class PassportNumberMaskRule : IRule
    {
        private readonly string _checkingValue;

        public int ViolationCode { get { return 17; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public PassportNumberMaskRule(string value)
        {
            _checkingValue = value != null ? value.Trim() : string.Empty;
        }

        public bool Passed()
        {
            if (_checkingValue.Length == 6 && _checkingValue.All(char.IsDigit))
            {
                return true;
            }
            ViolationMessage = string.Format("Номер паспорта {0} должен состоять из 6 цифр", _checkingValue);
            return false;
        }
    }
}
