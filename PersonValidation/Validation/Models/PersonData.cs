using System.Collections.Generic;

namespace Validation.Models
{
    public class PersonData
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PreviousFirstName { get; set; }
        public string PreviousMiddleName { get; set; }
        public string PreviousLastName { get; set; }
        public string BornOn { get; set; }
        public string Inn { get; set; }
        public string Snils { get; set; }
        public IEnumerable<string> Phones { get; set; }
        public IEnumerable<string> Emails { get; set; }
        public IEnumerable<PersonDocument> Passports { get; set; }
        public IEnumerable<PersonDocument> ForeignPassports { get; set; }
        public IEnumerable<PersonDocument> DriverLicenses { get; set; }
    }
}
