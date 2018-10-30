using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem4
{
    class Problem4
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(" ").Select(s => int.Parse(s)).ToArray();
            int[] input2 = Console.ReadLine().Split(" ").Select(s => int.Parse(s)).ToArray();

            int add = input1[0];
            int remove = input1[1];
            int find = input1[2];
            var queue = new Queue<int>(add);

            for (int i = 0; i < add; i++)
            {
                queue.Enqueue(input2[i]);
            }

            for (int i = 0; i < remove; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(find))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }

        }
    }
}
