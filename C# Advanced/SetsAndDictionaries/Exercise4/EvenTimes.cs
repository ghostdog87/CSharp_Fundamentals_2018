using System;
using System.Collections.Generic;

namespace Exercise4
{
    class EvenTimes
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < N; i++)
            {
                int currentInput = int.Parse(Console.ReadLine());


                if (!numbers.ContainsKey(currentInput))
                {
                    numbers.Add(currentInput, 1);
                }
                else
                {
                    numbers[currentInput]++;
                }
            }

            foreach (var item in numbers)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
