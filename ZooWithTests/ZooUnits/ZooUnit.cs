using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooUnits
{
    public abstract class ZooUnit
    {
        public Guid Id { get; private set; }

        public ZooUnit()
        {
            Id = Guid.NewGuid();
        }

        public abstract void Add(ZooUnit unit);
        public abstract void Remove(ZooUnit unit);
        public abstract int GetWeight();
        public abstract int GetAmountOfAnimals();
        public abstract List<Animal> GetAnimals();
        public abstract List<Container> GetAviaries();
        public abstract List<Container> GetCages();
        public abstract string Voice();
        public abstract string Info();
    }
}
