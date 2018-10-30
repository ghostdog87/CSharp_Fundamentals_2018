using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem10
{
    class Problem10
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> indexes = new List<int>();

            int days = 0;
            while (true) {
                

                for (int i = 0; i < input.Count - 1; i++)
                {
                    if (input[i] < input[i + 1])
                    {
                        indexes.Add(i + 1);
                    }
                }
                if (indexes.Count == 0) {
                    break;
                }
                days++;

                int counter = 0;
                for (int i = 0; i < indexes.Count; i++)
                {
                    input.RemoveAt(indexes[i] - counter);
                    counter++;
                }
                indexes.Clear();
            }
            Console.WriteLine(days);

        }
    }
}
