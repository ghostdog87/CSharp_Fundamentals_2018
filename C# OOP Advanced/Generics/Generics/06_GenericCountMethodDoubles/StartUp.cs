using System;

namespace _06_GenericCountMethodDoubles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<double> boxes = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                double item = double.Parse(Console.ReadLine());

                boxes.AddBox(item);
            }

            double element = double.Parse(Console.ReadLine());
            int result = boxes.GetBiggerThan(element);

            Console.WriteLine(result);
        }
    }
}
