using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise6
{
    class TargetPractice
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            string snake = Console.ReadLine();

            char[][] wall = new char[rows][];

            int snakeCounter = 0;
            bool goLeft = true;

            for (int row = rows - 1; row >= 0; row--)
            {
                char[] rowOfWall = new char[cols];
                wall[row] = rowOfWall;
                if (goLeft)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        snakeCounter = FillWithSnakes(snake, snakeCounter, rowOfWall, col);

                    }
                    goLeft = false;
                }
                else
                {
                    for (int col = 0; col < cols; col++)
                    {
                        snakeCounter = FillWithSnakes(snake, snakeCounter, rowOfWall, col);

                    }
                    goLeft = true;
                }
                
            }

            //Print(wall);

            int[] shot = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int targetRow = shot[0];
            int targetCol = shot[1];
            int radius = shot[2];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    bool isShotInsideTriangle = Math.Pow(targetRow - row,2) + Math.Pow(targetCol - col, 2) <= Math.Pow(radius,2);

                    if (isShotInsideTriangle)
                    {
                        wall[row][col] = ' ';
                    }
                }
            }

            //Print(wall);


            Queue<char> finalCols = new Queue<char>();
            for (int col = 0; col < cols; col++)
            {
                
                int counter = 0;
                for (int row = 0; row < rows; row++)
                {

                    if (wall[row][col] != ' ')
                    {
                        finalCols.Enqueue(wall[row][col]);
                    }
                    else
                    {
                        counter++;
                    }
                }

                for (int row = 0; row < counter; row++)
                {
                    wall[row][col] = ' ';
                }
                for (int row = counter; row < wall.Length; row++)
                {
                    wall[row][col] = finalCols.Dequeue();
                }
            }

            Print(wall);
        }

        private static void PrintQueue(Queue<char>[] finalCols)
        {
            for (int rows = 0; rows < finalCols.Length; rows++)
            {
                Console.WriteLine(String.Join(" ", finalCols[rows]));
            }
        }

        private static int FillWithSnakes(string snake, int snakeCounter, char[] rowOfWall, int col)
        {
            if (snakeCounter > snake.Length - 1)
            {
                snakeCounter = 0;
            }
            rowOfWall[col] = snake[snakeCounter];
            snakeCounter++;
            return snakeCounter;
        }

        private static void Print(char[][] wall)
        {
            for (int rows = 0; rows < wall.Length; rows++)
            {
                Console.WriteLine(String.Join("", wall[rows]));
            }
        }
    }
}
