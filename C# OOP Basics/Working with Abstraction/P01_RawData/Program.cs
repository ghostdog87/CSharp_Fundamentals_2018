using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];

                
                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);
                Engine engine = new Engine(engineSpeed,enginePower);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];
                Cargo cargo = new Cargo(cargoWeight,cargoType);


                List<Tire> tires = new List<Tire>();

                for (int j = 0; j < 8; j+=2)
                {
                    double currentTirePressure = double.Parse(parameters[5 + j]);
                    int currentTireAge = int.Parse(parameters[6 + j]);
                    tires.Add(new Tire(currentTirePressure, currentTireAge));
                }

                Car car = new Car(model,engine,cargo,tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            List<string> result = new List<string>();

            if (command == "fragile")
            {
                result = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();
            }
            else
            {
                result = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();                
            }
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
