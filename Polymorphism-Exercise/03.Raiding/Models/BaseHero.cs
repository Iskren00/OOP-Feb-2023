using _03.Raiding.Models.Interfaces;

namespace _03.Raiding.Models;

public abstract class BaseHero : IBaseHero
{
    public BaseHero(string name, int power)
    {
        Name = name;
        Power = power;
    }

    public string Name { get;  set; }
    public int Power { get; set; }

    public abstract string CastAbility();

}
