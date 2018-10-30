using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise13
{
    class TriFunction
    {
        static void Main(string[] args)
        {
            int charSum = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            for (int x = 0; x < names.Count; x++)
            {
                int sum = 0;
                for (int y = 0; y < names[x].Length; y++)
                {
                    sum += names[x][y];
                }

                if (sum >= charSum)
                {
                    Console.WriteLine(names[x]);
                    break;
                }
            }
        }
    }
}
