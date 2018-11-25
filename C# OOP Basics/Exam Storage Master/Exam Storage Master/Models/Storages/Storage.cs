using Exam_Storage_Master.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam_Storage_Master.Models.Storages
{
    public abstract class Storage
    {
        private string name;
        private int capacity;
        private int garageSlots;
        private List<Product> products;
        private Vehicle[] garage;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            Name = name;
            Capacity = capacity;
            GarageSlots = garageSlots;
            products = new List<Product>();
            garage = new Vehicle[this.GarageSlots];

            this.FillGarageWithVehicles(vehicles);
        }

        private void FillGarageWithVehicles(IEnumerable<Vehicle> vehicles)
        {
            int index = 0;

            foreach (var vehicle in vehicles)
            {
                this.garage[index] = vehicle;
                index++;
            }
        }

        public IReadOnlyCollection<Vehicle> Garage
        {
            get { return Array.AsReadOnly(garage); }
        }

        public IReadOnlyCollection<Product> Products
        {
            get { return products.AsReadOnly(); }
        }

        public bool IsFull => products.Sum(x => x.Weight) >= this.Capacity;

        public int GarageSlots
        {
            get { return garageSlots; }
            private set { garageSlots = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }


        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
            if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return this.garage[garageSlot];
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle currentVehicle = this.GetVehicle(garageSlot);

            int firstFreeSlot = Array.IndexOf(deliveryLocation.garage, null);

            if (firstFreeSlot == -1)
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[garageSlot] = null;
            
            deliveryLocation.garage[firstFreeSlot] = currentVehicle;

            return firstFreeSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }
            Vehicle currentVehicle = this.GetVehicle(garageSlot);

            int countProducts = 0;

            while (!this.IsFull && !currentVehicle.IsEmpty)
            {
                Product currentProduct = currentVehicle.Unload();
                this.products.Add(currentProduct);
                countProducts++;
            }

            return countProducts;
        }
    }
}
