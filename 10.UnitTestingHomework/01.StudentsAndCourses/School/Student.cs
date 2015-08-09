namespace School
{
    using System;

    public class Student
    {
        private string firstName;
        private string lastName;
        private int number;

        public Student(string firstName, string lastName, int number)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Number = number;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("First name must not be an empty string");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Last name must not be an empty string");
                }

                this.lastName = value;
            }
        }

        public int Number
        {
            get
            {
                return this.number;
            }

            set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("Student number must be between 10 000 and 99 999");
                }

                this.number = value;
            }
        }
    }
}
