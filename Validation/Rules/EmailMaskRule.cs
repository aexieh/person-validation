using System.Linq;
using System.Text.RegularExpressions;

namespace Validation.Rules
{
    public class EmailMaskRule : IRule
    {
        private const string EmailMask = @"^((?>[a-zA-Z\d!#$%&'*+\-/=?^_`{|}~]+\x20*|""((?=[\x01-\x7f])[^""\\]|\\[\x01-\x7f])*""\x20*)*(?<angle><))?((?!\.)(?>\.?[a-zA-Z\d!#$%&'*+\-/=?^_`{|}~]+)+|""((?=[\x01-\x7f])[^""\\]|\\[\x01-\x7f])*"")@(((?!-)[a-zA-Z\d\-]+(?<!-)\.)+[a-zA-Z]{2,}|\[(((?(?<!\[)\.)(25[0-5]|2[0-4]\d|[01]?\d?\d)){4}|[a-zA-Z\d\-]*[a-zA-Z\d]:((?=[\x01-\x7f])[^\\\[\]]|\\[\x01-\x7f])+)\])(?(angle)>)$";
        private readonly string _checkingValue;

        public int ViolationCode { get { return 5; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public EmailMaskRule(string value)
        {
            _checkingValue = value != null ? value.Trim() : string.Empty;
        }

        public bool Passed()
        {
            try
            {
                if (!_checkingValue.Contains("@") || !_checkingValue.Contains("."))
                {
                    ViolationMessage = string.Format("Адрес электронной почты {0} введен некорректно, отсутствуют знаки @ и .", _checkingValue);
                    return false;
                }
                var name = _checkingValue.Substring(0, _checkingValue.IndexOf('@')).ToLower();
                if (name.Length == 0 || name.Length > 30 
                    || !name.All(c => (c >= 'a' && c <= 'z') || char.IsDigit(c) || c == '_' || c == '-' || c == '.'))
                {
                    ViolationMessage = string.Format("В адресе электронной почты {0} некорректно указано имя (должно содержать от 1 до 30 символов, могут быть использованы только латинские буквы, цифры, знак подчеркивания, дефис и точка)", _checkingValue);
                    return false;
                }
                var afterAt = _checkingValue.Substring(_checkingValue.IndexOf('@') + 1);
                var domain = afterAt.Substring(0, _checkingValue.IndexOf('.')).ToLower();
                if (domain.Length == 0 || domain.Length > 20 
                    || !domain.All(c => (c >= 'a' && c <= 'z') || char.IsDigit(c) || c == '_' || c == '-' || c == '.')
                    || domain.StartsWith("_") || domain.StartsWith("-") || domain.StartsWith(".")
                    || domain.EndsWith("_") || domain.EndsWith("-") || domain.EndsWith("."))
                {
                    ViolationMessage = string.Format("В адресе электронной почты {0} некорректно указано имя домена (значение после @ должно содержать 1-20 знаков, только латинские буквы, цифры, знаки подчеркивания, дефис, точка. Должен начинаться и заканчиваться буквой или цифрой", _checkingValue);
                    return false;
                }
                var zone = _checkingValue.Substring(_checkingValue.LastIndexOf('.') + 1).ToLower();
                if (zone.Length < 2 || zone.Length > 4 || !name.All(c => (c >= 'a' && c <= 'z')))
                {
                    ViolationMessage = string.Format("В адресе электронной почты {0} некорректно указана доменная зона. Допустимо значение из 2-4 символов, только латинские буквы", _checkingValue);
                    return false;
                }
                return Regex.IsMatch(_checkingValue, EmailMask);
            }
            catch
            {
                ViolationMessage = string.Format("Адрес электронной почты {0} введен некорректно", _checkingValue);
                return false;
            }
            
        }
    }
}
