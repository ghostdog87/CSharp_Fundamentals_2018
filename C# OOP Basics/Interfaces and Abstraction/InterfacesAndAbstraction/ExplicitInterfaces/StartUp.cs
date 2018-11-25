using ExplicitInterfaces.Contracts;
using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] currentPerson = input.Split();

                string name = currentPerson[0];
                string country = currentPerson[1];
                int age = int.Parse(currentPerson[2]);

                Citizen citizen = new Citizen(name,country,age);
                IPerson person = citizen;
                IResident resident = citizen;


                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());

                input = Console.ReadLine();
            }
        }
    }
}
