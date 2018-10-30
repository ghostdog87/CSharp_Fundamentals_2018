using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cups_and_Bottles
{
    class CupsAndBottles 
    {
        static void Main(string[] args)
        {
            List<int> listOfCups = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> listOfBottles = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Queue<int> cups = new Queue<int>();
            Stack<int> bottles = new Stack<int>();

            for (int i = 0; i < listOfCups.Count; i++)
            {
                cups.Enqueue(listOfCups[i]);
            }

            for (int i = 0; i < listOfBottles.Count; i++)
            {
                bottles.Push(listOfBottles[i]);
            }

            //Console.WriteLine(cups.Peek());
            //Console.WriteLine(bottles.Peek());

            int wastedWater = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currentCup = cups.Peek();
                int currentBottle = bottles.Pop();

                int waste = currentBottle - currentCup;

                if (waste >= 0)
                {
                    wastedWater += waste;
                    cups.Dequeue();
                }
                else
                {                   
                    while (waste < 0 && bottles.Count > 0)
                    {
                        currentBottle = bottles.Pop();
                        waste = currentBottle - (Math.Abs(waste));

                        if (waste >= 0)
                        {
                            wastedWater += waste;
                            cups.Dequeue();
                            break;
                        }
                    }
                }
            }
            if (cups.Count > 0)
            {
                Console.WriteLine("Cups: " + string.Join(" ", listOfCups.TakeLast(cups.Count)));
            }
            else if (bottles.Count > 0)
            {
                Console.WriteLine("Bottles: " + string.Join(" ", listOfBottles.Take(bottles.Count)));
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
