using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> boxes = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                string item = Console.ReadLine();

                boxes.AddBox(item);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            boxes.Swap(indexes[0], indexes[1]);

            Console.WriteLine(boxes);
        }
    }
}
