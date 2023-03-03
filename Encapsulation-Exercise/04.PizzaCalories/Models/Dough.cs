namespace PizzaCalories.Models;

public class Dough
{
    private const double White = 1.5;
    private const double Wholegrain = 1.0;
    private const double Crispy = 0.9;
    private const double Chewy = 1.1;
    private const double Homemade = 1.0;
    private const int CaloriesPerGram = 2;

    private double flourType;
    private double bakingTechnique;
    private int grams;

    public Dough(string flourType, string bakingTechnique, int grams)
    {
        string copyFlour = flourType.ToLower();
        string copyBaking = bakingTechnique.ToLower();

        switch (copyFlour)
        {
            case "white":
                FlourType = White;
                break;
            case "wholegrain":
                FlourType = Wholegrain;
                break;
            default:
                throw new ArgumentException("Invalid type of dough.");
                break;
        }

        switch (copyBaking)
        {
            case "crispy":
                BakingTechnique = Crispy;
                break;
            case "chewy":
                BakingTechnique = Chewy;
                break;
            case "homemade":
                BakingTechnique = Homemade;
                break;
            default:
                throw new ArgumentException("Invalid type of dough.");
                break;
        }

        Grams = grams;
    }
    public double FlourType { get; private set; }

    public double BakingTechnique { get; private set; }

    public int Grams 
    {
        get => grams; 
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            grams = value;
        }
    }

    public double DoughCalories()
    {        
        double sumOfCalories = CaloriesPerGram * Grams * FlourType * BakingTechnique;

        return sumOfCalories;
    }
}
