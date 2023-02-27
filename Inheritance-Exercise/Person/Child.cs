namespace Person;

public class Child : Person
{
    public Child(string name, int age) 
        : base(name, age)
    {
        if (age < 15)
        {
            Age = age;
        }
    }

    public override int Age 
    {
        get => base.Age;

        set
        {
            if (value <= 15)
            {
                base.Age = value;
            }
        }
    }
}
