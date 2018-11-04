using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooUnits
{
    public class CageForBears : AviaryForPredators<Bear>
    {
        public override void Add(ZooUnit unit)
        {
            if (unit is Bear || unit is CageForBears)
            {
                if (unit is Bear)
                    (unit as Animal).IsInZoo = true;
                Units.Add(unit);
            }
            else throw new CannotAddUnitException("Невозможно добавить травоядное/клетку для травоядного!");
        }

        public override string ToString()
        {
            return "Клетка для медведей " + Id.ToString();
        }

        public override List<Container> GetCages()
        {
            List<Container> cages = new List<Container>();
            cages.Add(this);
            foreach (var unit in Units)
            {
                cages.AddRange(unit.GetCages());
            }
            return cages;
        }

        public override List<Container> GetAviaries()
        {
            return new List<Container>();
        }

    }
}
