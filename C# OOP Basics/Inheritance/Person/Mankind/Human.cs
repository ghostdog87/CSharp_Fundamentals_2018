using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Mankind
{
    public abstract class Human
    {
        private string firstName;
        private string lastName;

        protected Human(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new Exception($"Expected upper case letter! Argument: firstName");
                }
                else if (value.Length < 3)
                {
                    throw new Exception($"Expected length at least 3 symbols! Argument: lastName"); // possible mistake in whitespace at the end
                }
                lastName = value;
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new Exception($"Expected upper case letter! Argument: firstName");
                }
                else if (value.Length < 4)
                {
                    throw new Exception($"Expected length at least 4 symbols! Argument: firstName");
                }
                firstName = value;
            }
        }

    }
}
