using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal workingHours;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal workingHours) : base(firstName, lastName)
        {
            WeekSalary = weekSalary;
            WorkingHours = workingHours;
        }

        public decimal WorkingHours
        {
            get { return workingHours; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new Exception($"Expected value mismatch! Argument: workHoursPerDay");
                }
                workingHours = value;
            }
        }

        public decimal WeekSalary
        {
            get { return weekSalary; }
            set
            {
                if (value <= 10)
                {
                    throw new Exception($"Expected value mismatch! Argument: weekSalary");
                }
                weekSalary = value;
            }
        }

        public decimal SalaryPerHour()
        {
            return this.weekSalary / (this.WorkingHours * 5);
        }
    }
}
