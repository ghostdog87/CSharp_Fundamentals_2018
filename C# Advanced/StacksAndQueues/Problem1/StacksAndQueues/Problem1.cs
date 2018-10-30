using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise1
{
    class Problem1
    {
        static void Main(string[] args)
        {
            int[] num = Console.ReadLine().Split(" ").Select(s => int.Parse(s)).ToArray();
            var reverNums = new Stack<int>(num);
            for (int i = 0; i < num.Length; i++)
            {
                Console.Write(reverNums.Pop());
                if (i != num.Length)
                {
                    Console.Write(" ");
                }
            }
        }
    }
}
