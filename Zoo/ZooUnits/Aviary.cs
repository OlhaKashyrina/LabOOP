using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooUnits
{
    public abstract class Aviary<T> : Container
        where T : Animal
    {
        public override void Remove(ZooUnit unit)
        {
            if (Units.Contains(unit))
            {
                if (unit is Animal)
                {
                    (unit as Animal).IsInZoo = false;
                    Units.Remove(unit);
                }
            }
            else throw new CannotRemoveUnitException("Невозможно удалить животное/клетку!");
        }

        public override string Info()
        {
            string res = "\t";
            res += ToString() + "\n";
            foreach (var item in Units)
            {
                res += "\t" + item.Info();
            }
            return res;
        }

        public override string Voice()
        {
            string voices = "";
            foreach (var unit in Units)
            {
                voices += unit.Voice();
            }
            return voices;
        }
    }
}
