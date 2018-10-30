using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise12
{
    class Inferno3
    {
        static void Main(string[] args)
        {
            List<int> gems = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> finalGems = new List<int>(gems);

            string commands = Console.ReadLine();


            while (commands != "Forge")
            {
                string changeGems = commands.Split(";", StringSplitOptions.RemoveEmptyEntries)[0];
                string findGems = commands.Split(";", StringSplitOptions.RemoveEmptyEntries)[1];
                int value = int.Parse(commands.Split(";", StringSplitOptions.RemoveEmptyEntries)[2]);
                Func<int, bool> someFunc = GetGems(gems, findGems, value);

                if (changeGems == "Exclude")
                {
                    for (int i = 0; i < gems.Count; i++)
                    {
                        if (someFunc(i))
                        {
                            finalGems[i] = -7777;
                        }
                    }
                }
                else if (changeGems == "Reverse")
                {
                    for (int i = 0; i < gems.Count; i++)
                    {
                        if (someFunc(i))
                        {
                            finalGems[i] = gems[i];
                        }
                    }
                }
                commands = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", finalGems.Where(x => x != -7777)));

        }

        private static Func<int,bool> GetGems(List<int> gems, string findGems,int value)
        {
            switch (findGems)
            {
                case "Sum Left":
                    return i => i == 0 ? gems[i] == value : gems[i] + gems[i - 1] == value;
                case "Sum Right":
                    return i => i == gems.Count - 1 ? gems[i] == value : gems[i] + gems[i + 1] == value;
                case "Sum Left Right":
                    return i => gems.Count == 1 ? gems[i] == value :
                                i == gems.Count - 1 ? gems[i - 1] + gems[i] == value :
                                i == 0 ? gems[i] + gems[i + 1] == value :
                                gems[i - 1] + gems[i] + gems[i + 1] == value;
                default:
                    return null;
            }
        }
    }
}
