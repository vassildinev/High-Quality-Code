namespace Methods
{
    using System;
    using System.Text.RegularExpressions;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AdditionalInformation { get; set; }

        public bool IsOlderThan(Student other)
        {
            var regex = new Regex(@"\b\d{2}\.\d{2}.\d{4}\b");
            DateTime thisDate = DateTime.Parse(regex.Match(this.AdditionalInformation).ToString());
            DateTime otherDate = DateTime.Parse(regex.Match(other.AdditionalInformation).ToString());

            TimeSpan thisAge = DateTime.Now - thisDate;
            TimeSpan otherAge = DateTime.Now - otherDate;

            return thisAge > otherAge;
        }
    }
}
