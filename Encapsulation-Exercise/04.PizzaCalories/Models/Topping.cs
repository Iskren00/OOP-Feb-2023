namespace PizzaCalories.Models;

public class Topping
{
    private const double Meat = 1.2;
    private const double Veggies  = 0.8;
    private const double Cheese = 1.1;
    private const double Sauce = 0.9;
    private const int CaloriesPerGram = 2;

    private int grams;
    private string typeName;

    public Topping(string typeOfTopping, int grams)
    { 
      string copy = typeOfTopping.ToUpper();

        switch (copy)
        {
            case "MEAT":
                TypeOfTopping = Meat;
                typeName = "Meat";
                break;
            case "VEGGIES":
                TypeOfTopping = Veggies;
                typeName = "Veggies";
                break;
            case "CHEESE":
                TypeOfTopping = Cheese;
                typeName = "Cheese";
                break;
            case "SAUCE":
                TypeOfTopping = Sauce;
                typeName = "Sauce";
                break;
            default:
                throw new ArgumentException($"Cannot place {typeOfTopping} on top of your pizza.");
                break;
        }


        Grams = grams;
    }
    public double TypeOfTopping { get; private set; }
    public int Grams
    {
        get => grams;
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{typeName} weight should be in the range [1..50].");
            }

            grams = value;
        }
    }

    public double ToppingCalories()
    {
        double sumOfCalories = CaloriesPerGram * TypeOfTopping * Grams;

        return sumOfCalories;
    }

}
