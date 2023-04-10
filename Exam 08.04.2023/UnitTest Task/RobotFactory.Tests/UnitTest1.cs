using NUnit.Framework;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace RobotFactory.Tests
{
    public class Tests
    {
      
        [Test]
        public void Test1()
        {
            Factory factory = new("aaa", 4);

            Assert.AreEqual(factory.Name, "aaa");
            Assert.AreEqual(factory.Capacity, 4);
            Assert.AreEqual(factory.Robots.Count, 0);
            Assert.AreEqual(factory.Supplements.Count, 0);
        }

        [Test]
        public void Test2()
        {
            Factory factory = new("aaa", 4);
            Assert.AreEqual(factory.ProduceRobot("asd", 5, 12), $"Produced --> {$"Robot model: asd IS: 12, Price: 5.00"}");

            Assert.AreEqual(factory.Robots.Count, 1);
            Assert.AreEqual(factory.Robots[0].Model, "asd");
            Assert.AreEqual(factory.Robots[0].Price, 5);
            Assert.AreEqual(factory.Robots[0].InterfaceStandard, 12);

        }

        [Test]
        public void Test3()
        {
            Factory factory = new("aaa", 4);
            Assert.AreEqual(factory.ProduceSupplement("wer", 33), $"Supplement: wer IS: 33");

            Assert.AreEqual(factory.Supplements.Count, 1);
            Assert.AreEqual(factory.Supplements[0].Name, "wer");
            Assert.AreEqual(factory.Supplements[0].InterfaceStandard, 33);
        }

        [Test] 
        public void Test4()
        {
            Factory factory = new("aaa", 4);
            Robot robot = new("asd", 55, 3);
            Supplement supplement = new("qqq", 3);

            Assert.AreEqual(factory.UpgradeRobot(robot, supplement), true);
        }

        [Test] 
        public void Test5()
        {
            Factory factory = new("aaa", 4);
            factory.ProduceRobot("asd", 5, 12);

            Robot robot = factory.Robots[0];

            Assert.AreEqual(factory.SellRobot(8), robot);
        }

        [Test]

    public void Test6()
        {
            Factory factory = new("aaa", 1);
            factory.ProduceRobot("ddd", 4, 12);

            Assert.AreEqual(factory.ProduceRobot("ss", 13, 55), $"The factory is unable to produce more robots for this production day!");
        }

        [Test]
        public void Test7()
        {
            Factory factory = new("aaa", 4);
            factory.ProduceRobot("asd", 5, 12);

            Robot robot = factory.Robots[0];

            Assert.AreEqual(factory.SellRobot(4), null);
        }

        [Test]
        public void Test8()
        {
            Factory factory = new("aaa", 4);
            Robot robot = new("asd", 55, 3);
            Supplement supplement = new("qqq", 3);

            factory.UpgradeRobot(robot, supplement);

            Assert.AreEqual(factory.UpgradeRobot(robot, supplement), false);
        }

        [Test]
        public void Test9()
        {
            Factory factory = new("aaa", 4);
            Robot robot = new("asd", 55, 3);
            Supplement supplement = new("qqq", 4);

            Assert.AreEqual(factory.UpgradeRobot(robot, supplement), false);
        }
    }
}