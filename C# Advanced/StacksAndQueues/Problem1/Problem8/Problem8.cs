using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem8
{
    class Problem8
    {
        static void Main(string[] args)
        {
            Stack<long> fibonaci = new Stack<long>();
            int input = int.Parse(Console.ReadLine());

            fibonaci.Push(0);
            fibonaci.Push(1);

            for (int i = 0; i < input - 1; i++)
            {
                long firstNum = fibonaci.Pop();
                long secondNum = fibonaci.Peek();
                fibonaci.Push(firstNum);
                fibonaci.Push(firstNum + secondNum);
            }

            Console.WriteLine(fibonaci.Peek());
        }
    }
}
