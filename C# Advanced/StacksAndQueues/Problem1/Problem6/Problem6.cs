using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem6
{
    class Problem6
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Queue<string> petrolPumps = new Queue<string>();

            for (int i = 0; i < N; i++)
            {
                string input = Console.ReadLine();
                petrolPumps.Enqueue(input);
            }


            int bestIndex = 0;

            while (true)
            {
                int reservoir = 0;
                
                foreach (var pump in petrolPumps)
                {
                    string[] input = pump.Split();
                    int oil = int.Parse(input[0]);
                    int distance = int.Parse(input[1]);
                    reservoir += oil - distance;

                    if (reservoir < 0)
                    {
                        petrolPumps.Enqueue(petrolPumps.Dequeue());
                        bestIndex++;
                        break;
                    }
                }

                if (reservoir >= 0)
                {
                    Console.WriteLine(bestIndex);
                    break;
                }
                
            }
            
        }
    }
}
