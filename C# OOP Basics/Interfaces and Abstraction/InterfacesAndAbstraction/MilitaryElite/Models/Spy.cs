using MilitaryEliteV1_2.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEliteV1_2.Models
{
    public class Spy : Soldier, ISpy
    {
        private int codeNumber;
        public Spy(int id, string firstName, string lastName, int codeNUmber) : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNUmber;
        }

        public int CodeNumber { get => codeNumber; private set => codeNumber = value; }

        public override string ToString()
        {
            return base.ToString()+$"\nCode Number: {this.CodeNumber}";
        }
    }
}
