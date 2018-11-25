using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_Storage_Master.Models.Products
{
    public class HardDrive : Product
    {
        private const double hardDriveWeight = 1.0;
        public HardDrive(double price) : base(price, hardDriveWeight)
        {
        }
    }
}
