using System;
using System.Collections.Generic;
using System.Text;
using Exam_Storage_Master.Models.Vehicles;

namespace Exam_Storage_Master.Models.Storages
{
    public class Warehouse : Storage
    {
        private const int WarehouseCapacity = 10;
        private const int WarehouseGarageSlots = 10;

        private static Vehicle[] Vehicles = new Vehicle[]{
            new Semi(),
            new Semi(),
            new Semi()
        };

        public Warehouse(string name) 
            : base(name, WarehouseCapacity, WarehouseGarageSlots, Vehicles)
        {
        }
    }
}
