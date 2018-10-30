using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional_Programming
{
    class ActionPoint
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in names)
            {
                Print(item);
            }
        }

        static Action<string> Print = name => Console.WriteLine($"Sir {name}");
    }
}
