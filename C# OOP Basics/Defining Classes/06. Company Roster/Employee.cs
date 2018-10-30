using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyRoster
{
    public class Employee
    {
        //name, salary, position, department, email and age

        private string name;
        private decimal salary;
        private string positon;
        private string department;
        private string email;
        private int age;

        public Employee(string name, decimal salary, string position, string department)
        {
            this.Age = -1;
            this.Email = "n/a";
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
     
        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        
        public string Position
        {
            get { return positon; }
            set { positon = value; }
        }
        
        public string Department
        {
            get { return department; }
            set { department = value; }
        }



    }
}
