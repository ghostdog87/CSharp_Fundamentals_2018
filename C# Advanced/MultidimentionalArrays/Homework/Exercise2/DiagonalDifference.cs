using System;

namespace Exercise2
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, rows];

            for (int row = 0; row < rows; row++)
            {
                string[] rowInput = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries); 
                for (int col = 0; col < rows; col++)
                {
                    matrix[row, col] = int.Parse(rowInput[col]);
                }
            }

            int leftDiag = 0;
            int rightDiag = 0;

            int leftIndex = 0;
            int rightIndex = rows - 1;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < rows; col++)
                {
                    if (row == leftIndex && col == leftIndex)
                    {
                        leftDiag += matrix[row, col];
                        leftIndex++;
                    }
                    if (col == rightIndex)
                    {
                        rightDiag += matrix[row, col];
                        rightIndex--;
                    }
                }
            }

            Console.WriteLine(Math.Abs( leftDiag - rightDiag));
        }
    }
}
