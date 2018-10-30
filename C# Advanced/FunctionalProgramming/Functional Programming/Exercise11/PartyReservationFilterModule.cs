using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise11
{
    class PartyReservationFilterModule
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> finalGuests = new List<string>(guests);

            Predicate<string> predicate;

            string commands = Console.ReadLine();

            while (commands != "Print")
            {
                string changeGuests = commands.Split(";", StringSplitOptions.RemoveEmptyEntries)[0];
                string findGuests = commands.Split(";", StringSplitOptions.RemoveEmptyEntries)[1];
                string value = commands.Split(";", StringSplitOptions.RemoveEmptyEntries)[2];

                predicate = GetGuests(findGuests, value);               

                if (changeGuests == "Add filter")
                {
                    List<string> indexes = finalGuests.FindAll(predicate);

                    foreach (var item in indexes)
                    {
                        finalGuests[finalGuests.IndexOf(item)] = "999999";
                    }
                }
                else if (changeGuests == "Remove filter")
                {
                    List<string> indexes = guests.FindAll(predicate);

                    foreach (var item in indexes)
                    {
                        finalGuests[guests.IndexOf(item)] = guests[guests.IndexOf(item)];
                    }
                    
                }
                commands = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", finalGuests.Where(x => x != "999999")));

        }

        private static Predicate<string> GetGuests(string findGuests, string value)
        {
            switch (findGuests)
            {
                case "Starts with":
                    return x => x.StartsWith(value);
                case "Ends with":
                    return x => x.EndsWith(value);
                case "Contains":
                    return x => x.Contains(value);
                case "Length":
                    return x => x.Length == int.Parse(value);
                default:
                    return null;
            }
        }
    }
}
