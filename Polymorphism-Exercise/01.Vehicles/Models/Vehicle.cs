using _01.Vehicles.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double increas;
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double increas)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            this.increas = increas;
        }

        public double FuelQuantity {
            get => fuelQuantity;
            private set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption { get; private set; }

        public double TankCapacity { get; private set; }

        public string Drive(double distance)
        {
            double sum = FuelConsumption + increas;
            sum = sum * distance;

            if (sum > FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= sum;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public string Drive(double distance, string empty)
        {
            double sum = FuelConsumption * distance;

            if (sum > FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= sum;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters) 
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (FuelQuantity + liters > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            FuelQuantity += liters;
        }


        public override string ToString()
        {
            return $"{this.GetType().Name}: {fuelQuantity:f2}";
        }
    }
}
