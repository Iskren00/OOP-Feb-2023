namespace _01.Vehicles.Models;

public class Bus : Vehicle
{
    private const double Increas = 1.4;
    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
        : base(fuelQuantity, fuelConsumption, tankCapacity, Increas)
    {
    }  
}
