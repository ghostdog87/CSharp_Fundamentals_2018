﻿using GenericBoxОfString;
using System;

namespace Generics
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string item = Console.ReadLine();
                Box<string> box = new Box<string>(item);
                Console.WriteLine(box);
            }
        }
    }
}
