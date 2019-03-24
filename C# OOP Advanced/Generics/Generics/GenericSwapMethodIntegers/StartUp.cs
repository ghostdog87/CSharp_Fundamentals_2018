using System;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<int> boxes = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                int item = int.Parse(Console.ReadLine());

                boxes.AddBox(item);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            boxes.Swap(indexes[0], indexes[1]);

            Console.WriteLine(boxes);
        }
    }
}
