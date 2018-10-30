using System;

namespace Exercise5
{
    class RubiksMatrix
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);
            int[][] matrix = new int[rows][];
         
            int currentNum = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                int[] innerCols = new int[cols];
                for (int col = 0; col < cols; col++)
                {
                    innerCols[col] = currentNum;
                    matrix[row] = innerCols;
                    currentNum++;
                }
            }

            //Print(matrix);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] currentInput = Console.ReadLine().Split();
                int position = int.Parse(currentInput[0]);
                string direction = currentInput[1];
                int moves = int.Parse(currentInput[2]);

                switch (direction)
                {
                    case "left":
                        MoveLeft(matrix, position, moves % matrix[position].Length);
                        break;
                    case "right":
                        MoveRight(matrix, position, moves % matrix[position].Length);
                        break;
                    case "up":
                        MoveUp(matrix, position, moves % matrix.Length);
                        break;
                    case "down":
                        MoveDown(matrix, position, moves % matrix.Length);
                        break;
                    default:
                        break;
                }
            }

            //Print(matrix);

            int counter = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == counter)
                    {
                        Console.WriteLine("No swap required");                       
                    }
                    else
                    {
                        RearrangeMatrix(matrix, row, col, counter);
                    }
                    counter++;
                }
            }
        }

        private static void RearrangeMatrix(int[][] matrix, int row, int col, int counter)
        {
            for (int targetRow = 0; targetRow < matrix.Length; targetRow++)
            {
                for (int targetCol = 0; targetCol < matrix[targetRow].Length; targetCol++)
                {
                    if (matrix[targetRow][targetCol] == counter)
                    {
                        matrix[targetRow][targetCol] = matrix[row][col];
                        matrix[row][col] = counter;
                        Console.WriteLine($"Swap ({row}, {col}) with ({targetRow}, {targetCol})");
                        return;
                    }
                }
            }
        }

        private static void MoveDown(int[][] matrix, int position, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int lastElement = matrix[matrix.Length - 1][position];
                for (int row = matrix.Length - 1; row > 0; row--)
                {
                    matrix[row][position] = matrix[row - 1][position];
                }
                matrix[0][position] = lastElement;
            }

            //Print(matrix);
        }

        private static void MoveUp(int[][] matrix, int position, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int firstElement = matrix[0][position];
                for (int row = 0; row < matrix.Length - 1; row++)
                {
                    matrix[row][position] = matrix[row + 1][position];
                }
                matrix[matrix.Length - 1][position] = firstElement;
            }
            //Print(matrix);
        }

        private static void MoveLeft(int[][] matrix, int position, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int firstElement = matrix[position][0];
                for (int col = 0; col < matrix[position].Length - 1; col++)
                {
                    matrix[position][col] = matrix[position][col + 1];
                }
                matrix[position][matrix[position].Length - 1] = firstElement;
            }

            //Print(matrix);
        }

        private static void MoveRight(int[][] matrix, int position, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int lastElement = matrix[position][matrix[position].Length - 1];
                for (int col = matrix[position].Length - 1; col > 0 ; col--)
                {
                    matrix[position][col] = matrix[position][col - 1];
                }
                matrix[position][0] = lastElement;
            }

            //Print(matrix);
        }

        private static void Print(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
