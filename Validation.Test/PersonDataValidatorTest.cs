using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Models;

namespace Validation.Test
{
    [TestClass]
    public class PersonDataValidatorTest
    {
        [TestMethod]
        public void WrongValues_ShouldReturnViolations()
        {
            var personData = new PersonData
            {
                FirstName = "384ht43u",
                MiddleName = "asdщлт",
                LastName = "-йцуйцу-",
                PreviousFirstName = "ццццццццц",
                PreviousMiddleName = "цв---цвцв",
                PreviousLastName = "Йцукен 9",
                BornOn = DateTime.Now.ToString("dd.MM.yyyy"),
                Inn = " 123ab c",
                Snils = "123-123-123-123-123-",
                Phones = new[] { "+7(111) 12 - 21- 23234", "0101010101"},
                Emails = new[] { "afaf@Wdqwdqwd", "a@b.com"},
                Passports = new[] { new PersonDocument { Series = "123", Number = "345", IssueAuthority = "sdsd", IssuedOn = DateTime.Now.AddYears(-100).ToString("dd.MM.yyyy") } },
                ForeignPassports = new[] { new PersonDocument { Series = "123", Number = "345", IssueAuthority = "sdsd", IssuedOn = DateTime.Now.AddYears(-100).ToString("dd.MM.yyyy") } },
                DriverLicenses = new[] {new PersonDocument { Series = "123", Number = "345", IssueAuthority = "sdsd", IssuedOn = "12.123.123"}}
            };

            var target = new PersonDataValidator(personData);
            var result = target.Validate().ToList();
            Assert.IsTrue(result.Any());
            Assert.IsFalse(result.First().Code == 0);
            Assert.IsFalse(string.IsNullOrEmpty(result.First().Message));
            Assert.IsFalse(string.IsNullOrEmpty(result.First().Value));
        }
    }
}
