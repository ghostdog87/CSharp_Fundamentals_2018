using Exam_Storage_Master.Models;
using Exam_Storage_Master.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_Storage_Master.Factory
{
    public class ProductFactory
    {
        public Product CreateProduct(string productType, double price)
        {

            switch (productType)
            {
                case "Gpu":
                    return new Gpu(price);
                case "HardDrive":
                    return new HardDrive(price);
                case "Ram":
                    return new Ram(price);
                case "SolidStateDrive":
                    return new SolidStateDrive(price);
                default:
                    throw new InvalidOperationException("Invalid product type!");
            }
        }
    }
}
