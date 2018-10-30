using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Problem3
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < N; i++)
            {
                string query = Console.ReadLine();
                int operand = int.Parse(query.Split(" ")[0]);

                switch (operand)
                {
                    case 1:
                        stack.Push(int.Parse(query.Split(" ")[1]));
                        break;
                    case 2:
                        stack.Pop();
                        break;
                    case 3:
                        Console.WriteLine(stack.Max());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
