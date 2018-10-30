using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise8
{
    class CustomComparator
    {
        static void Main(string[] args)
        {
            Func<int, int, int> sortingNums = (x, y) =>
              {
                  if (x % 2 == 0 && y % 2 != 0)
                  {
                      return -1;
                  }
                  else if (x % 2 != 0 && y % 2 == 0)
                  {
                      return 1;
                  }
                  else
                  {
                      return x.CompareTo(y);
                  }
              };

            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Array.Sort(numbers, new Comparison<int>(sortingNums));

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
