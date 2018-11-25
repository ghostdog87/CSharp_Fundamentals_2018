using MilitaryEliteV1_2.Contracts;
using MilitaryEliteV1_2.EnumM;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEliteV1_2.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<IRepair>();
        }

        public ICollection<IRepair> Repairs { get; set; }

        public override string ToString()
        {
            if (this.Repairs.Count==0)
            {
                return "Repairs:";
            }
            return base.ToString()+ $"\nCorps: {this.Corps}\nRepairs:{(this.Repairs.Count == 0? "":"\n")}{string.Join("\n", this.Repairs)}";
        }
    }
}
