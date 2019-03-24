using System;
using System.Linq;

namespace GenericCountMethodStrings
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

            string element = Console.ReadLine();
            int result = boxes.GetBiggerThan(element);

            Console.WriteLine(result);
        }
    }
}
