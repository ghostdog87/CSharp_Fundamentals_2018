using System;

namespace _09_CustomListIterator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //•	Add < element > -Adds the given element to the end of the list
            //•	Remove < index > -Removes the element at the given index
            //•	Contains < element > -Prints if the list contains the given element(True or False)
            //•	Swap<index> < index > -Swaps the elements at the given indexes
            //•	Greater < element > -Counts the elements that are greater than the given element and prints their count
            //•	Max - Prints the maximum element in the list
            //•	Min - Prints the minimum element in the list
            //•	Print - Prints all of the elements in the list, each on a separate line
            //•	END - stops the reading of commands

            CustomList<string> list = new CustomList<string>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArgs = input.Split();
                string command = inputArgs[0];
                string element = string.Empty;
                int index = 0;

                switch (command)
                {
                    case "Add":
                        element = inputArgs[1];
                        list.Add(element);
                        break;
                    case "Remove":
                        index = int.Parse(inputArgs[1]);
                        list.Remove(index);
                        break;
                    case "Contains":
                        element = inputArgs[1];
                        Console.WriteLine(list.Contains(element));
                        break;
                    case "Swap":
                        int index1 = int.Parse(inputArgs[1]);
                        int index2 = int.Parse(inputArgs[2]);
                        list.Swap(index1, index2);
                        break;
                    case "Greater":
                        element = inputArgs[1];
                        Console.WriteLine(list.CountGreaterThan(element));
                        break;
                    case "Max":
                        Console.WriteLine(list.Max());
                        break;
                    case "Min":
                        Console.WriteLine(list.Min());
                        break;
                    case "Print":
                        foreach (var item in list)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case "Sort":
                        list.Sort();
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
