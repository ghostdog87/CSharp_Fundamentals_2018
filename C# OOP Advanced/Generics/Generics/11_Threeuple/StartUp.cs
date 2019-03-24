using System;

namespace _11_Threeuple
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
            string town = inputArgs1[3];

            string[] inputArgs2 = Console.ReadLine().Split();
            string name = inputArgs2[0];
            int beers = int.Parse(inputArgs2[1]);
            bool drunk = inputArgs2[2] == "drunk" ? true : false;

            string[] inputArgs3 = Console.ReadLine().Split();
            string name2 = inputArgs3[0];
            double balance = double.Parse(inputArgs3[1]);
            string bankName = inputArgs3[2];

            Threeuple<string, string, string> tuple1 = new Threeuple<string, string, string>(fullName, address, town);
            Threeuple<string, int, bool> tuple2 = new Threeuple<string, int, bool>(name, beers, drunk);
            Threeuple<string, double, string> tuple3 = new Threeuple<string, double, string>(name2, balance, bankName);

            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}
