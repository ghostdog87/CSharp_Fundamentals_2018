using System;
using System.Collections.Generic;
using System.Text;
using Exam_Storage_Master.Models.Vehicles;

namespace Exam_Storage_Master.Models.Storages
{
    public class AutomatedWarehouse : Storage
    {
        private const int AutomatedWarehouseCapacity = 1;
        private const int AutomatedWarehouseGarageSlots = 2;
        private static Vehicle[] Vehicles = new Vehicle[]{
            new Truck(),
        };

        public AutomatedWarehouse(string name) 
            : base(name, AutomatedWarehouseCapacity, AutomatedWarehouseGarageSlots, Vehicles)
        {
        }
    }
}
