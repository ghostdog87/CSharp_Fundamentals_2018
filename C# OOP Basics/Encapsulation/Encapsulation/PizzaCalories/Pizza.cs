using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            Toppings = new List<Topping>();
        }

        public string Name {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public Dough Dough { get => dough; set => dough = value; }
        private List<Topping> Toppings {
            get => toppings;
            set
            {               
                toppings = value;
            }
        }

        public void AddToppings(Topping topping)
        {
            this.Toppings.Add(topping);
            if (this.Toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }

    }
}
