﻿namespace _03.Raiding.Models;

public class Warrior : BaseHero
{
    private const int Power = 100;

    public Warrior(string name)
        : base(name, Power)
    {
    }

    public override string CastAbility()
        => $"{GetType().Name} - {Name} hit for {Power} damage";
}
