using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Core
{
    public class Engine
    {
        private AnimalCentre animalCenter;

        public Engine()
        {
            this.animalCenter = new AnimalCentre();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] currentInput = input.Split();
                string type;

                try
                {
                    //•	RegisterAnimal {type} {name} {energy} {happiness} {procedureTime}
                    if (currentInput[0] == "RegisterAnimal")
                    {
                        type = currentInput[1];
                        string name = currentInput[2];
                        int energy = int.Parse(currentInput[3]);
                        int happiness = int.Parse(currentInput[4]);
                        int procedureTime = int.Parse(currentInput[5]);
                        string result = animalCenter.RegisterAnimal(type, name, energy,happiness,procedureTime);
                        Console.WriteLine(result);
                    }
                    //•	Chip {name} {procedureTime}
                    if (currentInput[0] == "Chip")
                    {
                        string name = currentInput[1];
                        int procedureTime = int.Parse(currentInput[2]);
                        string result = animalCenter.Chip(name, procedureTime);
                        Console.WriteLine(result);
                    }
                    //•	Vaccinate {name} {procedureTime}
                    if (currentInput[0] == "Vaccinate")
                    {
                        string name = currentInput[1];
                        int procedureTime = int.Parse(currentInput[2]);
                        string result = animalCenter.Vaccinate(name, procedureTime);
                        Console.WriteLine(result);
                    }
                    //•	Fitness {name} {procedureTime}
                    if (currentInput[0] == "Fitness")
                    {
                        string name = currentInput[1];
                        int procedureTime = int.Parse(currentInput[2]);
                        string result = animalCenter.Fitness(name, procedureTime);
                        Console.WriteLine(result);
                    }
                    //•	Play {name} {procedureTime}
                    if (currentInput[0] == "Play")
                    {
                        string name = currentInput[1];
                        int procedureTime = int.Parse(currentInput[2]);
                        string result = animalCenter.Play(name, procedureTime);
                        Console.WriteLine(result);
                    }
                    //•	DentalCare {name} {procedureTime}
                    if (currentInput[0] == "DentalCare")
                    {
                        string name = currentInput[1];
                        int procedureTime = int.Parse(currentInput[2]);
                        string result = animalCenter.DentalCare(name, procedureTime);
                        Console.WriteLine(result);
                    }
                    //•	NailTrim {name} {procedureTime}
                    if (currentInput[0] == "NailTrim")
                    {
                        string name = currentInput[1];
                        int procedureTime = int.Parse(currentInput[2]);
                        string result = animalCenter.NailTrim(name, procedureTime);
                        Console.WriteLine(result);
                    }
                    //•	Adopt {animal name} {owner}
                    if (currentInput[0] == "Adopt")
                    {
                        string name = currentInput[1];
                        string owner = currentInput[2];
                        string result = animalCenter.Adopt(name, owner);
                        Console.WriteLine(result);
                    }
                    //•	History {procedureType}
                    if (currentInput[0] == "History")
                    {
                        string procedureType = currentInput[1];
                        string result = animalCenter.History(procedureType);
                        Console.WriteLine(result);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("InvalidOperationException: " + ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("ArgumentException: " + ex.Message);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(animalCenter.GetSummary());
        }
    }
}
