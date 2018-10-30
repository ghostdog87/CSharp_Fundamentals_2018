using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];
                decimal fuelAmount = decimal.Parse(input[1]);
                decimal fuelConsumptionFor1km = decimal.Parse(input[2]);
                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);
                cars.Add(car);
            }

            string input2 = Console.ReadLine();

            while (input2 != "End")
            {
                string[] currentInput = input2.Split();

                string model = currentInput[1];
                int amountOfKm = int.Parse(currentInput[2]);

                Car currentCar = cars.Find(x => x.Model == model);

                if (!currentCar.IsEnoughFuel(amountOfKm))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }

                input2 = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.DistanceTraveled}");
            }
        }
    }
}
