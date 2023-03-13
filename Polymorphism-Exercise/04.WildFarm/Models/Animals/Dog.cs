using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Models.Animals;

public class Dog : Mammal
{
    private const double Increase = 0.40;
    public Dog(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
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
        return "Woof!";
    }

    public override string ToString()
    {
        return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
