using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Contracts
{
    public interface IPerson
    {
        //name, an age and a method GetName()
        string Name { get; }
        int Age { get; }

        string GetName();
    }
}
