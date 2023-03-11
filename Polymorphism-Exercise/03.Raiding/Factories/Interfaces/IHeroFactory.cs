using _03.Raiding.Models.Interfaces;

namespace _03.Raiding.Factories.Interfaces;

public interface IHeroFactory
{
    IBaseHero Create(string type, string name);
}
