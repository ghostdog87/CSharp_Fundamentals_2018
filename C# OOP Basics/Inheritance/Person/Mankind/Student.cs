using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

       
        public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
        {
            FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return facultyNumber; }
            set
            {
                bool isValid = value.All(c => Char.IsLetterOrDigit(c));

                if (value.Length < 5 || value.Length > 10 || !isValid)
                {
                    throw new Exception("Invalid faculty number!");
                }
                facultyNumber = value;
            }
        }
    }
}
