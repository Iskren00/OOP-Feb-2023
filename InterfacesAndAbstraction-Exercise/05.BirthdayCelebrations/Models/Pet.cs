using _04.BorderControl.Models.Interfaces;

namespace _05.BirthdayCelebrations.Models;

public class Pet : IInformationonal, IBirthable
{
    public Pet(string name, string birthdate)
    {
        Name = name;
        Birthdate = birthdate;
    }

    public string Name { get; private set; }

    public string Birthdate { get; private set; }
}
