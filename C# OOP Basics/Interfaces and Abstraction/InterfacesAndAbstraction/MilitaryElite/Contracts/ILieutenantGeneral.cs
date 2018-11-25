using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryEliteV1_2.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        ICollection<IPrivate> Privates { get; set; }
    }
}
