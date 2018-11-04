using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooUnits
{
    public class AviaryForHerbivorous<T> : Aviary<Herbivorous>
        where T : Herbivorous
    {
        public override void Add(ZooUnit unit)
        {
            if (unit is Animal && (unit as Animal).IsInZoo) throw new CannotAddUnitException("Это животное уже в другой клетке!");
            if (unit is Herbivorous)
            {
                if (this.Units.Count == 0)
                {
                    Units.Add(unit);
                    (unit as Animal).IsInZoo = true;
                }
                else
                {
                    List<ZooUnit> zu = new List<ZooUnit>();
                    foreach (var item in this.Units)
                        if (item is Herbivorous)
                            zu.Add(item);
                    if (zu.Count != 0 && zu[0].GetType() == unit.GetType())
                    {
                        Units.Add(unit);
                        (unit as Animal).IsInZoo = true;
                    }
                }
            }
            else if (unit is Animal) throw new CannotAddUnitException("Нельзя добавить хищника!");
            if (unit is CageForGiraffes)
                Units.Add(unit);
            else if(!(unit is Animal)) throw new CannotAddUnitException("Нельзя добавить клетку для хищников!");
        }

        public override List<Container> GetAviaries()
        {
            return new List<Container> { this };
        }

        public override string ToString()
        {
            return "Вольер для травоядных " + Id.ToString();
        }

    }
}
