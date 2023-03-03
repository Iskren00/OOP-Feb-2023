using PizzaCalories.Models;

try
{
    string[] pizzaName = Console.ReadLine()
        .Split(" ");

    Pizza pizza = new(pizzaName[1]);

    string[] inputOfDough = Console.ReadLine()
        .Split(" ");

    string flourType = inputOfDough[1];
    string bakingTechnique = inputOfDough[2];
    int grams = int.Parse(inputOfDough[3]);

    Dough dough = new(flourType, bakingTechnique, grams);

    string input;

    while ((input = Console.ReadLine()) != "END")
    {

        string[] typeOfTopping = input
            .Split(" ");


        string toppingName = typeOfTopping[1];
        int gramsOfTopping = int.Parse(typeOfTopping[2]);

        Topping topping = new(toppingName, gramsOfTopping);

        pizza.AddTopping(topping);
    }

        Console.WriteLine($"{pizza.Name} - {pizza.SumOfTotalCalorie(dough):f2} Calories.");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);

    return;
}