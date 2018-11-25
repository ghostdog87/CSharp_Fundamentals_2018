using MilitaryEliteV1_2.EnumM;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEliteV1_2.Contracts
{
    public interface IMission 
    {
        string CodeName { get; }
        State State { get; }

        void CompleteMission();
    }
}
