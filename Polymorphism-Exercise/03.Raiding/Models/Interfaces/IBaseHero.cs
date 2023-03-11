namespace _03.Raiding.Models.Interfaces;

public interface IBaseHero
{
    public string Name { get; }

    public int Power { get; }

    string CastAbility();
}
