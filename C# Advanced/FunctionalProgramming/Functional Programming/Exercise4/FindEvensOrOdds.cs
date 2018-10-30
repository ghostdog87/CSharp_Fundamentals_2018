using System;
using System.Linq;

namespace Exercise4
{
    class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            Predicate<int> OddOrEven = x => x % 2 == 0;

            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            int minNum = input[0];
            int maxNum = input[1];

            for (int i = minNum; i <= maxNum; i++)
            {
                if (command == "even" && OddOrEven(i))
                {
                    Console.Write(i + " ");
                }
                else if (command == "odd" && !OddOrEven(i))
                {
                    Console.Write(i + " ");
                }
            }           
        }
    }
}
