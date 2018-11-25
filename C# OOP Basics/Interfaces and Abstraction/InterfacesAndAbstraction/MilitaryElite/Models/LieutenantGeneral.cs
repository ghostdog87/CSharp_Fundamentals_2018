using MilitaryEliteV1_2.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEliteV1_2.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private ICollection<IPrivate> privates;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public ICollection<IPrivate> Privates { get => privates; set => privates = value; }

        public override string ToString()
        {
            return base.ToString()+ $"\nPrivates:{(this.Privates.Count== 0? "":"\n")} {string.Join("\n  ", this.Privates)}";
        }

    }
}
