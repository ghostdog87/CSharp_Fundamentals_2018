using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam___11_February_2018
{
    class KeyRevolver
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int sizeOfBarrel = int.Parse(Console.ReadLine());
            int[] inputBullets = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] inputLocks = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int value = int.Parse(Console.ReadLine());

            Queue<int> bullets = new Queue<int>();
            Stack<int> locks = new Stack<int>();

            for (int i = inputBullets.Length - 1; i >= 0; i--)
            {
                bullets.Enqueue(inputBullets[i]);
            }
            for (int i = inputLocks.Length - 1; i >= 0; i--)
            {
                locks.Push(inputLocks[i]);
            }

            int barrelCounter = 0;

            while (true)
            {
                if (locks.Count > 0)
                {
                    if (bullets.Count > 0)
                    {
                        int currentBullet = bullets.Dequeue();
                        int currentLock = locks.Peek();

                        if (currentBullet <= currentLock)
                        {
                            Console.WriteLine("Bang!");
                            locks.Pop();
                        }
                        else
                        {
                            Console.WriteLine("Ping!");
                        }

                        barrelCounter++;
                        if (barrelCounter == sizeOfBarrel && bullets.Count > 0)
                        {
                            Console.WriteLine("Reloading!");
                            barrelCounter = 0;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                        break;
                    }
                }
                else
                {
                    int bulletCost = (inputBullets.Length - bullets.Count) * bulletPrice;
                    int award = value - bulletCost;
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${award}");
                    break;
                }
            }

            
        }
    }
}
