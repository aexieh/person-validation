namespace Validation.Rules
{
    public class NameRepeatedCharactersRule : IRule
    {
        private readonly string _checkingValue;
        private readonly string _subject;

        public int ViolationCode { get { return 14; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public NameRepeatedCharactersRule(string value, string subject = "")
        {
            _checkingValue = value != null ? value.Trim() : string.Empty;
            _subject = subject;
        }

        public bool Passed()
        {
            for (var i = 0; i < _checkingValue.Length - 1; i++)
            {
                var current = _checkingValue[i];
                var next = _checkingValue[i + 1];
                if ((current == '-' || current == ' ') && current == next)
                {
                    ViolationMessage = string.Format("В значении {0} {1} указаны подряд два или более пробела/дефиса", _subject, _checkingValue);
                    return false;
                }
                if (i < _checkingValue.Length - 2)
                {
                    var nextNext = _checkingValue[i + 2];
                    if (current == next && current == nextNext)
                    {
                        ViolationMessage = string.Format("В значении {0} {1} указаны три одинаковых символа подряд", _subject, _checkingValue);
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
