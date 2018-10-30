using System;
using System.Linq;

namespace Exercise3
{
    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            Func<int[], int> MinNumber = num => num.Min();

            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine(MinNumber(numbers));
        }

        
    }
}
