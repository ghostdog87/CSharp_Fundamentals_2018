using Exam_Storage_Master.Models.Storages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_Storage_Master.Factory
{
    public class StorageFactory
    {
        public Storage CreateStorage(string storageType, string name)
        {
            switch (storageType)
            {
                case "AutomatedWarehouse":
                    return new AutomatedWarehouse(name);
                case "DistributionCenter":
                    return new DistributionCenter(name);
                case "Warehouse":
                    return new Warehouse(name);
                default:
                    throw new InvalidOperationException("Invalid storage type!");
            }
        }
    }
}
