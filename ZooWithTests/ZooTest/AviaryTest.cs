using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZooUnits;
using System.Collections.Generic;

namespace ZooTest
{
    [TestClass]
    public class AviaryTest
    {
        public AviaryForHerbivorous<Herbivorous> ah1 = new AviaryForHerbivorous<Herbivorous>();
        public AviaryForHerbivorous<Herbivorous> ah2 = new AviaryForHerbivorous<Herbivorous>();
        public AviaryForPredators<Predator> ap1 = new AviaryForPredators<Predator>();
        public AviaryForPredators<Predator> ap2 = new AviaryForPredators<Predator>();
        public AviaryForPredators<Predator> ap3 = new AviaryForPredators<Predator>();

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

        public CageForBears cb = new CageForBears();
        public CageForGiraffes cg1 = new CageForGiraffes();
        public CageForGiraffes cg2 = new CageForGiraffes();
        public CageForWolves cw = new CageForWolves();

        [TestMethod]
        public void Add_HerbivorousInHerbivorous_OneAnimalInAviary()
        {
            ah1.Add(g1);
            Assert.AreEqual(ah1.GetAmountOfAnimals(), 1);
            Assert.AreEqual(ah1.GetAnimals()[0], g1);
            Assert.IsTrue(g1.IsInZoo);
        }

        [TestMethod]
        [ExpectedException(typeof(CannotAddUnitException), "Нельзя добавить хищника!")]
        public void Add_PredatorInHerbivorous_CannotAddUnitException()
        {
            ah1.Add(w1);
        }

        [TestMethod]
        [ExpectedException(typeof(CannotAddUnitException), "Это животное уже в другой клетке!")]
        public void Add_HerbivorousIsInZooInHerbivorous_CannotAddUnitException()
        {
            ah1.Add(g2);
            Assert.IsTrue(g2.IsInZoo);
            ah1.Add(g2);
        }

        [TestMethod]
        public void Add_PredatorInPredators_OneAnimalInAviary()
        {
            ap1.Add(w1);
            Assert.AreEqual(ap1.GetAmountOfAnimals(), 1);
            Assert.AreEqual(ap1.GetAnimals()[0], w1);
            Assert.IsTrue(w1.IsInZoo);
        }

        [TestMethod]
        [ExpectedException(typeof(CannotAddUnitException), "Нельзя добавить травоядное!")]
        public void Add_HerbivorousInPredators_CannotAddUnitException()
        {
            ap1.Add(g3);
        }

        [TestMethod]
        [ExpectedException(typeof(CannotAddUnitException), "Это животное уже в другой клетке!")]
        public void Add_PredatorIsInZooInPredators_CannotAddUnitException()
        {
            ap1.Add(b1);
            Assert.IsTrue(b1.IsInZoo);
            ah1.Add(b1);
        }

        [TestMethod]
        public void Add_BearToBear_TwoBearsInAviary()
        {
            ap2.Add(b2);
            ap2.Add(b3);
            Assert.AreEqual(ap2.GetAmountOfAnimals(), 2);
        }

        [TestMethod]
        [ExpectedException(typeof(CannotAddUnitException), "Тут уже животные другого вида!")]
        public void Add_WolfToBear_CannotAddUnitException()
        {
            ap2.Add(b1);
            ap2.Add(w2);
        }

        [TestMethod]
        public void Add_CageForGiraffesInHerbivorous_OneCageInAviary()
        {
            ah2.Add(cg1);
            var cages = ah2.GetCages();
            Assert.AreEqual(cages.Count, 1);
            Assert.AreEqual(cages[0], cg1);
        }

        [TestMethod]
        [ExpectedException(typeof(CannotAddUnitException), "Нельзя добавить клетку для хищников!")]
        public void Add_CageForWolvesInHerbivorous_CannotAddUnitException()
        {
            ah2.Add(cw);
        }

        [TestMethod]
        [ExpectedException(typeof(CannotAddUnitException), "Нельзя добавить клетку для хищников!")]
        public void Add_CageForBearsInHerbivorous_CannotAddUnitException()
        {
            ah2.Add(cb);
        }

