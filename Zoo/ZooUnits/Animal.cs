using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooUnits
{
    public abstract class Animal : ZooUnit
    {
        public string Name { get; private set; }
        public int Weight { get; private set; }
        public bool IsAwake { get; private set; }
        public bool IsInZoo { get; set; }

        public Animal()
        {

        }

        public Animal(string name, int weight)
        {
            Name = name;
            Weight = weight;
            IsAwake = true;
            IsInZoo = false;
        }

        public string WakeUp()
        {
            IsAwake = true;
            return String.Format("\n{0} теперь не спит", this.Name);
        }

        public void Goodnight()
        {
            IsAwake = false;
        }

        public override void Add(ZooUnit unit)
        {
            throw new InvalidOperationException();
        }

        public override void Remove(ZooUnit unit)
        {
            throw new InvalidOperationException();
        }

        public override ZooUnit GetChild(int index)
        {
            throw new InvalidOperationException();
        }

        public override List<Container> GetAviaries()
        {
            throw new InvalidOperationException();
        }

        public override List<Container> GetCages()
        {
            return new List<Container>();
        }

        public override int GetAmountOfAnimals()
        {
            return 1;
        }

        public override List<Animal> GetAnimals()
        {
            return new List<Animal> { this };
        }

        public override int GetWeight()
        {
            return Weight;
        }
    }
}
