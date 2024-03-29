﻿using _01.Vehicles.Models.Interfaces;

namespace _01.Vehicles.Models;

public class Car : Vehicle
{

    private const double Increas = 0.9;

    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
        : base(fuelQuantity, fuelConsumption, tankCapacity, Increas)
    {
    }
}
