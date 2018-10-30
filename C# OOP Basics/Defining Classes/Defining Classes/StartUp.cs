using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] currentInput = Console.ReadLine().Split();
                string name = currentInput[0];
                int age = int.Parse(currentInput[1]);

                family.AddMember(new Person(name, age));
            }

            List<Person> sortedPeople = family.SortPeople();

            foreach (var person in sortedPeople)
            {
                //Lyubo - 44
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
            
        }
    }
}
