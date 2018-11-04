using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooUnits
{
    public class AviaryForPredators<T> : Aviary<Predator>
        where T : Predator
    {
        public override void Add(ZooUnit unit)
        {
            if (unit is Animal && (unit as Animal).IsInZoo) throw new CannotAddUnitException("Это животное уже в другой клетке!");
            if (unit is Predator)
            {
                if (this.Units.Count == 0)
                {
                    (unit as Animal).IsInZoo = true;
                    Units.Add(unit);
                }
                else
                {
                    List<ZooUnit> zu = new List<ZooUnit>();
                    foreach (var item in this.Units)
                        if (item is Predator)
                            zu.Add(item);
                    if (zu.Count != 0 && zu[0].GetType() == unit.GetType())
                    {
                        (unit as Animal).IsInZoo = true;
                        Units.Add(unit);
                    }
                    else if(zu.Count !=0) throw new CannotAddUnitException("Тут уже животные другого вида!");
                }
            }
            else if (unit is Animal) throw new CannotAddUnitException("Нельзя добавить травоядное!");
            if (unit is CageForBears || unit is CageForWolves)
                Units.Add(unit);
            else if (!(unit is Animal)) throw new CannotAddUnitException("Нельзя добавить клетку для травоядных!");
            
        }

        public override List<Container> GetAviaries()
        {
            return new List<Container> { this };
        }

        public override string ToString()
        {
            return "Вольер для хищников " + Id.ToString();
        }

        
    }
}
