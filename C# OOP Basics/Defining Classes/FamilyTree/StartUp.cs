using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyTree
{
    public class StartUp
    {
        static List<Person> parents;
        static List<Person> children;

        static void Main(string[] args)
        {
            string ourPerson = Console.ReadLine();

            List<Person> persons = new List<Person>();
            List<string> relationShips = new List<string>();
            parents = new List<Person>();
            children = new List<Person>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                if (!input.Contains("-"))
                {
                    string[] personInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string personName = personInput[0] + " " + personInput[1];
                    string personBirthDate = personInput[2];
                    Person person = new Person(personName, personBirthDate);
                    persons.Add(person);
                }
                else
                {
                    relationShips.Add(input);
                }

                input = Console.ReadLine();
            }

            foreach (var relation in relationShips)
            {
                string[] relationArgs = relation.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                Person parent = GetConnection(persons, relationArgs[0]);
                Person child = GetConnection(persons, relationArgs[1]);
                if (!parent.Children.Contains(child))
                {
                    parent.Children.Add(child);
                }
                if (!child.Parents.Contains(parent))
                {
                    child.Parents.Add(parent);
                }               
            }

            Person mainPerson = GetConnection(persons, ourPerson);
            Console.WriteLine($"{mainPerson.Name} {mainPerson.Birthday}");
            Console.WriteLine("Parents:");
            foreach (var parents in mainPerson.Parents)
            {
                Console.WriteLine($"{parents.Name} {parents.Birthday}");
            }
            Console.WriteLine("Children:");
            foreach (var children in mainPerson.Children)
            {
                Console.WriteLine($"{children.Name} {children.Birthday}");
            }
        }

        private static Person GetConnection(List<Person> persons, string relationArgs)
        {
            if (relationArgs.Contains("/"))
            {
                return persons.FirstOrDefault(x => x.Birthday == relationArgs);
            }
            return persons.FirstOrDefault(x => x.Name == relationArgs);
        }
    }
}
