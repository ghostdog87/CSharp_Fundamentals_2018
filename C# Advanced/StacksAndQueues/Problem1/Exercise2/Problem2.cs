using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise2
{
    class Problem2
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(" ").Select(s => int.Parse(s)).ToArray();
            int[] input2 = Console.ReadLine().Split(" ").Select(s => int.Parse(s)).ToArray();

            int N = input1[0];
            int pop = input1[1];
            int find = input1[2];
            var stack = new Stack<int>(N);
            for (int i = 0; i < N; i++)
            {
                stack.Push(input2[i]);
            }

            for (int i = 0; i < pop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(find))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0) {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(stack.Min());

            }
            
        }
    }
}
