using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise7
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
          
            int nameLength = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Func<List<string>,int, List<string>> getNames = (x,len) => x.Where(y => y.Length <= len).ToList();

            names = getNames(names, nameLength);

            Console.WriteLine(string.Join("\n", names));
        }
    }
}
