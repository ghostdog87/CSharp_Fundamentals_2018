using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise3
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < N; i++)
            {
                string[] currentElements = Console.ReadLine().Split().ToArray();
                for (int j = 0; j < currentElements.Length; j++)
                {
                    elements.Add(currentElements[j]);
                }
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
