namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        Warrior warrior1 = new("Mirka", 5, 50);
        Warrior warrior2 = new("Iskren", 10, 100);

        [Test]
        public void MakeArena()
        {
            Arena arena = new();

            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void EnrollMethodTest()
        {
            Arena arena = new();

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            Assert.AreEqual(2, arena.Count);
        }

        [Test]
        public void EnrollMethodThrowException()
        {
            Arena arena = new();

            arena.Enroll(warrior1);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior1));

            Assert.AreEqual(exception.Message, "Warrior is already enrolled for the fights!");
            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void FightMethodTest()
        {
            Arena arena = new();

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            arena.Fight("Iskren", "Mirka");

            Assert.AreEqual(warrior1.HP, 40);
            Assert.AreEqual(warrior2.HP, 95);
        }

        [Test]
        public void FightMethodTestThrowException()
        {
            Arena arena = new();

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => arena.Fight("Kiko", "Ivan"));

            Assert.AreEqual(exception.Message, "There is no fighter with name Ivan enrolled for the fights!");
        }

        [Test]
        public void AttackerKillTheDefender()
        {
            Arena arena = new();
            Warrior warrior3 = new("Dimityr", 50, 60);
            Warrior warrior4 = new("Ivan", 50, 40);

            arena.Enroll(warrior3);
            arena.Enroll(warrior4);
            arena.Fight("Dimityr", "Ivan");

            Assert.AreEqual(warrior4.HP, 0);
            Assert.AreEqual(warrior3.HP, 10);
        }
    }
}
