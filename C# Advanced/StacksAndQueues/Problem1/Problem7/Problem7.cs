using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem7
{
    class Problem7
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stackOfParanteses = new Stack<char>();

            char[] paranteses = { '[', '{', '(' };

            bool isValid = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (paranteses.Contains(input[i]))
                {
                    stackOfParanteses.Push(input[i]);
                    continue;
                }

                if (stackOfParanteses.Count == 0)
                {
                    Console.WriteLine("NO");
                    isValid = false;
                    break;
                }

                if (stackOfParanteses.Peek() == '[' && input[i] == ']')
                {
                    stackOfParanteses.Pop();
                }
                else if (stackOfParanteses.Peek() == '{' && input[i] == '}')
                {
                    stackOfParanteses.Pop();
                }
                else if (stackOfParanteses.Peek() == '(' && input[i] == ')')
                {
                    stackOfParanteses.Pop();
                }                    
            }

            if (stackOfParanteses.Count > 0)
            {
                Console.WriteLine("NO");
            }
            else if(isValid)
            {
                Console.WriteLine("YES");
            }
        }
    }
}
