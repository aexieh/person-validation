namespace Validation.Rules
{
    public class PassportNumberRangeRule : IRule
    {
        private readonly string _checkingValue;

        public int ViolationCode { get { return 18; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public PassportNumberRangeRule(string value)
        {
            _checkingValue = value != null ? value.Trim() : string.Empty;
        }

        public bool Passed()
        {
            int number;
            if (int.TryParse(_checkingValue.TrimStart(new[] {'0'}), out number) && number >= 101 && number <= 999999)
            {
                return true;
            }
            ViolationMessage = string.Format("Номер паспорта {0} не соответствует допустимому диапазону значений", _checkingValue);
            return false;
        }
    }
}
