using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem5
{
    class Problem5
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();
            queue.Enqueue(input);
            long nextElement = queue.Peek();
            Console.Write($"{nextElement} ");

            for (int i = 1; i <= 50;)
            {
                nextElement = queue.Peek();               
                queue.Enqueue(nextElement + 1);
                Console.Write($"{nextElement + 1} ");
                i++;
                if (i == 50)
                {
                    break;
                }
                queue.Enqueue((nextElement * 2) + 1);
                Console.Write($"{(nextElement * 2) + 1} ");
                i++;
                if (i == 50)
                {
                    break;
                }
                queue.Enqueue(nextElement + 2);
                Console.Write($"{nextElement + 2} ");
                i++;
                if (i == 50)
                {
                    break;
                }
                queue.Dequeue();

            }
        }
    }
}
