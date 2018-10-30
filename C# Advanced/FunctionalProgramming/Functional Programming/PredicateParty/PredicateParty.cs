using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise10
{
    class PredicateParty
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Predicate<string> predicate;

            string commands = Console.ReadLine();

            while (commands != "Party!")
            {
                string changeGuests = commands.Split(" ")[0];
                string findGuests = commands.Split(" ")[1];
                string value = commands.Split(" ")[2];

                predicate = GetGuests(findGuests, value);

                commands = Console.ReadLine();

                if (changeGuests == "Remove")
                {
                    guests.RemoveAll(predicate);
                }
                else if (changeGuests == "Double")
                {
                    List<string> getNewGuests = guests.FindAll(predicate);

                    foreach (var guest in getNewGuests)
                    {
                        int findIndex = guests.IndexOf(guest);
                        guests.Insert(findIndex + 1, guest);
                    }
                }

                
            }
            if (guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
            }
            
        }

        private static Predicate<string> GetGuests(string findGuests, string value)
        {
            switch (findGuests)
            {
                case "StartsWith":
                    return x => x.StartsWith(value);                   
                case "EndsWith":
                    return x => x.EndsWith(value);                   
                case "Length":
                    return x => x.Length == int.Parse(value);                    
                default:
                    return null;
            }
        }
    }
}
