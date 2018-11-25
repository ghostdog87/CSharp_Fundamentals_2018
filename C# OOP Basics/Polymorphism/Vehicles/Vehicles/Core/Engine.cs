using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            IVehicle car = new Car(carFuelQuantity, carFuelConsumption,carTankCapacity);
            IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption,truckTankCapacity);
            IVehicle bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] vehicleInfo = Console.ReadLine().Split();
                string actionType = vehicleInfo[0];
                string vehicleType = vehicleInfo[1];
                double vehicleValue = double.Parse(vehicleInfo[2]);

                if (actionType.ToLower() == "refuel")
                {
                    try
                    {
                        if (vehicleType.ToLower() == "car")
                        {
                            car.Refuel(vehicleValue);
                        }
                        else if (vehicleType.ToLower() == "truck")
                        {
                            truck.Refuel(vehicleValue);
                        }
                        else
                        {
                            bus.Refuel(vehicleValue);
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                }
                else if (actionType.ToLower() == "drive" || actionType.ToLower() == "driveempty")
                {
                    try
                    {
                        if (vehicleType.ToLower() == "car")
                        {
                            car.Drive(vehicleValue);
                        }
                        else if (vehicleType.ToLower() == "truck")
                        {
                            truck.Drive(vehicleValue);
                        }
                        else
                        {
                            if (actionType.ToLower() == "drive")
                            {
                                bus.IsVehicleEmpty = false;
                            }
                            else
                            {
                                bus.IsVehicleEmpty = true;
                            }
                            bus.Drive(vehicleValue);
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
