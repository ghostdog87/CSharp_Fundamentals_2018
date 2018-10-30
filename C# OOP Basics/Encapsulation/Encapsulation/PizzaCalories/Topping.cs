using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppingType;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    string type = char.ToUpper(this.ToppingType[0]) + this.ToppingType.Substring(1);
                    throw new ArgumentException($"{type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public string ToppingType
        {
            get { return toppingType; }
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value;
            }
        }

        public double ToppingCalories { get => CalcCalories(); }

        private double CalcCalories()
        {
            double toppingModifier = 0;

            switch (this.ToppingType.ToLower())
            {
                case "meat":
                    toppingModifier = 1.2;
                    break;
                case "veggies":
                    toppingModifier = 0.8;
                    break;
                case "cheese":
                    toppingModifier = 1.1;
                    break;
                case "sauce":
                    toppingModifier = 0.9;
                    break;
                default:
                    break;
            }

            return this.Weight * toppingModifier * 2;
        }
    }
}