        [TestMethod]
        public void Add_CageForBearsInPredators_OneCageInAviary()
        {
            ap3.Add(cb);
            var cages = ap3.GetCages();
            Assert.AreEqual(cages.Count, 1);
            Assert.AreEqual(cages[0], cb);
        }

        [TestMethod]
        public void Add_CageForWolvesInPredators_OneCageInAviary()
        {
            ap3.Add(cw);
            var cages = ap3.GetCages();
            Assert.AreEqual(cages.Count, 1);
            Assert.AreEqual(cages[0], cw);
        }

        [TestMethod]
        public void Remove_AnimalInAviaryForHerbivorous_EmptyAviary()
        {
            ah2.Add(g1);
            Assert.AreEqual(ah2.GetAmountOfAnimals(), 1);
            ah2.Remove(g1);
            Assert.AreEqual(ah2.GetAmountOfAnimals(), 0);
        }

        [TestMethod]
        public void Remove_AnimalInAviaryForPredators_EmptyAviary()
        {
            ap3.Add(w1);
            Assert.AreEqual(ap3.GetAmountOfAnimals(), 1);
            ap3.Remove(w1);
            Assert.AreEqual(ap3.GetAmountOfAnimals(), 0);
        }

        [TestMethod]
        [ExpectedException(typeof(CannotRemoveUnitException), "Невозможно удалить животное/клетку!")]
        public void Remove_AnimalIsNotInAviaryForHerbivorous_CannotRemoveUnitException()
        {
            ah1.Remove(g1);
        }

        [TestMethod]
        [ExpectedException(typeof(CannotRemoveUnitException), "Невозможно удалить животное/клетку!")]
        public void Remove_AnimalIsNotInAviaryForPredators_CannotRemoveUnitException()
        {
            ap1.Remove(b1);
        }

        [TestMethod]
        public void GetAviaries_Aviary_ListOfAviariesWithThis()
        {
            Assert.AreEqual(ah1.GetAviaries()[0], ah1);
            Assert.AreEqual(ap1.GetAviaries()[0], ap1);
        }

        [TestMethod]
        public void GetCages_AviaryWithCages_ListOfCages()
        {
            ah1.Add(cg1);
            ah1.Add(cg2);
            Assert.AreEqual(ah1.GetCages()[0], cg1);
            Assert.AreEqual(ah1.GetCages()[0], cg1);
        }

        [TestMethod]
        public void GetCages_AviaryWithoutCages_EmptyList()
        {
            Assert.AreEqual(ap1.GetCages().Count, 0);
        }

        [TestMethod]
        public void GetAnimals_AviaryWithAnimals_ListOfAnimalsWithThreeAnimals()
        {
            ap1.Add(b1);
            ap1.Add(b2);
            ap1.Add(b3);
            Assert.AreEqual(ap1.GetAnimals().Count, 3);
        }

        [TestMethod]
        public void GetAnimals_AviaryWithoutAnimals_EmptyList()
        {
            Assert.AreEqual(ap1.GetAnimals().Count, 0);
        }

        [TestMethod]
        public void GetWeight_AviaryWithAnimals_EqualWeight()
        {
            ap1.Add(b1);
            ap1.Add(b2);
            ap1.Add(b3);
            int actual = b1.GetWeight() + b2.GetWeight() + b3.GetWeight();
            Assert.AreEqual(ap1.GetWeight(), actual);
        }

        [TestMethod]
        public void GetWeight_AviaryWithoutAnimals_ZeroWeight()
        {
            Assert.AreEqual(ah1.GetWeight(), 0);
        }

        [TestMethod]
        public void Voice_AviaryWithAnimals_NotEmptyString()
        {
            ah2.Add(g1);
            Assert.IsFalse(ah2.Voice() == "");
        }

        [TestMethod]
        public void Voice_AviaryWithoutAnimals_EmptyString()
        {
            Assert.IsTrue(ap2.Voice() == "");
        }
    }
}
