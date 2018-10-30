using System;
using System.Collections.Generic;
using System.Linq;

namespace Google
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Person> persons = new List<Person>();

            while (input != "End")
            {
                string[] currentInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = currentInput[0];
                string info = currentInput[1];

                if (!persons.Any(x => x.Name == name))
                {
                    persons.Add(new Person(name));
                }

                Person person = persons.FirstOrDefault(x => x.Name == name);

                if (info == "company")
                {
                    string companyName = currentInput[2];
                    string department = currentInput[3];
                    decimal salary = decimal.Parse(currentInput[4]);
                    person.Company = new Company(companyName, department, salary);
                }
                else if (info == "pokemon")
                {
                    string pokemonName = currentInput[2];
                    string pokemonType = currentInput[3];
                    person.Pokemon.Add(new Pokemon(pokemonName, pokemonType));
                }
                else if (info == "parents")
                {
                    string parentName = currentInput[2];
                    string parentBirthday = currentInput[3];
                    person.Parents.Add(new Parents(parentName, parentBirthday));
                }
                else if (info == "children")
                {
                    string childName = currentInput[2];
                    string childBirthday = currentInput[3];
                    person.Children.Add(new Children(childName, childBirthday));
                }
                else if (info == "car")
                {
                    string carModel = currentInput[2];
                    int carSpeed = int.Parse(currentInput[3]);
                    person.Car = new Car(carModel, carSpeed);
                }

                input = Console.ReadLine();
            }

            string getPersonInfo = Console.ReadLine();

            Person personInfo = persons.FirstOrDefault(x => x.Name == getPersonInfo);
            Console.WriteLine(personInfo.Name);
            Console.WriteLine($"Company:");
            if (personInfo.Company != null)
            {
                Console.WriteLine($"{personInfo.Company.CompanyName} {personInfo.Company.Department} {personInfo.Company.Salary:F2}");
            }           
            Console.WriteLine($"Car:");
            if (personInfo.Car != null)
            {
                Console.WriteLine($"{personInfo.Car.CarModel} {personInfo.Car.CarSpeed}");
            }           
            Console.WriteLine($"Pokemon:");
            foreach (var pokemon in personInfo.Pokemon)
            {
                Console.WriteLine($"{pokemon.PokemonName} {pokemon.PokemonType}");
            }
            Console.WriteLine($"Parents:");
            foreach (var parent in personInfo.Parents)
            {
                Console.WriteLine($"{parent.ParentName} {parent.ParentBirthday}");
            }
            Console.WriteLine($"Children:");
            foreach (var child in personInfo.Children)
            {
                Console.WriteLine($"{child.ChildName} {child.ChildBirthday}");
            }
        }
    }
}
