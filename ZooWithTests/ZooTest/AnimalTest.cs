using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZooUnits;
using System.Collections.Generic;

namespace ZooTest
{
    [TestClass]
    public class AnimalTest
    {
        public Wolf w1 = new Wolf("Люпин", 100);
        public Wolf w2 = new Wolf("Стью", 90);
        public Wolf w3 = new Wolf("Дерек", 80);

        public Bear b1 = new Bear("Акакий", 200);
        public Bear b2 = new Bear("Огнеслав", 180);
        public Bear b3 = new Bear("Тимофей", 160);

        public Giraffe g1 = new Giraffe("Мелман", 300);
        public Giraffe g2 = new Giraffe("Байт", 190);
        public Giraffe g3 = new Giraffe("Карл", 80);

        [TestMethod]
        public void Goodnight_AwakeAnimal_True()
        {
            w1.Goodnight();
            Assert.IsTrue(!w1.IsAwake);
        }

        [TestMethod]
        public void WakeUp_AsleepAnimal_True()
        {
            w1.WakeUp();
            Assert.IsTrue(w1.IsAwake);
        }

        [TestMethod]
        public void GetWeight_Animal_Equals()
        {
            int weight = b1.Weight;
            int getWeight = b1.GetWeight();
            Assert.AreEqual(weight, getWeight);
        }

        [TestMethod]
        public void GetAnimals_Animal_ListOfAnimalsWithOneAnimal()
        {
            var animals = g1.GetAnimals();
            Assert.IsInstanceOfType(animals, new List<Animal>().GetType());
            Assert.AreEqual(animals.Count, 1);
            Assert.AreEqual(animals[0], g1);
        }

        [TestMethod]
        public void GetAmountOfAnimals_Animal_OneAnimal()
        {
            Assert.AreEqual(w2.GetAmountOfAnimals(), 1);
            Assert.AreEqual(b2.GetAmountOfAnimals(), 1);
            Assert.AreEqual(g2.GetAmountOfAnimals(), 1);
        }

        [TestMethod]
        public void GetCages_Animal_EmptyListOfContainers()
        {
            var cages = g3.GetCages();
            Assert.IsInstanceOfType(cages, new List<Container>().GetType());
            Assert.AreEqual(cages.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Add_Animal_IvalidOperationException()
        {
            w2.Add(b1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Remove_Animal_IvalidOperationException()
        {
            g2.Remove(b1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetAviaries_Animal_IvalidOperationException()
        {
            b2.GetAviaries();
        }

        [TestMethod]
        public void Voice_AwakeAnimal_DoesNotContainSubstringAwake()
        {
            string substr = "не спит";
            string res = g1.Voice();
            Assert.IsFalse(res.Contains(substr));
        }

        [TestMethod]
        public void Voice_AsleepAnimal_StatusChangedAndContainsSubstringAwake()
        {
            string substr = "не спит";
            b1.Goodnight();
            bool asleep = b1.IsAwake;
            string res = b1.Voice();
            bool awake = b1.IsAwake;
            Assert.AreNotEqual(asleep, awake);
            Assert.IsTrue(res.Contains(substr));
        }
    }
}
