using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_Storage_Master.Models.Products
{
    public class Ram : Product
    {
        private const double ramWeight = 0.1;
        public Ram(double price) : base(price, ramWeight)
        {
        }
    }
}
