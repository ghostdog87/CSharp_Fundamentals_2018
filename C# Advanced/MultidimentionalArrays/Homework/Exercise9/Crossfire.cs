using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise9
{
    class Crossfire
    {
        static List<List<int>> field;

        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int dimension1 = input[0];
            int dimension2 = input[1];

            field = new List<List<int>>();

            int counter = 1;

            for (int row = 0; row < dimension1; row++)
            {
                List<int> fieldRow = new List<int>();
                for (int col = 0; col < dimension2; col++)
                {
                    fieldRow.Add(counter);
                    counter++;
                }
                field.Add(fieldRow);
            }

            //Print();

            string blast = Console.ReadLine();

            while (blast != "Nuke it from orbit")
            {
                int[] coordinates = blast.Split().Select(int.Parse).ToArray();
                int targetRow = coordinates[0];
                int targetCol = coordinates[1];
                int radius = coordinates[2];

                for (int row = targetRow - radius; row <= radius + targetRow; row++)
                {
                    if (IsInside(row, targetCol))
                    {
                        field[row][targetCol] = 0;
                    }
                }

                for (int col = targetCol - radius; col <= radius + targetCol; col++)
                {
                    if (IsInside(targetRow, col))
                    {
                        field[targetRow][col] = 0;
                    }
                }

                //Print();

                for (int row = 0; row < field.Count; row++)
                {
                    field[row].RemoveAll(x => x == 0);
                    
                }
                field.RemoveAll(x => x.Count == 0);


                blast = Console.ReadLine();
            }

            

            Print();

        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < field.Count && col >= 0 && col < field[row].Count;
        }

        private static void Print()
        {
            for (int row = 0; row < field.Count; row++)
            {
                Console.WriteLine(string.Join(" ", field[row]));
            }
        }
    }
}
