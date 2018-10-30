using System;
using System.Collections.Generic;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < N; i++)
            {
                string[] currentEngine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                //<Model> <Power> <Displacement> <Efficiency>
                string model = currentEngine[0];
                int power = int.Parse(currentEngine[1]);
                Engine engine = new Engine(model, power);

                if (currentEngine.Length == 3)
                {
                    bool isNumeric = int.TryParse(currentEngine[2], out int n);
                    if (isNumeric)
                    {
                        engine.Displacement = n;
                    }
                    else
                    {
                        engine.Efficiency = currentEngine[2];
                    }
                }
                else if(currentEngine.Length == 4)
                {
                    engine.Displacement = int.Parse(currentEngine[2]);
                    engine.Efficiency = currentEngine[3];
                }
                engines.Add(engine);
            }

            int M = int.Parse(Console.ReadLine());

            for (int i = 0; i < M; i++)
            {
                string[] currentCar = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                //<Model> <Engine> <Weight> <Color>
                string model = currentCar[0];
                Engine engine = engines.Find(x => x.Model == currentCar[1]);
                Car car = new Car(model, engine);

                if (currentCar.Length == 3)
                {
                    bool isNumeric = int.TryParse(currentCar[2], out int weight);
                    if (isNumeric)
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = currentCar[2];
                    }
                }
                else if (currentCar.Length == 4)
                {
                    car.Weight = int.Parse(currentCar[2]);
                    car.Color = currentCar[3];
                }
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                string displacement = car.Engine.Displacement == 0 ? "n/a" : car.Engine.Displacement.ToString();
                Console.WriteLine($"    Displacement: {displacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                string weight = car.Weight == 0 ? "n/a" : car.Weight.ToString();
                Console.WriteLine($"  Weight: {weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}
