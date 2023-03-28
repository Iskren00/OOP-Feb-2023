namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }

        [Test]
        public void AddMethodTest()
        {
            database.Add(3);
            int[] result = database.Fetch();

            Assert.AreEqual(1, database.Count);
            Assert.AreEqual(3, result[0]);
            Assert.AreEqual(1, result.Length);
        }

        [Test]
        public void AddMethodThrowExeption()
        {
            database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => database.Add(1));

            Assert.That(exception.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void RemoveMethodTest()
        {
            database.Add(1);
            database.Add(2);

            database.Remove();
            
            int[] result = database.Fetch();

            Assert.AreEqual(1, database.Count);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(1, result.Length);
        }

        [Test]
        public void RemoveMethodThrowExeption()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => database.Remove());

            Assert.That(exception.Message, Is.EqualTo("The collection is empty!"));
        }
    }
}
