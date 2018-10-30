using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise10
{
    class TheHeiganDance
    {
        static int playerRow = 7;
        static int playerCol = 7;
        static int playerHP = 18500;
        static double heiganHP = 3000000;
        static int plagueCloud = 3500;
        static int eruption = 6000;
        static bool isCloud = false;

        static void Main(string[] args)
        {

            double playerDmg = double.Parse(Console.ReadLine());
            bool killedByCloud = false;
            bool killedByEruption = false;

            while (true)
            {
                if (playerHP > 0)
                {
                    heiganHP -= playerDmg;
                }
                
                if (isCloud)
                {
                    playerHP -= plagueCloud;
                    isCloud = false;
                    if (playerHP <= 0)
                    {
                        killedByCloud = true;
                    }
                }

                if (playerHP <= 0 || heiganHP <= 0)
                {
                    break;
                }

                string[] input = Console.ReadLine().Split();
                string spell = input[0];
                int spellRow = int.Parse(input[1]);
                int spellCol = int.Parse(input[2]);
                
                bool isHitOrOutside = false;

                if (IsImpactArea(spellRow, spellCol, playerRow, playerCol))
                {
                    isHitOrOutside = true;

                    isHitOrOutside = Move(-1, 0, spellRow, spellCol); // up
                    if (isHitOrOutside)
                    {
                        isHitOrOutside = Move(0, 1, spellRow, spellCol); // right
                    }
                    if (isHitOrOutside)
                    {
                        isHitOrOutside = Move(1, 0, spellRow, spellCol); // down
                    }
                    if (isHitOrOutside)
                    {
                        isHitOrOutside = Move(0, -1, spellRow, spellCol); // left
                    }

                    if (isHitOrOutside)
                    {
                        if (spell == "Cloud")
                        {
                            isCloud = true;
                            playerHP -= plagueCloud;
                            if (playerHP <= 0)
                            {
                                killedByCloud = true;
                            }

                        }
                        else if (spell == "Eruption")
                        {
                            isCloud = false;
                            playerHP -= eruption;
                            if (playerHP <= 0)
                            {
                                killedByEruption = true;
                            }
                        }
                    }
                }
                               
            }

            if (heiganHP <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganHP:F2}");
            }

            if (playerHP <= 0)
            {
                if (killedByCloud)
                {
                    Console.WriteLine($"Player: Killed by Plague Cloud");
                }
                else if (killedByEruption)
                {
                    Console.WriteLine($"Player: Killed by Eruption");
                }
            }
            else
            {
                Console.WriteLine($"Player: {playerHP}");
            }

            Console.WriteLine($"Final position: {playerRow}, {playerCol}");

        }

        private static bool IsImpactArea(int spellRow, int spellCol, int playerRow, int playerCol)
        {
            return playerRow >= spellRow - 1 && playerRow <= spellRow + 1 &&
                   playerCol >= spellCol - 1 && playerCol <= spellCol + 1;
        }

        private static bool Move(int row, int col, int spellRow, int spellCol)
        {
            int currentPlayerRow = playerRow + row;
            int currentPlayerCol = playerCol + col;

            if (PlayerIsInside(currentPlayerRow, currentPlayerCol))
            {
                if (IsImpactArea2(spellRow, spellCol, currentPlayerRow, currentPlayerCol))
                {
                    return true;
                }
                else
                {
                    playerRow += row;
                    playerCol += col;
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private static bool IsImpactArea2(int spellRow, int spellCol, int currentPlayerRow, int currentPlayerCol)
        {
            return currentPlayerRow >= spellRow - 1 && currentPlayerRow <= spellRow + 1 &&
                   currentPlayerCol >= spellCol - 1 && currentPlayerCol <= spellCol + 1;
        }

        private static bool PlayerIsInside(int row, int col)
        {
            return row >= 0 && row < 15 && col >= 0 && col < 15;
        }

    }
}
