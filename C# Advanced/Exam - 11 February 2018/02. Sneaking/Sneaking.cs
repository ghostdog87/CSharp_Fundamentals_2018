using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Sneaking
{
    class Sneaking
    {
        static char[][] matrix;
        static List<int[]> enemiesPositions;
        static int[] NikoladzePosition;
        static int[] SamPosition;

        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            matrix = new char[numberOfRows][];

            enemiesPositions = new List<int[]>();
            NikoladzePosition = new int[2];
            SamPosition = new int[2];

            for (int row = 0; row < numberOfRows; row++)
            {
                string currentRow = Console.ReadLine();
                matrix[row] = new char[currentRow.Length];
                for (int col = 0; col < currentRow.Length; col++)
                {                    
                    matrix[row][col] = currentRow[col];
                    if (matrix[row][col] == 'S')
                    {
                        SamPosition[0] = row;
                        SamPosition[1] = col;
                    }
                    else if (matrix[row][col] == 'N')
                    {
                        NikoladzePosition[0] = row;
                        NikoladzePosition[1] = col;
                    }
                    else if (matrix[row][col] == 'b' || matrix[row][col] == 'd')
                    {
                        enemiesPositions.Add(new int[] { row, col});
                    }
                }
            }

            //Print(matrix);

            string commands = Console.ReadLine();

            for (int i = 0; i < commands.Length; i++)
            {
                MoveEnemies();
                //Print(matrix);
                
                if (IsSamKilled()) // might need second check afer Sam moves
                {
                    matrix[SamPosition[0]][SamPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {SamPosition[0]}, {SamPosition[1]}");
                    Print(matrix);
                    break;
                }
                MoveSam(commands[i]);

                if (IsNikoladzeKilled())
                {
                    matrix[NikoladzePosition[0]][NikoladzePosition[1]] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    Print(matrix);
                    break;
                }
                //Print(matrix);
            }


        }

        private static bool IsNikoladzeKilled()
        {
            if (NikoladzePosition[0] == SamPosition[0])
            {
                return true;
            }
            return false;
        }

        private static void MoveSam(char command)
        {
            switch (command)
            {
                //(U, D, L, R, W)
                case 'U':
                    matrix[SamPosition[0]][SamPosition[1]] = '.';
                    SamPosition[0] -= 1;
                    matrix[SamPosition[0]][SamPosition[1]] = 'S';
                    break;
                case 'D':
                    matrix[SamPosition[0]][SamPosition[1]] = '.';
                    SamPosition[0] += 1;
                    matrix[SamPosition[0]][SamPosition[1]] = 'S';
                    break;
                case 'L':
                    matrix[SamPosition[0]][SamPosition[1]] = '.';
                    SamPosition[1] -= 1;
                    matrix[SamPosition[0]][SamPosition[1]] = 'S';
                    break;
                case 'R':
                    matrix[SamPosition[0]][SamPosition[1]] = '.';
                    SamPosition[1] += 1;
                    matrix[SamPosition[0]][SamPosition[1]] = 'S';
                    break;
                default:
                    break;
            }
        }

        private static bool IsSamKilled()
        {           
            for (int col = 0; col < matrix[SamPosition[0]].Length; col++)
            {
                if (matrix[SamPosition[0]][col] == 'b' && col <= SamPosition[1])
                {
                    return true;
                }
                if (matrix[SamPosition[0]][col] == 'd' && col >= SamPosition[1])
                {
                    return true;
                }
            }
            return false;
        }

        private static void MoveEnemies()
        {
            for (int i = 0; i < enemiesPositions.Count; i++)
            {

                int currentEnemyRow = enemiesPositions[i][0];
                int currentEnemyCol = enemiesPositions[i][1];

                if (matrix[currentEnemyRow][currentEnemyCol] == 'b') // goes right
                {
                    if (currentEnemyCol == matrix[currentEnemyRow].Length - 1)
                    {
                        matrix[currentEnemyRow][currentEnemyCol] = 'd';
                    }
                    else
                    {
                        matrix[currentEnemyRow][currentEnemyCol] = '.';
                        enemiesPositions[i][1] += 1;
                        matrix[currentEnemyRow][currentEnemyCol + 1] = 'b';
                    }
                }

                else if (matrix[currentEnemyRow][currentEnemyCol] == 'd') // goes left
                {
                    if (currentEnemyCol == 0)
                    {
                        matrix[currentEnemyRow][currentEnemyCol] = 'b';
                    }
                    else
                    {
                        matrix[currentEnemyRow][currentEnemyCol] = '.';
                        enemiesPositions[i][1] -= 1;
                        matrix[currentEnemyRow][currentEnemyCol - 1] = 'd';
                    }
                }

                //Print(matrix);
            }
        }

        private static void Print(char[][] matrix)
        {
            //Console.WriteLine(); // put in comments before judge
            for (int row = 0; row < matrix.Length; row++)
            {               
                Console.WriteLine(string.Join("", matrix[row]));
            }
        }
    }
}
