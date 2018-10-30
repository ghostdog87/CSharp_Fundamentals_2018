using System;

namespace Homework
{
    class ProgramMatrixOfPolindroms
    {
        static void Main(string[] args)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int counter = row;
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = (alphabet[row]).ToString() + (alphabet[counter]).ToString() + (alphabet[row]).ToString();
                    counter++;
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
