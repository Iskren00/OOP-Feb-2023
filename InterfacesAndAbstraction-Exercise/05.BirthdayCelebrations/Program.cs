using _04.BorderControl.Models;
using _04.BorderControl.Models.Interfaces;
using _05.BirthdayCelebrations.Models;

List<IBirthable> entered = new();


string input;

while ((input = Console.ReadLine()) != "End")
{
    string[] inputInfo = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string type = inputInfo[0];

    switch (type)
    {
        case "Citizen":
            Citizen citizen = new(inputInfo[1], int.Parse(inputInfo[2]), inputInfo[3], inputInfo[4]);

            entered.Add(citizen);
            break;
        case "Robot":
            Robot robot = new(inputInfo[1], inputInfo[2]);
            break;
        case "Pet":
            Pet pet = new(inputInfo[1], inputInfo[2]);

            entered.Add(pet);
            break;
    }
}

string yearOfBirth = Console.ReadLine();

foreach (var element in entered)
{
    if (element.Birthdate.EndsWith(yearOfBirth))
    {
        Console.WriteLine(element.Birthdate);
    }
}
