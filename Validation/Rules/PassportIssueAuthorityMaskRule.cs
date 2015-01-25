using System.Linq;

namespace Validation.Rules
{
    public class PassportIssueAuthorityMaskRule : IRule
    {
        private readonly string _checkingValue;

        public int ViolationCode { get { return 15; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public PassportIssueAuthorityMaskRule(string value)
        {
            _checkingValue = value != null ? value.Trim() : string.Empty;
        }

        public bool Passed()
        {
            var code = _checkingValue;
            if (code.Contains('-'))
            {
                code = code.Remove(code.IndexOf('-'), 1);
            }
            if (code.Length == 6 && code.All(char.IsDigit))
            {
                return true;
            }
            ViolationMessage = string.Format("Код подразделения {0} должен быть указан в формате xxxxxx или xxx-xxx", _checkingValue);
            return false;
        }
    }
}
