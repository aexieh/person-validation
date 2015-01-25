namespace Validation.Models
{
    public struct Violation
    {
        private readonly int _code;
        private readonly string _message;
        private readonly string _value;

        public int Code { get { return _code; } }
        public string Message { get { return _message; }}
        public string Value { get { return _value; } }

        public Violation(int code, string message, string value)
        {
            _code = code;
            _message = message;
            _value = value;
        }
    }
}
