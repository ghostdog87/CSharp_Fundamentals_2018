using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Factories
{
    public class AnimalFactory
    {
        public IAnimal CreateAnimal(string animalType, string name,int energy,int happiness, int procedureTime)
        {
            switch (animalType)
            {
                case "Cat":
                    return new Cat(name, energy, happiness, procedureTime);
                case "Dog":
                    return new Dog(name, energy, happiness, procedureTime);
                case "Lion":
                    return new Lion(name, energy, happiness, procedureTime);
                case "Pig":
                    return new Pig(name, energy, happiness, procedureTime);
                default:
                    throw new InvalidOperationException("Invalid animal type!");
            }
        }
    }
}
