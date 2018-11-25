using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals.Factory;
using WildFarm.Models.Foods.Factory;

namespace WildFarm.Core
{
    public class Engine
    {
        public void Run()
        {
            BirdFactory birdFactory = new BirdFactory();
            MammalFactory mammalFactory = new MammalFactory();
            FelineFactory felineFactory = new FelineFactory();
            FoodFactory foodFactory = new FoodFactory();

            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string[] currentAnimal = Console.ReadLine().Split();

                if (currentAnimal[0] == "End")
                {
                    break;
                }

                string[] currentFood = Console.ReadLine().Split();

                string animalType = currentAnimal[0];
                string animalName = currentAnimal[1];
                double animalWeight = double.Parse(currentAnimal[2]);

                string foodType = currentFood[0];
                int foodQuantity = int.Parse(currentFood[1]);
                Food food = foodFactory.CreateFood(foodType, foodQuantity);

                try
                {
                    if (animalType == "Hen" || animalType == "Owl")
                    {
                        double wingSize = double.Parse(currentAnimal[3]);
                        Animal animal = birdFactory.CreateBird(animalType, animalName, animalWeight, wingSize);
                       
                        animal.ProduceSound();
                        animals.Add(animal);
                        animal.Eat(food);
                        
                    }
                    else if (animalType == "Mouse" || animalType == "Dog")
                    {
                        string livingRegion = currentAnimal[3];
                        Animal animal = mammalFactory.CreateMammal(animalType, animalName, animalWeight, livingRegion);
                       
                        animal.ProduceSound();
                        animals.Add(animal);
                        animal.Eat(food);
                        
                    }
                    else if (animalType == "Cat" || animalType == "Tiger")
                    {
                        string livingRegion = currentAnimal[3];
                        string breed = currentAnimal[4];
                        Animal animal = felineFactory.CreateFeline(animalType, animalName, animalWeight, livingRegion, breed);
                      
                        animal.ProduceSound();
                        animals.Add(animal);
                        animal.Eat(food);
                        

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
