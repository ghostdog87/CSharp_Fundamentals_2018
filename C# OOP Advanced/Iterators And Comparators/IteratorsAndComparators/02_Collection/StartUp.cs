﻿using System;
using System.Linq;

namespace _02_Collection
{
    public class StartUp
    {
        static ListyIterator<string> customList;

        public static void Main(string[] args)
        {
            string[] inputArgs = Console.ReadLine().Split();

            string command = inputArgs[0];

            try
            {
                while (command != "END")
                {
                    switch (command)
                    {
                        case "Create":
                            customList = new ListyIterator<string>(inputArgs.Skip(1).ToArray());
                            break;
                        case "Move":
                            Console.WriteLine(customList.Move());
                            break;
                        case "Print":
                            customList.Print();
                            break;
                        case "HasNext":
                            Console.WriteLine(customList.HasNext());
                            break;
                        case "PrintAll":
                            foreach (var item in customList)
                            {
                                Console.Write(item + " ");
                            }
                            Console.WriteLine();
                            break;
                        default:
                            break;
                    }

                    inputArgs = Console.ReadLine().Split();
                    command = inputArgs[0];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
