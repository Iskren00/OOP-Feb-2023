using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Models.Animals;

public abstract class Bird : Animal
{
    protected Bird(string name, double weight, double wingSize) 
        : base(name, weight)
    {
        WingSize = wingSize;
    }

    public double WingSize { get; private set; }

    public override string ToString()
    {
        return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
    }
    
}
