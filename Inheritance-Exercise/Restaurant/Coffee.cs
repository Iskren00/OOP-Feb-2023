namespace Restaurant;

public class Coffee : HotBeverage
{
    private const decimal CoffeePrice = 3.50M;
    private const double CoffeeMilliliters = 50;
    public Coffee(string name, double coffeine) 
        : base(name, CoffeePrice, CoffeeMilliliters)
    {
        Caffeine = coffeine;
    }

    public double Caffeine { get; private set; }
}
