using System;
using System.Collections.Generic;
using System.Text;
using Exam_Storage_Master.Models.Vehicles;

namespace Exam_Storage_Master.Models.Storages
{
    public class DistributionCenter : Storage
    {
        private const int DistributionCenterCapacity = 2;
        private const int DistributionCenterGarageSlots = 5;

        private static Vehicle[] Vehicles = new Vehicle[]{
            new Van(),
            new Van(),
            new Van()
        };

        public DistributionCenter(string name) 
            : base(name, DistributionCenterCapacity, DistributionCenterGarageSlots, Vehicles)
        {
        }
    }
}
