﻿namespace _04.WildFarm.Models.Interfaces;

public interface IAnimal
{
    string Name { get; }
    double Weight { get; }
    int FoodEaten { get; }

    string Sound();

    void Feed(IFood food);
}
