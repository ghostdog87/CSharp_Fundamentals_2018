using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise5
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> add = num => num.Select(x => x + 1).ToList();
            Func<List<int>, List<int>> multiply = num => num.Select(x => x * 2).ToList();
            Func<List<int>, List<int>> subtract = num => num.Select(x => x - 1).ToList();
            Action<List<int>> print = p => Console.WriteLine(string.Join(" ",p));

            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string commands = Console.ReadLine();

            while (commands != "end")
            {
                switch (commands)
                {
                    case "add":
                        numbers = add(numbers);
                        break;
                    case "multiply":
                        numbers = multiply(numbers);
                        break;
                    case "subtract":
                        numbers = subtract(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                    default:
                        break;
                }

                commands = Console.ReadLine();
            }
        }
    }
}
