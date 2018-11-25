using Exam_Storage_Master.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_Storage_Master.Factory
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string vehicleType)
        {
            switch (vehicleType)
            {
                case "Van":
                    return new Van();
                case "Truck":
                    return new Truck();
                case "Semi":
                    return new Semi();
                default:
                    throw new InvalidOperationException("Invalid vehicle type!");
            }
        }
    }
}
