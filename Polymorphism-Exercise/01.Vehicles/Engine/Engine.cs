using _01.Vehicles.Engine.Interfaces;
using _01.Vehicles.Models;
using _01.Vehicles.Models.Interfaces;

namespace _01.Vehicles.Engine;

public class Engine : IEngine
{
    public void Run()
    {
        List<IVehicle> vehicles = new();

        string[] carInput = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        Car car = new(double.Parse(carInput[1]), double.Parse(carInput[2]), double.Parse(carInput[3]));

        string[] truckInput = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        Truck truck = new(double.Parse(truckInput[1]), double.Parse(truckInput[2]), double.Parse(truckInput[3]));

        string[] busInput = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        Bus bus = new(double.Parse(busInput[1]), double.Parse(busInput[2]), double.Parse(busInput[3]));

        vehicles.Add(car);
        vehicles.Add(truck);
        vehicles.Add(bus);

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = input[0];
            string vehicle = input[1];

            try
            {
                switch (command)
                {
                    case "Drive":
                        switch (vehicle)
                        {
                            case "Car":
                                Console.WriteLine(car.Drive(double.Parse(input[2])));
                                break;
                            case "Truck":
                                Console.WriteLine(truck.Drive(double.Parse(input[2])));
                                break;
                            case "Bus":
                                Console.WriteLine(bus.Drive(double.Parse(input[2])));
                                break;
                        }
                        break;
                    case "Refuel":
                        switch (vehicle)
                        {
                            case "Car":
                                car.Refuel(double.Parse(input[2]));
                                break;
                            case "Truck":
                                truck.Refuel(double.Parse(input[2]));
                                break;
                            case "Bus":
                                bus.Refuel(double.Parse(input[2]));
                                break;
                        }                       
                        break;
                    case "DriveEmpty":
                        Console.WriteLine(bus.Drive(double.Parse(input[2]), ""));
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle);
        }
    }
}