using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEliteV1_2.Contracts
{
    public interface ICommando : ISoldier
    {
        ICollection<IMission> Missions { get; set; }

    }
}
