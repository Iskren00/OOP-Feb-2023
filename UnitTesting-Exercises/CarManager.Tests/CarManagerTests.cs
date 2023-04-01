namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        Car privateCar = new("VW", "Bora", 3, 50);

        [Test]
        public void BuildACar()
        {
            Car car = new("Opel", "Astra", 4, 60);

            Assert.AreEqual("Opel", car.Make);
            Assert.AreEqual("Astra", car.Model);
            Assert.AreEqual(4, car.FuelConsumption);
            Assert.AreEqual(60, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CarMakeThrowException(string make)
        {
            Car car;

            ArgumentException exception = Assert.Throws<ArgumentException>(() => car = new(make, "Astra", 4, 60));

            Assert.AreEqual(exception.Message, "Make cannot be null or empty!");
        }

        [TestCase("")]
        [TestCase(null)]
        public void CarModelThrowException(string model)
        {
            Car car;

            ArgumentException exception = Assert.Throws<ArgumentException>(() => car = new("Opel", model, 4, 60));

            Assert.AreEqual(exception.Message, "Model cannot be null or empty!");
        }

        [TestCase(-43)]
        [TestCase(0)]
        [TestCase(-2)]
        public void CarFuelConsumtionThrowException(double fuelConsumption)
        {
            Car car;

            ArgumentException exception = Assert.Throws<ArgumentException>(() 
                => car = new("Opel", "Astra", fuelConsumption, 60));

            Assert.AreEqual(exception.Message, "Fuel consumption cannot be zero or negative!");
        }

        [TestCase(-43)]
        [TestCase(0)]
        [TestCase(-2)]
        public void CarFuelCapacityThrowException(double fuelCapacity)
        {
            Car car;

            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => car = new("Opel", "Astra", 4, fuelCapacity));

            Assert.AreEqual(exception.Message, "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        public void RefuelMethodTest()
        {
            privateCar.Refuel(60);

            Assert.AreEqual(50, privateCar.FuelAmount);
        }

        [TestCase(-23)]
        [TestCase(0)]
        [TestCase(-3)]
        public void RefuelMethodThrowException(double fuelToRefuel)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => privateCar.Refuel(fuelToRefuel));

            Assert.AreEqual(exception.Message, "Fuel amount cannot be zero or negative!");
        }

        [Test]
        public void DriveMethodTest()
        {
            privateCar.Refuel(50);

            privateCar.Drive(100);

            Assert.AreEqual(47, privateCar.FuelAmount);
        }

        [Test]
        public void DriveMethodThrowException()
        {
            privateCar.Refuel(50);       

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => privateCar.Drive(100000000));

            Assert.AreEqual(exception.Message, "You don't have enough fuel to drive!");
        }
    }
}