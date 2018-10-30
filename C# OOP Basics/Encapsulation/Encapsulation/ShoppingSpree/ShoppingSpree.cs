using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class ShoppingSpree
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();
            string[] inputPersons = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < inputPersons.Length; i++)
            {
                // might be wrong to remove empty entries
                string[] currentPerson = inputPersons[i].Split("=");
                string currentName = currentPerson[0];
                decimal currentMoney = decimal.Parse(currentPerson[1]);
                Person person = new Person(currentName, currentMoney);
                persons.Add(person);
                
            }

            string[] inputProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < inputProducts.Length; i++)
            {
                // might be wrong to remove empty entries
                string[] currentProduct = inputProducts[i].Split("="); 
                string currentName = currentProduct[0];
                decimal currentCost = decimal.Parse(currentProduct[1]);
                Product product = new Product(currentName, currentCost);
                products.Add(product);            
            }

            string commands = Console.ReadLine();

            while (commands != "END")
            {
                string[] currentInput = commands.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string personName = currentInput[0];
                string productName = currentInput[1];

                Product product = products.FirstOrDefault(x => x.Name == productName);
                Person person = persons.FirstOrDefault(x => x.Name == personName);

                if (person.Money >= product.Cost)
                {
                    person.Money -= product.Cost;
                    person.BagOfProducts.Add(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }

                commands = Console.ReadLine();
            }
            
            foreach (Person person in persons)
            {
                if (person.BagOfProducts.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - " + string.Join(", ",person.BagOfProducts.Select(x => x.Name)));
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }
}
