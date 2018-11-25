using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Animal> animals = new List<Animal>();

            while (input != "Beast!")
            {
                string animalType = input;
                string[] animalProperties = Console.ReadLine().Split();
                string animalName = animalProperties[0];
                int animalAge = int.Parse(animalProperties[1]);
                string animalGender = animalProperties[2];

                try
                {
                    switch (animalType.ToLower())
                    {
                        case "dog":
                            Dog dog = new Dog(animalName, animalAge, animalGender);
                            animals.Add(dog);
                            break;
                        case "cat":
                            Cat cat = new Cat(animalName, animalAge, animalGender);
                            animals.Add(cat);
                            break;
                        case "frog":
                            Frog frog = new Frog(animalName, animalAge, animalGender);
                            animals.Add(frog);
                            break;
                        case "kitten":
                            Kitten kitten = new Kitten(animalName, animalAge);
                            animals.Add(kitten);
                            break;
                        case "tomcat":
                            Tomcat tomcat = new Tomcat(animalName, animalAge);
                            animals.Add(tomcat);
                            break;
                        default:
                            throw new Exception("Invalid input!");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                animal.ProduceSound();
            }
        }
    }
}
