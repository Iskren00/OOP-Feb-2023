using ShoppingSpree.Models;

List<Person> people = new();
List<Product> products = new();

string[] peopleInfo = Console.ReadLine()
    .Split(";", StringSplitOptions.RemoveEmptyEntries);


try
{
    for (int i = 0; i < peopleInfo.Length; i++)
    {
        string[] input = peopleInfo[i]
            .Split("=", StringSplitOptions.RemoveEmptyEntries);

        Person person = new(input[0], decimal.Parse(input[1]));

        people.Add(person);
    }

    string[] productsInfo = Console.ReadLine()
        .Split(";", StringSplitOptions.RemoveEmptyEntries);

    for (int i = 0; i < productsInfo.Length; i++)
    {
        string[] input = productsInfo[i]
            .Split("=", StringSplitOptions.RemoveEmptyEntries);

        Product product = new(input[0], decimal.Parse(input[1]));

        products.Add(product);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}

string command;

while ((command = Console.ReadLine()) != "END")
{
    string[] arg = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    foreach (var person in people)
    {
        if (person.Name == arg[0])
        {
            person.CanBuyIt(arg[1], products);
        }
    }
}

foreach (var person in people)
{
    person.PrintPerson();
}