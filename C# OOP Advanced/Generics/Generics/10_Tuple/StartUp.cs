using System;
using System.Collections.Generic;

namespace _10_Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Sofka Tripova Stolipinovo
            //Az 2
            //23 21.23212321

            string[] inputArgs1 = Console.ReadLine().Split();
            string fullName = inputArgs1[0] + " " + inputArgs1[1];
            string address = inputArgs1[2];

            string[] inputArgs2 = Console.ReadLine().Split();
            string name = inputArgs2[0];
            int beers = int.Parse(inputArgs2[1]);

            string[] inputArgs3 = Console.ReadLine().Split();
            int someInt = int.Parse(inputArgs3[0]);
            double someDouble = double.Parse(inputArgs3[1]);

            CustomTuple<string, string> tuple1 = new CustomTuple<string, string>(fullName, address);
            CustomTuple<string, int> tuple2 = new CustomTuple<string, int>(name, beers);
            CustomTuple<int, double> tuple3 = new CustomTuple<int, double>(someInt, someDouble);

            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}
