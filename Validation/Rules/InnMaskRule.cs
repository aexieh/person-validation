using System.Linq;

namespace Validation.Rules
{
    public class InnMaskRule : IRule
    {
        private readonly string _checkingValue;

        public int ViolationCode { get { return 11; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public InnMaskRule(string value)
        {
            _checkingValue = value != null ? value.Trim() : string.Empty;
        }

        public bool Passed()
        {
            if (_checkingValue.Length == 12 && _checkingValue.All(char.IsDigit))
            {
                return true;
            }
            ViolationMessage = string.Format("ИНН {0} должен содержать 12 цифр", _checkingValue);
            return false;
        }
    }
}
