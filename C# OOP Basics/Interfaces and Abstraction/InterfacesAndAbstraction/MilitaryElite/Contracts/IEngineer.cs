using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEliteV1_2.Contracts
{
    public interface IEngineer : ISpecialisedSoldier, ISoldier
    {
        ICollection<IRepair> Repairs { get; set; }
    }
}
