﻿namespace _03.Raiding.Models;

public class Rogue : BaseHero
{
    private const int Power = 80;

    public Rogue(string name)
        : base(name, Power)
    {
    }

    public override string CastAbility()
        => $"{GetType().Name} - {Name} hit for {Power} damage";
}
