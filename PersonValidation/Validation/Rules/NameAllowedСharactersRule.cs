using System.Linq;

namespace Validation.Rules
{
    public class NameAllowedСharactersRule : IRule
    {
        private readonly string _checkingValue;
        private readonly string _subject;

        public int ViolationCode { get { return 12; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public NameAllowedСharactersRule(string value, string subject = "")
        {
            _checkingValue = value != null ? value.Trim() : string.Empty;
            _subject = subject;
        }

        public bool Passed()
        {
            var name = _checkingValue.ToLower();
            if (name.First() == '-' || name.Last() == '-')
            {
                ViolationMessage = string.Format("Значение {0} {1} начинается или заканчивается знаком '-'", _subject, _checkingValue);
                return false;
            }
            if (name.Any(c => (c >= 'a' && c <= 'z')) && name.Any(c => (c >= 'а' && c <= 'я')))
            {
                ViolationMessage = string.Format("В значении {0} {1} использованы латинские и кириллические буквы", _subject, _checkingValue);
                return false;
            }
            if (name.All(c => (c >= 'a' && c <= 'z') || c == '-' || c == ' '))
            {
                return true;
            }
            if (name.All(c => (c >= 'а' && c <= 'я') || c == '-' || c == ' '))
            {
                return true;
            }
            ViolationMessage = string.Format("В значении {0} {1} использованы недопустимые спец. символы", _subject, _checkingValue);
            return false;
        }
    }
}
