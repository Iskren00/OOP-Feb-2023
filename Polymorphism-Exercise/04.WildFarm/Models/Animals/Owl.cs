using _04.WildFarm.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double Increase = 0.25;
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Feed(IFood food)
        {
            if (food.Name == "Meat")
            {
                double increaseFood = food.Quantity * Increase;
                Weight += increaseFood;
                FoodEaten = food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string Sound()
        {
            return "Hoot Hoot";
        }
    }
}
