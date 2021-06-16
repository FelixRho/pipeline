using System;

namespace RhF.Model.PersonLib
{
    public class Person
    {
        private string firstName;
        private string lastName;

        public Person() { }

        public Person(string firstname, string lastname)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
        }

        public string FirstName
        {
            get => this.firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception($"{nameof(Person)}:{nameof(FirstName)}");

                this.firstName = value;
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception($"{nameof(Person)}:{nameof(LastName)}");

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}