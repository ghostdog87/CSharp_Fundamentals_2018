using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Hotel
{
    public class Hotel : IHotel
    {
        private const int DefaultCapacity = 10;
        private int capacity;
        private Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.Capacity = DefaultCapacity;
            this.animals = new Dictionary<string, IAnimal>();
        }

        public IReadOnlyDictionary<string, IAnimal> Animals
        {
            get { return animals; }
        }

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public void Accommodate(IAnimal animal)
        {
            if (this.animals.Count >= this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }
            if (this.animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }
            this.animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
            IAnimal adoptedAnimal = animals[animalName];
            adoptedAnimal.Owner = owner;
            adoptedAnimal.IsAdopt = true;
            animals.Remove(animalName);
        }
    }
}
