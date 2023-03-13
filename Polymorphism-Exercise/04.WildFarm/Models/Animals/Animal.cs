using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Models.Animals;

public abstract class Animal : IAnimal
{

    public Animal(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }
    public string Name { get; private set; }

    public double Weight { get; internal set; }

    public int FoodEaten { get; internal set; }

    public abstract void Feed(IFood food);

    public abstract string Sound();

}
