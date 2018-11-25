using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEliteV1_2.Contracts
{
    public interface IPrivate : ISoldier
    {
        decimal Salary { get; }

    }
}
