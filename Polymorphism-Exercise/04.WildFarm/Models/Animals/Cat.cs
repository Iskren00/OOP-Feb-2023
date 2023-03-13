using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Models.Animals;

public class Cat : Feline
{
    private const double Increase = 0.30;
    public Cat(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {
    }

    public override void Feed(IFood food)
    {
        if (food.Name == "Vegetable" || food.Name == "Meat")
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
        return "Meow";
    }
}
