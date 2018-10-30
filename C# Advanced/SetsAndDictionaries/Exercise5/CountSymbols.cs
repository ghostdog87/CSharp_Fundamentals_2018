using System;
using System.Collections.Generic;

namespace Exercise5
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> numbers = new SortedDictionary<char, int>();


            for (int i = 0; i < input.Length; i++)
            {
                if (!numbers.ContainsKey(input[i]))
                {
                    numbers.Add(input[i], 1);
                }
                else
                {
                    numbers[input[i]]++;
                }
            }

            foreach (var item in numbers)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
