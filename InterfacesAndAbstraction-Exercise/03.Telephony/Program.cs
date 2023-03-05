using _03.Telephony.Classes;
using _03.Telephony.Interfaces;

string[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] urls = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

ICallable callable;

foreach (var number in numbers)
{
    if (number.Length == 10)
    {
        callable = new Smartphone();
    }
    else
    {
        callable = new StationaryPhone();
    }

    try
    {
        Console.WriteLine(callable.Call(number));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

IBrowsable browsable = new Smartphone();

foreach (var url in urls)
{
    try
    {
        Console.WriteLine(browsable.Browse(url));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

