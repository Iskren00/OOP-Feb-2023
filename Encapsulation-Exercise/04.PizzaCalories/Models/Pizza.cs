namespace PizzaCalories.Models;

public class Pizza
{
	private List<Topping> toppings;
	private string name;

	public Pizza(string name)
	{
		Name = name;
		toppings = new List<Topping>();
	}
	public string Name 
	{
		get => name;
		private set
		{
			if (string.IsNullOrEmpty(value) || value.Length > 15)
			{
				throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
			}

			name = value;
		} 
	}

	public int NumberOfToppings { get => toppings.Count; }

	public int TotalCalories { get; private set; }

	public void AddTopping(Topping topping)
	{
		if (toppings.Count >= 10)
		{
			throw new ArgumentException("Number of toppings should be in range [0..10].");
		}

		toppings.Add(topping);

		
	}

	public double SumOfTotalCalorie(Dough dough)
	{
		double sum = dough.DoughCalories();

		foreach (var topping in toppings)
		{
			sum += topping.ToppingCalories();
		}
		
		return sum;
	}
}
