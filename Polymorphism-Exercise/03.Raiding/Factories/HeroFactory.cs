using _03.Raiding.Factories.Interfaces;
using _03.Raiding.Models;
using _03.Raiding.Models.Interfaces;

namespace VehiclesExtension.Factories;

public class HeroFactory : IHeroFactory
{
    public IBaseHero Create(string type, string name)
    {
        switch (type)
        {
            case "Druid":
                return new Druid(name);
            case "Paladin":
                return new Paladin(name);
            case "Rogue":
                return new Rogue(name);
            case "Warrior":
                return new Warrior(name);
            default:
                throw new ArgumentException("Invalid hero!");
        }
    }
}