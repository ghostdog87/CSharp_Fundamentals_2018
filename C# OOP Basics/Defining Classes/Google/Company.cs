using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Company
    {
        //<companyName> <department> <salary>
        public string CompanyName { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }

        public Company(string companyName, string department, decimal salary)
        {
            CompanyName = companyName;
            Department = department;
            Salary = salary;
        }
    }
}
