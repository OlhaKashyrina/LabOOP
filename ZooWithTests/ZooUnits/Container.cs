using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooUnits
{
    public abstract class Container : ZooUnit
    {
        public List<ZooUnit> Units = new List<ZooUnit>();

        public override void Add(ZooUnit unit)
        {
            Units.Add(unit);
        }

        public override void Remove(ZooUnit unit)
        {
            if (Units.Contains(unit))
                Units.Remove(unit);
            else throw new CannotRemoveUnitException("Невозможно удалить животное/клетку!");
        }

        public override int GetWeight()
        {
            int weight = 0;
            foreach (var unit in Units)
            {
                weight += unit.GetWeight();
            }
            return weight;
        }

        public override int GetAmountOfAnimals()
        {
            int count = 0;
            foreach (var unit in Units)
            {
                count += unit.GetAmountOfAnimals();
            }
            return count;
        }

        public override List<Animal> GetAnimals()
        {
            List<Animal> animals = new List<Animal>();
            foreach (var unit in Units)
            {
                animals.AddRange(unit.GetAnimals());
            }
            return animals;
        }

        public override List<Container> GetAviaries()
        {
            List<Container> aviaries = new List<Container>();
            foreach (var unit in Units)
            {
                aviaries.AddRange(unit.GetAviaries());
            }
            return aviaries;
        }

        public override List<Container> GetCages()
        {
            List<Container> cages = new List<Container>();
            foreach (var unit in Units)
            {
                cages.AddRange(unit.GetCages());
            }
            return cages;
        }

        public override string Info()
        {
            string res = "\t";
            foreach (var item in Units)
            {
                res += "\t" + item.Info();
            }
            return res;
        }

        public override string ToString()
        {
            return GetAmountOfAnimals().ToString();
        }

    }
}
