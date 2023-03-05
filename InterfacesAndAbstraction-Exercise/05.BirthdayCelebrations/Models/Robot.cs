using _04.BorderControl.Models.Interfaces;

namespace _04.BorderControl.Models;

public class Robot : IInformationonal
{
    public Robot(string name, string id)
    {
        Name = name;
        Id = id;
    }

    public string Name { get; private set; }

    public string Id { get; private set; }
}