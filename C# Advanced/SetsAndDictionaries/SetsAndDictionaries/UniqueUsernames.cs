using System;
using System.Collections.Generic;

namespace SetsAndDictionaries
{
    class UniqueUsernames
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < N; i++)
            {
                names.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join("\n",names));
        }
    }
}
