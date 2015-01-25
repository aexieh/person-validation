using System.Linq;

namespace Validation.Rules
{
    public class SnilsMaskRule : IRule  
    {
        private readonly string _checkingValue;

        public int ViolationCode { get { return 25; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public SnilsMaskRule(string value)
        {
            _checkingValue = value != null ? value.Trim() : string.Empty;
        }

        public bool Passed()
        {
            var snils = _checkingValue.Replace("-", "").Replace(" ", "");
            if (snils.Length == 11 && snils.All(char.IsDigit))
            {
                return true;
            }
            ViolationMessage = string.Format("Значение СНИЛС {0} не соответствует формату данных", _checkingValue);
            return false;
        }
    }
}
