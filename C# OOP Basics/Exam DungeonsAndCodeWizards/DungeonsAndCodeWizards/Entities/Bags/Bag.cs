using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Bags
{
    public abstract class Bag
    {
        private const int DefaultCapacity = 100;
        private int capacity;
        private List<Item> items;

        protected Bag()
        {
            this.Capacity = DefaultCapacity;
            this.items = new List<Item>();
        }

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();           
        }

        public int Load => Items.Sum(x => x.Weight);

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {

            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            if (!(this.Items.Any(x => x.GetType().Name == name)))
            {
                throw new InvalidOperationException($"No item with name {name} in bag!");
            }

            Item currentItem = this.Items.First(x => x.GetType().Name == name);
            this.items.Remove(currentItem);
            return currentItem;
        }

        public IReadOnlyCollection<Item> Items
        {
            get { return items.AsReadOnly(); }
        }

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

    }
}
