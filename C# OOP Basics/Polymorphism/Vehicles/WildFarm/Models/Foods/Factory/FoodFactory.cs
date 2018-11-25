using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Foods.Factory
{
    public class FoodFactory
    {
        public Food CreateFood(string foodType, int quantity)
        {
            foodType = foodType.ToLower();

            switch (foodType)
            {
                case "fruit":
                    return new Fruit(quantity);
                case "meat":
                    return new Meat(quantity);
                case "seeds":
                    return new Seeds(quantity);
                case "vegetable":
                    return new Vegetable(quantity);
                default:
                    throw new ArgumentException("Bad food input!");
            }
        }
    }
}
