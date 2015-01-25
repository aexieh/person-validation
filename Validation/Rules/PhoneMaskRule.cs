using System.Linq;

namespace Validation.Rules
{
    public class PhoneMaskRule : IRule
    {
        private readonly string _checkingValue;

        public int ViolationCode { get { return 23; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public PhoneMaskRule(string value)
        {
            _checkingValue = value != null ? value.Trim() : string.Empty;
        }

        public bool Passed()
        {
            var phone = _checkingValue.Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "");
            phone = phone.StartsWith("+7") ? phone.Substring(2) : phone;
            if (phone.Length == 10 && phone.All(char.IsDigit))
            {
                return true;
            }
            ViolationMessage = string.Format("Номер телефона с кодом {0} должен состоять из 10 цифр", _checkingValue);
            return false;
        }
    }
}
