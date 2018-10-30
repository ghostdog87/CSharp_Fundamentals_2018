using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise7
{
    class LegoBlocks
    {
        static void Main(string[] args)
        {
            int numberOfArr = int.Parse(Console.ReadLine());

            int[][] jagged1 = new int[numberOfArr][];
            int[][] jagged2 = new int[numberOfArr][];

            for (int i = 0; i < numberOfArr; i++)
            {

                int[] arr1 = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jagged1[i] = arr1;
            }
            for (int i = 0; i < numberOfArr; i++)
            {

                int[] arr2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jagged2[i] = arr2;
            }

            //Print(jagged1);
            //Print(jagged2);

            for (int row = 0; row < jagged2.Length; row++)
            {
                jagged2[row] = jagged2[row].Reverse().ToArray();
            }
            //Print(jagged2);

            Queue<int>[] jaggedFinal = new Queue<int>[numberOfArr];

            int maxCounter = 0;
            int countOfElements = 0;
            bool isValidJagged = true;

            for (int row = 0; row < numberOfArr; row++)
            {
                Queue<int> currentJagged = new Queue<int>();
                int counter = 0;

                for (int col = 0; col < jagged1[row].Length; col++)
                {
                    currentJagged.Enqueue(jagged1[row][col]);
                    Increasing(ref countOfElements, ref counter);
                }

                for (int col = 0; col < jagged2[row].Length; col++)
                {
                    currentJagged.Enqueue(jagged2[row][col]);
                    Increasing(ref countOfElements, ref counter);
                }

                if (row == 0)
                {
                    maxCounter = counter;
                }
                else if (maxCounter != counter)
                {
                    isValidJagged = false;
                }
                jaggedFinal[row] = currentJagged;

            }
            if (isValidJagged)
            {
                Print2(jaggedFinal);
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {countOfElements}");
            }
            

        }

        private static void Increasing(ref int countOfElements, ref int counter)
        {
            counter++;
            countOfElements++;
        }

        private static void Print2(Queue<int>[] jagged)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine("[" + String.Join(", ", jagged[row]) + "]");
            }
        }

        private static void Print(int[][] jagged)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine(String.Join(" ", jagged[row]));
            }
        }
    }
}
