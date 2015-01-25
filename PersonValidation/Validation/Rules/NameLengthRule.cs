namespace Validation.Rules
{
    public class NameLengthRule : IRule
    {
        private readonly string _checkingValue;
        private readonly string _subject;

        public int ViolationCode { get { return 13; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public NameLengthRule(string value, string subject = "")
        {
            _checkingValue = value != null ? value.Trim() : string.Empty;
            _subject = subject;
        }

        public bool Passed()
        {
            if (_checkingValue.Length >= 2 && _checkingValue.Length <= 100)
            {
                return true;
            }
            ViolationMessage = string.Format("В значении {0} {1} указано меньше 2 или больше 100 символов", _subject, _checkingValue);
            return false;
        }
    }
}
