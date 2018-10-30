using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise8
{
    class VampireBunnies
    {
        static int playerRow = 0;
        static int playerCol = 0;
        static char[][] lair;
        static bool isPlayerDeadOrOut = false;
        static bool isPlayerOut = false;

        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int dimension1 = input[0];
            int dimension2 = input[1];

            lair = new char[dimension1][];           

            for (int row = 0; row < dimension1; row++)
            {
                char[] lairRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < lairRow.Length; col++)
                {
                    lair[row] = lairRow;
                }
            }

            //Print();

            char[] commands = Console.ReadLine().ToCharArray();
            for (int i = 0; i < commands.Length; i++)
            {
                GetPlayerPosition();
                MovePlayer(commands[i]);
                if (!isPlayerOut)
                {
                    SpreadBunnies();
                    if (isPlayerDeadOrOut)
                    {
                        Dead(playerRow, playerCol);
                        break;
                    }
                }
                else
                {
                    break;
                }
                //Print();
                
            }
        }

        private static void SpreadBunnies()
        {
            Queue<int[]> bunnyPositions = new Queue<int[]>();

            for (int row = 0; row < lair.Length; row++)
            {
                for (int col = 0; col < lair[row].Length; col++)
                {
                    if (lair[row][col] == 'B')
                    {
                        int[] bunny = new int[]{row,col};
                        bunnyPositions.Enqueue(bunny);
                    }
                }
            }

            while (bunnyPositions.Count > 0)
            {
                int[] currentBunny = bunnyPositions.Dequeue();

                int bunnyRow = currentBunny[0];
                int bunnyCol = currentBunny[1];

                if (IsInside(bunnyRow - 1, bunnyCol)) // spread left
                {
                    if (IsPlayer(bunnyRow - 1, bunnyCol))
                    {
                        isPlayerDeadOrOut = true;
                    }
                    lair[bunnyRow - 1][bunnyCol] = 'B';
                }
                if (IsInside(bunnyRow + 1, bunnyCol)) // spread right
                {
                    if (IsPlayer(bunnyRow + 1, bunnyCol))
                    {
                        isPlayerDeadOrOut = true;
                    }
                    lair[bunnyRow + 1][bunnyCol] = 'B';
                }
                if (IsInside(bunnyRow, bunnyCol - 1)) // spread up
                {
                    if (IsPlayer(bunnyRow, bunnyCol - 1))
                    {
                        isPlayerDeadOrOut = true;
                    }
                    lair[bunnyRow][bunnyCol - 1] = 'B';
                }
                if (IsInside(bunnyRow, bunnyCol + 1)) // spread down
                {
                    if (IsPlayer(bunnyRow, bunnyCol + 1))
                    {
                        isPlayerDeadOrOut = true;
                    }
                    lair[bunnyRow][bunnyCol + 1] = 'B';
                }
            }
        }

        private static bool IsPlayer(int row, int col)
        {
            return lair[row][col] == 'P';
        }

        private static void MovePlayer(char command)
        {
            switch (command)
            {
                case 'L':
                    Move(0, -1);
                    break;
                case 'R':
                    Move(0, 1);
                    break;
                case 'U':
                    Move(-1, 0);
                    break;
                case 'D':
                    Move(1, 0);
                    break;
                default:
                    break;
            }
        }

        private static void Move(int row, int col)
        {
            int finalRow = playerRow;
            int finalCol = playerCol;
            playerRow += row;
            playerCol += col;

            if (IsInside(playerRow, playerCol))
            {
                if (lair[playerRow][playerCol] == 'B')
                {
                    isPlayerDeadOrOut = true;
                }
                else
                {
                    lair[playerRow - row][playerCol - col] = '.';
                    lair[playerRow][playerCol] = 'P';
                }               
            }
            else
            {
                lair[finalRow][finalCol] = '.';
                SpreadBunnies();
                Print();
                Console.WriteLine($"won: {playerRow - row} {playerCol - col}");
                isPlayerOut = true;
                isPlayerDeadOrOut = true;
            }
        }

        private static void Dead(int row, int col)
        {
            Print();
            Console.WriteLine($"dead: {playerRow} {playerCol}");           
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < lair.Length && col >= 0 && col < lair[0].Length;
        }

        private static void GetPlayerPosition()
        {
            for (int row = 0; row < lair.Length; row++)
            {
                for (int col = 0; col < lair[row].Length; col++)
                {
                    if (lair[row][col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }

        private static void Print()
        {
            for (int row = 0; row < lair.Length; row++)
            {
                Console.WriteLine(String.Join("", lair[row]));
            }
        }
    }
}
