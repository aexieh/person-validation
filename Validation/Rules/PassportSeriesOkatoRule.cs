﻿using System.Collections.Generic;

namespace Validation.Rules
{
    public class PassportSeriesOkatoRule : IRule
    {
        private readonly string _checkingValue;
        private readonly IDictionary<int, string> _okatos;

        public int ViolationCode { get { return 21; } }
        public string ViolationMessage { get; private set; }
        public string CheckingValue { get { return _checkingValue; } }

        public PassportSeriesOkatoRule(string value)
        {
            _checkingValue = value != null ? value.Trim() : string.Empty;
            _okatos = new Dictionary<int, string>
            {
                {79, "Республика Адыгея (Адыгея)"},
                {84, "Республика Алтай"},
                {80, "Республика Башкортостан"},
                {81, "Республика Бурятия"},	
                {82, "Республика Дагестан"},	
                {26, "Республика Ингушетия"},	
                {83, "Кабардино-Балкарская Республика"},	
                {85, "Республика Калмыкия"},
                {91, "Карачаево-Черкесская Республика"},
                {86, "Республика Карелия"},
                {87, "Республика Коми"},
                {88, "Республика Марий Эл"},
                {89, "Республика Мордовия"},
                {98, "Республика Саха (Якутия)"},
                {90, "Республика Северная Осетия-Алания"},
                {92, "Республика Татарстан (Татарстан)"},
                {93, "Республика Тыва"},	
                {94, "Удмуртская Республика"},
                {95, "Республика Хакасия"},
                {96, "Чеченская Республика"},
                {97, "Чувашская Республика"},
                {1, "Алтайский край"},
                {3, "Краснодарский край"},
                {4, "Красноярский край"},
                {5, "Приморский край"},
                {7, "Ставропольский край"},
                {8, "Хабаровский край"},
                {10, "Амурская"},
                {11, "Архангельская область"},
                {12, "Астраханская область"},
                {14, "Белгородская область"},
                {15, "Брянская область"},
                {17, "Владимирская область"},
                {19, "Вологодская область"},
                {20, "Воронежская область"},
                {24, "Ивановская область"},	
                {25, "Иркутская область"},	
                {27, "Калининградская область"},	
                {29, "Калужская область"},
                //{20, "Камчатская область"},
                {32, "Кемеровская область"},	
                {33, "Кировская область"},
                {34, "Костромская область"},
                {37, "Курганская область"},	
                {38, "Курская область"},	
                {41, "Ленинградская область"},
                {42, "Липецкая область"},
                {44, "Магаданская область"},	
                {46, "Московская область, комплекс \"Байконур\""},
                {47, "Мурманская область"},	
                {22, "Нижегородская область"},	
                {49, "Новгородская область"},	
                {50, "Новосибирская область"},	
                {52, "Омская область"},	
                {53, "Оренбургская область"},	
                {54, "Орловская область"},	
                {56, "Пензенская область"},	
                {57, "Пермская область"},	
                {58, "Псковская область"},	
                {60, "Ростовская область"},	
                {61, "Рязанская область"},	
                {36, "Самарская область"},	
                {63, "Саратовская область"},	
                {64, "Сахалинская область"},	
                {65, "Свердловская область"},	
                {66, "Смоленская область"},	
                {68, "Тамбовская область"},	
                {28, "Тверская область"},
                {69, "Томская область"},	
                {73, "Ульяновская область"},	
                {75, "Челябинская область"},	
                {76, "Читинская область"},	
                {78, "Ярославская область"},	
                {45, "город Москва"},	
                {40, "город Санкт-Петербург"},	
                {99, "Еврейская автономная область"},	
                {43, "Агинский Бурятский автономный округ"},	
                {48, "Коми-Пермяцкий автономный округ"},	
                {51, "Корякский автономный округ"},	
                {55, "Ненецкий автономный округ"},	
                {59, "Таймырский (Долгано-Ненецкии) автономный округ"},	
                {62, "Усть-Ордынский Бурятский автономный округ"},	
                {67, "Ханты-Мансийский автономный округ"},	
                {77, "Чукотский автономный округ"},	
                {72, "Эвенкийский автономный округ"},	
                {74, "Ямало-Ненецкий автономный округ"}
            };
        }

        public bool Passed()
        {

            int okato;
            if (_checkingValue.Length >= 4 
                && int.TryParse(_checkingValue.Substring(2, 2).TrimStart(new[] { '0' }), out okato) 
                && _okatos.ContainsKey(okato))
            {
                return true;
            }
            ViolationMessage = string.Format("Значение серии паспорта {0} некорректно, проверьте наличие ошибок", _checkingValue);
            return false;
        }
    }
}