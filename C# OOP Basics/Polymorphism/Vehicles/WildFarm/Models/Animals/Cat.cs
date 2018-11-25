using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double increasedWeightByEating = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            if (!(food is Meat || food is Vegetable))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            this.FoodEaten += food.Quantity;
            this.Weight += increasedWeightByEating * food.Quantity;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
