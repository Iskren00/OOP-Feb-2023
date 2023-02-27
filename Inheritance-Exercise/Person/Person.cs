using System.Net.Cache;
using System.Runtime.CompilerServices;

namespace Person;

public class Person
{
    private int age;
    public Person(string name, int age)
    {
        Name = name;

        if (age > 0)
        {
            Age = age;
        }
    }

    public string Name { get; set; }
    

    public virtual int Age 
    {
        get => age;

        set
        {
            if (value > 0)
            {
                age = value;
            }
        }
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}";
    }
}
