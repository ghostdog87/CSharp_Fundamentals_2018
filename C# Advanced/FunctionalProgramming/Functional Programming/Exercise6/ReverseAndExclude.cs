using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise6
{
    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            Action<List<int>> reverseNums = nums => nums.Reverse();
            Func<List<int>,int, List<int>> deleteItem = (nums,command) => nums.Where(x => x % command != 0).ToList();

            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int commands = int.Parse(Console.ReadLine());

            reverseNums(numbers);
            numbers = deleteItem(numbers, commands);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
