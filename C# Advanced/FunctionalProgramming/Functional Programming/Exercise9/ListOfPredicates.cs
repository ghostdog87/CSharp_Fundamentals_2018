using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise9
{
    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            Func<int, int[], bool> divideNums = (x, y) =>
            {
                foreach (var item in y)
                {
                    if (x % item != 0)
                    {
                        return false;
                    }
                }
                return true;
            };

            int N = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            List<int> result = new List<int>();

            for (int i = 1; i <= N; i++)
            {
                if (divideNums(i, dividers))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
