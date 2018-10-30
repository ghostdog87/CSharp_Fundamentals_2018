using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise2
{
    class SetsOfElements
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int N = input[0];
            int M = input[0];

            HashSet<string> set1 = new HashSet<string>();
            HashSet<string> set2 = new HashSet<string>();

            for (int i = 0; i < N; i++)
            {
                set1.Add(Console.ReadLine());
            }

            for (int i = 0; i < M; i++)
            {
                set2.Add(Console.ReadLine());
            }

            set1.IntersectWith(set2);

            Console.WriteLine(string.Join(" ", set1));
        }
    }
}
