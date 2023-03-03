namespace ShoppingSpree.Models;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> products;

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        products = new List<Product>();
    }
    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            name = value;
        }
    }

    public decimal Money
    {
        get => money;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            money = value;
        }
    }

    public void CanBuyIt(string productName, List<Product> items)
    {
        foreach (var item in items)
        {
            if (productName == item.Name)
            {
                if (Money < item.Cost)
                {
                    Console.WriteLine($"{Name} can't afford {productName}");

                    break;
                }

                products.Add(item);

                Money -= item.Cost;

                Console.WriteLine($"{Name} bought {productName}");
            }
        }
    }

    public void PrintPerson()
    {
        if (products.Any())
        {
        Console.WriteLine($"{Name} - {string.Join(", ", products)}");
        }
        else
        {
            Console.WriteLine($"{Name} - Nothing bought");
        }

    }

}
