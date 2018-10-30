using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.BagOfProducts = new List<Product>();
        }

        public List<Product> BagOfProducts
        {
            get { return bagOfProducts; }
            set { bagOfProducts = value; }
        }

        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    MoneyException();
                }
                money = value;
            }
        }

        private void MoneyException()
        {
            Exception ex = new ArgumentException("Money cannot be negative");
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    NameException();
                }
                name = value;
            }
        }

        private void NameException()
        {
            Exception ex = new ArgumentException("Name cannot be empty");
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }
    }
}
