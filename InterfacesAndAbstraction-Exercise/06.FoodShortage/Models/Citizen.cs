﻿using _06.FoodShortage.Models.Interfaces;

namespace _04.BorderControl.Models;

public class Citizen : IInformationonal, IBirthable
{
    public Citizen(string name, int age, string id, string birthdate)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthdate = birthdate;
        Food = 0;
    }
    public string Name { get; private set; }

    public int Age { get; private set; }

    public string Id { get; private set; }

    public string Birthdate { get; private set; }
    public int Food { get; private set; }
    public int BuyFood()
    {
        return 10;
    }
}
