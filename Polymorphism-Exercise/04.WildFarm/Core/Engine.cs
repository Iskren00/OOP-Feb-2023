using _04.WildFarm.Core.Interfaces;
using _04.WildFarm.Models.Animals;
using _04.WildFarm.Models.Foods;
using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string animalInput;
            List<IAnimal> animals = new();

            while ((animalInput = Console.ReadLine()) != "End")
            {
                string[] animalArg = animalInput
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = animalArg[0];
                string name = animalArg[1];
                double weight = double.Parse(animalArg[2]);

                string[] foodArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string foodName = foodArg[0];
                int quantity = int.Parse(foodArg[1]);
                Stack<IFood> foods = new();
                IAnimal animal;

                if (foodName == "Vegetable")
                {
                    IFood food = new Vegetable(quantity);

                    foods.Push(food);
                }
                else if (foodName == "Fruit")
                {
                    IFood food = new Fruit(quantity);

                    foods.Push(food);
                }
                else if (foodName == "Meat")
                {
                    IFood food = new Meat(quantity);

                    foods.Push(food);
                }
                else if (foodName == "Seeds")
                {
                    IFood food = new Seeds(quantity);

                    foods.Push(food);
                }

                try
                {
                    if (type == "Owl")
                    {
                        double wingSize = double.Parse(animalArg[3]);

                        animal = new Owl(name, weight, wingSize);
                        animals.Add(animal);

                        Console.WriteLine(animal.Sound());
                        animal.Feed(foods.Pop());
                    }
                    else if (type == "Hen")
                    {
                        double wingSize = double.Parse(animalArg[3]);

                        animal = new Hen(name, weight, wingSize);
                        animals.Add(animal);

                        Console.WriteLine(animal.Sound());
                        animal.Feed(foods.Pop());
                    }
                    else if (type == "Mouse")
                    {
                        string livingRegion = animalArg[3];

                        animal = new Mouse(name, weight, livingRegion);
                        animals.Add(animal);

                        Console.WriteLine(animal.Sound());
                        animal.Feed(foods.Pop());
                    }
                    else if (type == "Dog")
                    {
                        string livingRegion = animalArg[3];

                        animal = new Dog(name, weight, livingRegion);
                        animals.Add(animal);

                        Console.WriteLine(animal.Sound());
                        animal.Feed(foods.Pop());
                    }
                    else if (type == "Cat")
                    {
                        string livingRegion = animalArg[3];
                        string breed = animalArg[4];

                        animal = new Cat(name, weight, livingRegion, breed);
                        animals.Add(animal);

                        Console.WriteLine(animal.Sound());
                        animal.Feed(foods.Pop());
                    }
                    else if (type == "Tiger")
                    {
                        string livingRegion = animalArg[3];
                        string breed = animalArg[4];

                        animal = new Tiger(name, weight, livingRegion, breed);
                        animals.Add(animal);

                        Console.WriteLine(animal.Sound());
                        animal.Feed(foods.Pop());
                    }

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
