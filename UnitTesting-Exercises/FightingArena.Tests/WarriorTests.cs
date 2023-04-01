namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void MakeAWarrior()
        {
            Warrior warrior = new("Iskren", 10, 100);

            Assert.AreEqual(warrior.Name, "Iskren");
            Assert.AreEqual(warrior.Damage, 10);
            Assert.AreEqual(warrior.HP, 100);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("        ")]
        public void ThrowExceptionIfNameIsNullOrWhiteSpace(string name)
        {
            Warrior warrior;

            ArgumentException exception = Assert.Throws<ArgumentException>(() => warrior = new(name, 10, 100));

            Assert.AreEqual(exception.Message, "Name should not be empty or whitespace!");
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(-1234)]
        public void ThrowExceptionIfDamageValueIsZeroOrNegative(int dmg)
        {
            Warrior warrior;

            ArgumentException exception = Assert.Throws<ArgumentException>(() => warrior = new("Iskren", dmg, 100));

            Assert.AreEqual(exception.Message, "Damage value should be positive!");
        }

        [TestCase(-1)]
        [TestCase(-20)]
        [TestCase(-1234)]
        public void ThrowExceptionIfHPValueIsNegative(int hp)
        {
            Warrior warrior;

            ArgumentException exception = Assert.Throws<ArgumentException>(() => warrior = new("Iskren", 10, hp));

            Assert.AreEqual(exception.Message, "HP should not be negative!");
        }

        [Test]
        public void AttackMethodThrowExceptionIfAttackerHPIsLowerOrEqualTo30()
        {
            Warrior warrior1 = new("Iskren", 10, 30);
            Warrior warrior2 = new("Mirka", 10, 50);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));

            Assert.AreEqual(exception.Message, "Your HP is too low in order to attack other warriors!");
        }

        [Test]
        public void AttackMethodThrowExceptionIfDefenderHPIsLowerOrEqualTo30()
        {
            Warrior warrior1 = new("Iskren", 10, 50);
            Warrior warrior2 = new("Mirka", 10, 30);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));

            Assert.AreEqual(exception.Message, "Enemy HP must be greater than 30 in order to attack him!");
        }

        [Test]
        public void AttackMethodThrowExceptionIfAtackerHPIsLowerThenDefenderDamage()
        {
            Warrior warrior1 = new("Iskren", 10, 50);
            Warrior warrior2 = new("Mirka", 60, 80);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));

            Assert.AreEqual(exception.Message, "You are trying to attack too strong enemy");
        }
    }
}