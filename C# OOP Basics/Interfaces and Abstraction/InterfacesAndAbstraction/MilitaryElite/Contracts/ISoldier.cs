using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEliteV1_2.Contracts
{
    public interface ISoldier
    {
  
        int Id { get; }
        string  FirstName { get; }
        string LastName { get; }

    }
}
