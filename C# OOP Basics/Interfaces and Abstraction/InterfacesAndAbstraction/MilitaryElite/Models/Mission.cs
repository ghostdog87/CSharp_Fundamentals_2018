using MilitaryEliteV1_2.Contracts;
using MilitaryEliteV1_2.EnumM;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEliteV1_2.Models
{
    public class Mission : IMission
    {
        private string codeName;
        private State state;

        public Mission(string codeName, State state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get => codeName; private set => codeName = value; }
        public State State { get => state; private set => state = value; }

        public void CompleteMission()
        {
            this.State = State.Finished;
        }
        public override string ToString()
        {
            return $" Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
