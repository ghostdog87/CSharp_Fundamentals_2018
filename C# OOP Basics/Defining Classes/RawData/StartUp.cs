using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                //“<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType> <Tire1Pressure> 
                //<Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age> <Tire4Pressure> <Tire4Age>"

                string[] input = Console.ReadLine().Split();              

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Car car = new Car(model, engine, cargo);

                for (int j = 0; j < 8; j+=2)
                {
                    double tirePressure = double.Parse(input[5 + j]);
                    int tireAge = int.Parse(input[6 + j]);
                    Tire tire = new Tire(tireAge, tirePressure);
                    car.Tires.Add(tire);
                }

                cars.Add(car);
            }

            string command = Console.ReadLine();

            List<Car> result = new List<Car>();

            if (command == "fragile")
            {
                result = cars.Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(y => y.TirePressure < 1)).ToList();
            }
            else
            {
                result = cars.Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250).ToList();
            }

            foreach (var car in result)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
