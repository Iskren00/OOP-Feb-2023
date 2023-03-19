using ValidationAttributes.Attributes;

namespace ValidationAttributes.Core;

public class Person
{
    private const int MinValue = 12;
    private const int MaxValue = 90;

    public Person(string fullName , int age)
    {
        FullName = fullName;
        Age = age;
    }

    [MyRequired]
    public string FullName { get; private set; }

    [MyRange(MinValue, MaxValue)]
    public int Age { get; private set; }

}
