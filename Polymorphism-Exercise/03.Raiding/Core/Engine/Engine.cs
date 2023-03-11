using _03.Raiding.Core.Interfaces;
using _03.Raiding.Factories.Interfaces;
using _03.Raiding.Models.Interfaces;
using VehiclesExtension.Factories;

namespace _03.Raiding.Core.Engine;

public class Engine : IEngine
{
    public void Run()
    {
        List<IBaseHero> heroes = new();
        IHeroFactory heroFactory = new HeroFactory();

        int n = int.Parse(Console.ReadLine());

        while (n > 0)
        {
            string name = Console.ReadLine();
            string type = Console.ReadLine();

            try
            {
                heroes.Add(heroFactory.Create(type, name));
                n--;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        int bossPower = int.Parse(Console.ReadLine());
        int powerSum = 0;

        foreach (var hero in heroes)
        {
            Console.WriteLine(hero.CastAbility());

            powerSum += hero.Power;
        }

        if (powerSum >= bossPower)
        {
            Console.WriteLine("Victory!");
        }
        else
        {
            Console.WriteLine("Defeat...");
        }
    }
}

