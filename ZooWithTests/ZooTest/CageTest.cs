using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZooUnits;

namespace ZooTest
{
    [TestClass]
    public class CageTest
    {
        public CageForBears cb1 = new CageForBears();
        public CageForBears cb2 = new CageForBears();
        public CageForGiraffes cg1 = new CageForGiraffes();
        public CageForGiraffes cg2 = new CageForGiraffes();
        public CageForWolves cw1 = new CageForWolves();
        public CageForWolves cw2 = new CageForWolves();

        public static WolfFactory wf = new WolfFactory();
        public static BearFactory bf = new BearFactory();
        public static GiraffeFactory gf = new GiraffeFactory();

        public Wolf w1 = wf.CreateAnimal() as Wolf;
        public Wolf w2 = wf.CreateAnimal() as Wolf;
        public Bear b1 = bf.CreateAnimal() as Bear;
        public Bear b2 = bf.CreateAnimal() as Bear;
        public Bear b3 = bf.CreateAnimal() as Bear;
        public Giraffe g1 = gf.CreateAnimal() as Giraffe;
        public Giraffe g2 = gf.CreateAnimal() as Giraffe;
        public Giraffe g3 = gf.CreateAnimal() as Giraffe;

        [TestMethod]
        public void Add_BearInBears_OneBearInCage()
        {
            cb1.Add(b1);
            Assert.AreEqual(cb1.GetAnimals()[0], b1);
            Assert.AreEqual(cb1.GetAmountOfAnimals(), 1);
        }

        [TestMethod]
        public void Add_GiraffeInGiraffes_OneGiraffeInCage()
        {
            cg1.Add(g1);
            Assert.AreEqual(cg1.GetAnimals()[0], g1);
            Assert.AreEqual(cg1.GetAmountOfAnimals(), 1);
        }

        [TestMethod]
        public void Add_WolfInWolvess_OneWolfInCage()
        {
            cw1.Add(w1);
            Assert.AreEqual(cw1.GetAnimals()[0], w1);
            Assert.AreEqual(cw1.GetAmountOfAnimals(), 1);
        }

        [TestMethod]
        [ExpectedException(typeof(CannotAddUnitException), "Невозможно добавить травоядное/клетку для травоядного!")]
        public void Add_HerbivorousInCageForPredators_CannotAddUnitException()
        {
            cb1.Add(g1);
        }

        [TestMethod]
        [ExpectedException(typeof(CannotAddUnitException), "Невозможно добавить хищника/клетку для хищника!")]
        public void Add_PredatorInCageForHerbivorous_CannotAddUnitException()
        {
            cg1.Add(w1);
        }

        [TestMethod]
        public void Add_CageForBearsInBears_TwoCagesTotal()
        {
            cb1.Add(cb2);
            Assert.AreEqual(cb1.GetCages()[1], cb2);
            Assert.AreEqual(cb1.GetCages().Count, 2);
        }

        [TestMethod]
        public void Add_CageForGiraffesInGiraffes_TwoCagesTotal()
        {
            cg1.Add(cg2);
            Assert.AreEqual(cg1.GetCages()[1], cg2);
            Assert.AreEqual(cg1.GetCages().Count, 2);
        }

        [TestMethod]
        public void Add_CageForWolvesInWolvess_TwoCagesTotal()
        {
            cw1.Add(cw2);
            Assert.AreEqual(cw1.GetCages()[1], cw2);
            Assert.AreEqual(cw1.GetCages().Count, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(CannotAddUnitException), "Невозможно добавить травоядное/клетку для травоядного!")]
        public void Add_CageForGiraffesInCageForWolves_CannotAddUnitException()
        {
            cw1.Add(cg1);
        }

        [TestMethod]
        [ExpectedException(typeof(CannotAddUnitException), "Невозможно добавить хищника/клетку для хищника!")]
        public void Add_CageForWolvesInCageForBears_CannotAddUnitException()
        {
            cb1.Add(cw1);
        }

        [TestMethod]
        [ExpectedException(typeof(CannotAddUnitException), "Невозможно добавить травоядное/клетку для травоядного!")]
        public void Add_CageForBearsInCageForGiraffes_CannotAddUnitException()
        {
            cg1.Add(cb1);
        }

        [TestMethod]
        public void Remove_AnimalInCageFromCage_EmptyCage()
        {
            cb1.Add(b1);
            Assert.AreEqual(cb1.GetAmountOfAnimals(), 1);
            cb1.Remove(b1);
            Assert.AreEqual(cb1.GetAmountOfAnimals(), 0);
            cg1.Add(g1);
            Assert.AreEqual(cg1.GetAmountOfAnimals(), 1);
            cg1.Remove(g1);
            Assert.AreEqual(cg1.GetAmountOfAnimals(), 0);
            cw1.Add(w1);
            Assert.AreEqual(cw1.GetAmountOfAnimals(), 1);
            cw1.Remove(w1);
            Assert.AreEqual(cw1.GetAmountOfAnimals(), 0);
        }

        [TestMethod]
        [ExpectedException(typeof(CannotRemoveUnitException), "Невозможно удалить животное/клетку!")]
        public void Remove_AnimalIsNotInCageFromCage_CannotRemoveUnitException()
        {
            cg1.Remove(g2);
        }

        [TestMethod]
        public void GetAviaries_AnyCage_EmptyListOfContainers()
        {
            Assert.AreEqual(cb1.GetAviaries().Count, 0);
            Assert.AreEqual(cg1.GetAviaries().Count, 0);
            Assert.AreEqual(cw1.GetAviaries().Count, 0);
        }

        [TestMethod]
        public void GetAnimals_CageWithAnimals_ListOfAnimalsWithOneAnimal()
        {
            cb1.Add(b1);
            Assert.AreEqual(cb1.GetAnimals().Count, 1);
            Assert.AreEqual(cb1.GetAnimals()[0], b1);
        }

        [TestMethod]
        public void GetAnimals_CageWithoutAnimals_EmptyListOfAnimals()
        {
            Assert.AreEqual(cg1.GetAnimals().Count, 0);
        }

        [TestMethod]
        public void GetCages_CageWithoutCages_ListOfContainersWithThisCage()
        {
            Assert.AreEqual(cw1.GetCages().Count, 1);
            Assert.AreEqual(cw1.GetCages()[0], cw1);
        }

        [TestMethod]
        public void GetCages_CageWithCages_ListOfContainersWithCages()
        {
            cg1.Add(cg2);
            Assert.AreEqual(cg1.GetCages().Count, 2);
            Assert.AreEqual(cg1.GetCages()[0], cg1);
            Assert.AreEqual(cg1.GetCages()[1], cg2);
        }

        [TestMethod]
        public void GetWeight_CageWithAnimals_EqualWeight()
        {
            cb1.Add(b1);
            cb1.Add(b2);
            cb1.Add(b3);
            int actual = b1.GetWeight() + b2.GetWeight() + b3.GetWeight();
            Assert.AreEqual(cb1.GetWeight(), actual);
        }

        [TestMethod]
        public void GetWeight_CageWithoutAnimals_ZeroWeight()
        {
            Assert.AreEqual(cg1.GetWeight(), 0);
        }

        [TestMethod]
        public void Voice_CageWithAnimals_NotEmptyString()
        {
            cw1.Add(w1);
            Assert.IsFalse(cw1.Voice() == "");
        }

        [TestMethod]
        public void Voice_CageWithoutAnimals_EmptyString()
        {
            Assert.IsTrue(cg1.Voice() == "");
        }
    }
}
