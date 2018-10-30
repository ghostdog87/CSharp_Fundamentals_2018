using System;

namespace ClassBox
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(length, width, height);
                Console.WriteLine("Surface Area - {0:f2}", box.CalcSurfaceArea());
                Console.WriteLine("Lateral Surface Area - {0:f2}", box.CalcLateralSurfaceArea());
                Console.WriteLine("Volume - {0:f2}", box.CalcVolume());
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

    }
}
