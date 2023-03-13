using _04.WildFarm.Models.Foods;
using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Models.Animals;

public class Mouse : Mammal
{
    private const double Increase = 0.10;
    public Mouse(string name, double weight, string livingRegion)
        : base(name, weight, livingRegion)
    {
    }

    public override void Feed(IFood food)
    {
        if (food.Name == "Vegetable" || food.Name == "Fruit")
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
        return "Squeak";
    }

    public override string ToString()
    {
        return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
