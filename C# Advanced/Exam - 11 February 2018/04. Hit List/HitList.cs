using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hit_List
{
    class HitList
    {
        static void Main(string[] args)
        {
            int targetIndex = int.Parse(Console.ReadLine());
            var killers = new Dictionary<string, SortedDictionary<string, string>>();

            string input = Console.ReadLine();

            while (input != "end transmissions")
            {
                //Lambert=age:57;salary:7000
                string[] currentKiller = input.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string killerName = currentKiller[0];
                string[] killerInfo = currentKiller[1].Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (!killers.ContainsKey(killerName))
                {
                    killers.Add(killerName, new SortedDictionary<string, string>());
                }

                for (int i = 0; i < killerInfo.Length; i++)
                {
                    string[] currentInfo = killerInfo[i].Split(":", StringSplitOptions.RemoveEmptyEntries);
                    string info = currentInfo[0];
                    string infoValue = currentInfo[1];

                    if (!killers[killerName].ContainsKey(info))
                    {
                        killers[killerName].Add(info, infoValue);
                    }
                    else
                    {
                        killers[killerName][info] = infoValue;
                    }
                }

                input = Console.ReadLine();
            }

            string toBeKilled = Console.ReadLine().Split("Kill ", StringSplitOptions.RemoveEmptyEntries)[0];

            int counterOfIndex = 0;

            Console.WriteLine($"Info on {toBeKilled}:");

            foreach (var info in killers[toBeKilled])
            {
                counterOfIndex += info.Key.Length + info.Value.Length;
                Console.WriteLine($"---{info.Key}: {info.Value}");
            }

            Console.WriteLine($"Info index: {counterOfIndex}");

            if (counterOfIndex >= targetIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetIndex - counterOfIndex} more info.");
            }
        }
    }
}
