using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam_Storage_Master.Models.Vehicles
{
    public abstract class Vehicle
    {
        private int capacity;
        private List<Product> trunk;

        protected Vehicle(int capacity)
        {
            Capacity = capacity;
            trunk = new List<Product>();
        }

        public bool IsFull => trunk.Sum(x => x.Weight) >= this.Capacity;
        public bool IsEmpty => trunk.Count == 0;

        public IReadOnlyCollection<Product> Trunk
        {
            get { return trunk.AsReadOnly(); }
        }

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }


        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }
            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            Product lastProduct = this.trunk[this.trunk.Count - 1];
            this.trunk.RemoveAt(this.trunk.Count - 1);
            return lastProduct;
        }
    }
}
