using _04.BorderControl.Models;
using _06.FoodShortage.Models;
using _06.FoodShortage.Models.Interfaces;

List<IInformationonal> buyers = new List<IInformationonal>();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (input.Length == 4)
    {
        Citizen citizen = new(input[0], int.Parse(input[1]), input[2], input[3]);

        buyers.Add(citizen);
    }
    else
    {
        Rebel rebel = new(input[0], int.Parse(input[1]), input[2]);

        buyers.Add(rebel);
    }
}

string name;
int sum = 0;

while ((name = Console.ReadLine()) != "End")
{
    foreach (var buyer in buyers)
    {
        if (buyer.Name == name)
        {
            sum += buyer.BuyFood();
        }
    }
}

Console.WriteLine(sum);