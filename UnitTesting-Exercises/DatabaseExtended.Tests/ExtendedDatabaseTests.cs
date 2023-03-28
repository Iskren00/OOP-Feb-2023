namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        private Person person;

        [SetUp]
        public void SetUp()
        {
            database = new Database();
            person = new Person(1, "Ivan");
        }

        [Test]
        public void AddMethodTest()
        {
            database = new Database(person);
            Person persno2 = new Person(2, "Gosho");
            database.Add(persno2);

            Assert.AreEqual(1, person.Id);
            Assert.AreEqual("Ivan", person.UserName);
            Assert.AreEqual(2, database.Count);
        }

        [Test]
        public void AddMethodThrowExeptionIfItContainsPersonWithSameId()
        {
            database.Add(person);
            Person persno2 = new Person(1, "Gosho");

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(persno2));

            Assert.That(exception.Message, Is.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void AddMethodThrowExeptionIfItContainsPersonWithSameUserName()
        {
            database.Add(person);
            Person persno2 = new Person(2, "Ivan");

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(persno2));

            Assert.That(exception.Message, Is.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void AddMethodThrowExeptionIfDatabaseCountIs16()
        {
            Add16Persons();
            Person newPerson = new Person(895, "Gosho");

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(newPerson));

            Assert.That(exception.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void AddRangeMethodThrowExeption()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => Add17Persons());

            Assert.That(exception.Message, Is.EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void RemoveMethodTest()
        {
            database.Add(person);
            Person person2 = new Person(2, "Gosho"); 
            database.Add(person2);

            database.Remove();

            Assert.AreEqual(1, person.Id);
            Assert.AreEqual("Ivan", person.UserName);
            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void RemoveMethodThrowExeption()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => database.Remove());
        }

        [Test]
        public void FindByUsernameMethodTest()
        {
            database.Add(person);

            Person person2 = database.FindByUsername("Ivan");

            Assert.AreEqual(person, person2);
        }

        [TestCase(null)]
        [TestCase("")]
        public void FindByUsernameMethodThrowExeptionWhenGiveNullOrEmpty(string name)
        {
            database.Add(person);

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => database.FindByUsername(name));

            Assert.That(exception.ParamName, Is.EqualTo("Username parameter is null!"));
        }

        [Test]
        public void FindByUsernameMethodThrowExeptionWhenGiveOtherName()
        {
            database.Add(person);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => database.FindByUsername("Pesho"));

            Assert.That(exception.Message, Is.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FindByIdMethodTest()
        {
            database.Add(person);

            Person person2 = database.FindById(1);

            Assert.AreEqual(person, person2);
        }

        [TestCase(-1)]
        [TestCase(-555)]
        public void FindByIdMethodThrowExeptionWhenGiveNegativeNumber(int id)
        {
            database.Add(person);

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
                () => database.FindById(id));

            Assert.That(exception.ParamName, Is.EqualTo("Id should be a positive number!"));
        }

        [Test]
        public void FindByUsernameMethodThrowExeptionWhenGiveOtherId()
        {
            database.Add(person);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => database.FindById(2));

            Assert.That(exception.Message, Is.EqualTo("No user is present by this ID!"));
        }

        public void Add16Persons()
        {
            Person persno2 = new Person(2, "a");
            Person persno3 = new Person(3, "aa");
            Person persno4 = new Person(4, "aaa");
            Person persno5 = new Person(5, "aaaaa");
            Person persno6 = new Person(6, "av");
            Person persno7 = new Person(7, "abg");
            Person persno8 = new Person(28, "ann");
            Person persno9 = new Person(29, "rra");
            Person persno10 = new Person(23, "wea");
            Person persno11 = new Person(24, "vga");
            Person persno12 = new Person(25, "asfdfha");
            Person persno13 = new Person(26, "awewtuj");
            Person persno14 = new Person(27, "a;;");
            Person persno15 = new Person(34, "afgdfghvb");
            Person persno16 = new Person(45, "aqqqq");



            database = new Database(person, persno2, persno3, persno4, persno5, persno6, persno7, persno8, persno9, persno10
                , persno11, persno12, persno13, persno14, persno15, persno16);
        }

        public void Add17Persons()
        {
            Person persno2 = new Person(2, "a");
            Person persno3 = new Person(3, "aa");
            Person persno4 = new Person(4, "aaa");
            Person persno5 = new Person(5, "aaaaa");
            Person persno6 = new Person(6, "av");
            Person persno7 = new Person(7, "abg");
            Person persno8 = new Person(28, "ann");
            Person persno9 = new Person(29, "rra");
            Person persno10 = new Person(23, "wea");
            Person persno11 = new Person(24, "vga");
            Person persno12 = new Person(25, "asfdfha");
            Person persno13 = new Person(26, "awewtuj");
            Person persno14 = new Person(27, "a;;");
            Person persno15 = new Person(34, "afgdfghvb");
            Person persno16 = new Person(45, "aqqqq");
            Person person17 = new Person(567, "Pier");



            database = new Database(person, persno2, persno3, persno4, persno5, persno6, persno7, persno8, persno9, persno10
                , persno11, persno12, persno13, persno14, persno15, persno16, person17);
        }
    }
}