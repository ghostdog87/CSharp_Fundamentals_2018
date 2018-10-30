using System;

namespace PizzaCalories
{
    public class PizzaCalories
    {
        static void Main(string[] args)
        {
            
            double totalCalories = 0;

            string pizzaName = Console.ReadLine().Split()[1];

            try
            {
                Pizza pizza = new Pizza(pizzaName);

                string[] inputDough = Console.ReadLine().Split();
                string flourType = inputDough[1];
                string bakingTechnique = inputDough[2];
                double doughWeight = double.Parse(inputDough[3]);

                try
                {
                    Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
                    pizza.Dough = dough;
                    totalCalories += dough.DoughCalories;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }

                string inputTopping = Console.ReadLine();

                while (inputTopping != "END")
                {
                    string[] currentTopping = inputTopping.Split();
                    string toppingType = currentTopping[1];
                    double toppingWeight = double.Parse(currentTopping[2]);

                    try
                    {
                        Topping topping = new Topping(toppingType, toppingWeight);
                        pizza.AddToppings(topping);
                        totalCalories += topping.ToppingCalories;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Environment.Exit(0);
                    }

                    inputTopping = Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }

            Console.WriteLine("{0} - {1:f2} Calories.", pizzaName, totalCalories);
        }
    }
}
