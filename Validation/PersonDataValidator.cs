using System.Collections.Generic;
using System.Linq;
using Validation.Models;
using Validation.Rules;

namespace Validation
{
    public class PersonDataValidator
    {
        private readonly IList<IRule> _rules = new List<IRule>();

        public PersonDataValidator(PersonData personData)
        {
            _rules.Add(new NameAllowedСharactersRule(personData.FirstName, "имени"));
            _rules.Add(new NameLengthRule(personData.FirstName, "имени"));
            _rules.Add(new NameRepeatedCharactersRule(personData.FirstName, "имени"));
            _rules.Add(new NameAllowedСharactersRule(personData.MiddleName, "отчества"));
            _rules.Add(new NameLengthRule(personData.MiddleName, "отчества"));
            _rules.Add(new NameRepeatedCharactersRule(personData.MiddleName, "отчества"));
            _rules.Add(new NameAllowedСharactersRule(personData.LastName, "фамилии"));
            _rules.Add(new NameLengthRule(personData.LastName, "фамилии"));
            _rules.Add(new NameRepeatedCharactersRule(personData.LastName, "фамилии"));
            _rules.Add(new NameAllowedСharactersRule(personData.PreviousFirstName, "прежнего имени"));
            _rules.Add(new NameLengthRule(personData.PreviousFirstName, "прежнего имени"));
            _rules.Add(new NameRepeatedCharactersRule(personData.PreviousFirstName, "прежнего имени"));
            _rules.Add(new NameAllowedСharactersRule(personData.PreviousMiddleName, "прежнего отчества"));
            _rules.Add(new NameLengthRule(personData.PreviousMiddleName, "прежнего отчества"));
            _rules.Add(new NameRepeatedCharactersRule(personData.PreviousMiddleName, "прежнего отчества"));
            _rules.Add(new NameAllowedСharactersRule(personData.PreviousLastName, "прежней фамилии"));
            _rules.Add(new NameLengthRule(personData.PreviousLastName, "прежней фамилии"));
            _rules.Add(new NameRepeatedCharactersRule(personData.PreviousLastName, "прежней фамилии"));
            _rules.Add(new DateMaskRule(personData.BornOn, "рождения"));
            _rules.Add(new BirthDateRangeRule(personData.BornOn));
            foreach (var passport in personData.Passports)
            {
                _rules.Add(new PassportSeriesMaskRule(passport.Series));
                _rules.Add(new PassportSeriesOkatoRule(passport.Series));
                _rules.Add(new PassportSeriesYearRule(passport.Series));
                _rules.Add(new PassportNumberMaskRule(passport.Number));
                _rules.Add(new PassportNumberRangeRule(passport.Number));
                _rules.Add(new DateMaskRule(passport.IssuedOn, "выдачи паспорта"));
                _rules.Add(new PassportDateRangeRule(passport.IssuedOn));
                _rules.Add(new PassportIssueAuthorityMaskRule(passport.IssueAuthority));
            }
            _rules.Add(new InnMaskRule(personData.Inn));
            _rules.Add(new InnChecksumRule(personData.Inn));
            _rules.Add(new SnilsMaskRule(personData.Snils));
            _rules.Add(new SnilsChecksumRule(personData.Snils));
            foreach (var phone in personData.Phones)
            {
                _rules.Add(new PhoneMaskRule(phone));
                _rules.Add(new PhoneCodeRule(phone));
            }
            foreach (var email in personData.Emails)
            {
                _rules.Add(new EmailMaskRule(email));
            }
            foreach (var passport in personData.ForeignPassports)
            {
                _rules.Add(new ForeignPassportSeriesMaskRule(passport.Series));
                _rules.Add(new ForeignPassportSeriesValueRule(passport.Series));
                _rules.Add(new ForeignPassportNumberMaskRule(passport.Number));
                _rules.Add(new DateMaskRule(passport.IssuedOn, "выдачи загранпаспорта"));
                _rules.Add(new ForeignPassportDateRangeRule(passport.IssuedOn));
            }
            foreach (var license in personData.DriverLicenses)
            {
                _rules.Add(new DriverLicenseSeriesMaskRule(license.Series));
                _rules.Add(new DriverLicenseNumberMaskRule(license.Number));
                _rules.Add(new DateMaskRule(license.IssuedOn, "выдачи водительского удостоверения"));
                _rules.Add(new DriverLicenseDateRangeRule(license.IssuedOn));
            }
        }

        public IEnumerable<Violation> Validate()
        {
            return (from rule in _rules
                    where !string.IsNullOrEmpty(rule.CheckingValue) && !rule.Passed()
                    select new Violation(rule.ViolationCode, rule.ViolationMessage, rule.CheckingValue));
        }
    }
}
