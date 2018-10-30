using System;
using System.Collections.Generic;

namespace Exercise6
{
    class Wardrobe
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < N; i++)
            {
                string[] currentInput = Console.ReadLine().Split(" -> ");
                string color = currentInput[0];
                string[] cloths = currentInput[1].Split(",",StringSplitOptions.RemoveEmptyEntries);

                Dictionary<string, int> listOfCloths = new Dictionary<string, int>();

                for (int j = 0; j < cloths.Length; j++)
                {                    
                    if (!wardrobe.ContainsKey(color))
                    {
                        if (!listOfCloths.ContainsKey(cloths[j]))
                        {
                            listOfCloths.Add(cloths[j], 1);
                        }
                        else
                        {
                            listOfCloths[cloths[j]]++;
                        }
                        wardrobe.Add(color,listOfCloths);
                    }
                    else
                    {
                        if (!wardrobe[color].ContainsKey(cloths[j]))
                        {
                            wardrobe[color].Add(cloths[j], 1);
                        }
                        else
                        {
                            wardrobe[color][cloths[j]]++;
                        }
                    }
                }
            }
            string[] findCloths = Console.ReadLine().Split();

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var cloth in color.Value)
                {
                    string found = string.Empty;
                    if (color.Key == findCloths[0] && cloth.Key == findCloths[1])
                    {
                        found = " (found!)";
                    }
                    Console.WriteLine($"* {cloth.Key} - {cloth.Value}" + found);
                }
            }
            
        }
    }
}
