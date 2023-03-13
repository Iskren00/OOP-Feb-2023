using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Models.Animals;

public class Hen : Bird
{
    private const double Increase = 0.35;

    public Hen(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {
    }

    public override string Sound()
    {
        return "Cluck";
    }

    public override void Feed(IFood food)
    {
        double increaseFood = food.Quantity * Increase;
        Weight += increaseFood;
        FoodEaten = food.Quantity;
    }
}
