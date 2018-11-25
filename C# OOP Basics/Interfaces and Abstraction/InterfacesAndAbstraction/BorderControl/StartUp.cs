using BorderControl.Contracts;
using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<Rebel> rebels = new List<Rebel>();
            List<Citizen> citizens = new List<Citizen>();

            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] currentPerson = Console.ReadLine().Split();

                if (currentPerson.Length == 3)
                {
                    //<name> <age><group>

                    string name = currentPerson[0];
                    int age = int.Parse(currentPerson[1]);
                    string group = currentPerson[2];

                    Rebel person = new Rebel(name,age,group);
                    rebels.Add(person);
                    
                }

                if (currentPerson.Length == 4)
                {
                    //<name> <age> <id> <birthdate>

                    string name = currentPerson[0];
                    int age = int.Parse(currentPerson[1]);
                    string id = currentPerson[2];
                    string birthdate = currentPerson[3];

                    Citizen person = new Citizen(name, age, id, birthdate);
                    citizens.Add(person);

                }
            }

            string currentName = Console.ReadLine();

            while (currentName != "End")
            {
                if (rebels.Any(x =>x.Name == currentName))
                {
                    Rebel currentRebel = rebels.FirstOrDefault(x => x.Name == currentName);
                    currentRebel.BuyFood();
                }

                if (citizens.Any(x => x.Name == currentName))
                {
                    Citizen currentCitizen = citizens.FirstOrDefault(x => x.Name == currentName);
                    currentCitizen.BuyFood();
                }

                currentName = Console.ReadLine();
            }

            int totalFood = citizens.Sum(x => x.Food) + rebels.Sum(x => x.Food);

            Console.WriteLine(totalFood);

        }
    }
}
