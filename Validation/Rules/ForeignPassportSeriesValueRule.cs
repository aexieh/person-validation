using System.Collections.Generic;

namespace Validation.Rules
{
    public class ForeignPassportSeriesValueRule : IRule
    {
        private readonly string _checkingValue;
        private readonly IDictionary<int, string> _alowedSeries;

        public int ViolationCode { get { return 9; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public ForeignPassportSeriesValueRule(string value)
        {
            _checkingValue = value != null ? value.Trim() : string.Empty;
            _alowedSeries = new Dictionary<int, string>
            {
                {10, "Дипломатический паспорт"},
                {20, "Служебный паспорт"},
                {21, ""},	
                {43, "Загранпаспорт СССР"},
                {44, "Загранпаспорт СССР"},
                {99, "Загранпаспорт СССР"},
                {50, "Заграничный паспорт с печатью, \"неламинированный\", выданный МИД РФ или российским консульством"},
                {51, "\"Ламинированный\" загранпаспорт, выдаваемый МИД РФ и российскими консульствами"},
                {53, "\"Биометрический\" паспорт, выдаваемый МИД РФ и консульствами на 10 лет"},
                {60, "Заграничный паспорт с печатью, \"неламинированный\", выданный ПВС МВД РФ"},
                {61, "\"Ламинированный\" загранпаспорт, выданный УФМС"},
                {62, "\"Ламинированный\" загранпаспорт, выданный УФМС"},
                {63, "\"Ламинированный\" загранпаспорт, выданный УФМС"},
                {64, "\"Ламинированный\" загранпаспорт, выданный УФМС"},
                {70, "\"Биометрический\" паспорт, выданный УФМС на 5 лет"},
                {71, "\"Биометрический\" паспорт, выданный УФМС на 10 лет"},
                {72, "\"Биометрический\" паспорт, выданный УФМС на 10 лет"},
                {73, "\"Биометрический\" паспорт, выданный УФМС на 10 лет"}
            };
        }

        public bool Passed()
        {
            int series;
            if (int.TryParse(_checkingValue.Trim().TrimStart(new[] {'0'}), out series) && _alowedSeries.ContainsKey(series))
            {
                return true;
            }
            ViolationMessage = string.Format("Серия загранпаспорта {0} содержит недопустимое значение", _checkingValue);
            return false;
        }
    }
}
