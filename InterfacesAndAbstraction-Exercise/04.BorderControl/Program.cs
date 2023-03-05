using _04.BorderControl.Models;
using _04.BorderControl.Models.Interfaces;

List<IInformationonal> entered = new();


string input;

while ((input = Console.ReadLine()) != "End")
{
    string[] inputInfo = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (inputInfo.Length == 3)
    {
        Citizen citizen = new(inputInfo[0], int.Parse(inputInfo[1]), inputInfo[2]);

        entered.Add(citizen);
    }
    else
    {
        Robot robot = new(inputInfo[0], inputInfo[1]);

        entered.Add(robot);
    }
}

string digitsOfFakeId = Console.ReadLine();

foreach (var element in entered)
{
    if (element.Id.EndsWith(digitsOfFakeId))
    {
        Console.WriteLine(element.Id);
    }
}