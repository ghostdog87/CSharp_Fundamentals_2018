using MilitaryEliteV1_2.Contracts;
using MilitaryEliteV1_2.EnumM;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEliteV1_2.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps {get; set;}
    }
}
