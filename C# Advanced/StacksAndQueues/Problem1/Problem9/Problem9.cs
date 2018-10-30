using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem9
{
    class Problem9
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            int N = int.Parse(Console.ReadLine());

            Stack<string> currentText = new Stack<string>();

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split();
                int command = int.Parse(input[0]);

                if (command == 1)
                {
                    
                    currentText.Push(text);
                    text += input[1];
                }
                else if (command == 2)
                {
                    int erase = int.Parse(input[1]);
                    currentText.Push(text);
                    text = text.Substring(0, text.Length - erase);
                }
                else if (command == 3)
                {
                    int position = int.Parse(input[1]);
                    Console.WriteLine(text[position - 1]);
                }
                else if (command == 4)
                {
                    text = currentText.Pop();
                }

            }

        }
    }
}
