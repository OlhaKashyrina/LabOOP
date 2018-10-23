using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooUnits
{
    public class CageForGiraffes : AviaryForHerbivorous<Giraffe>
    {
        public override void Add(ZooUnit unit)
        {
            if (unit is Giraffe || unit is CageForGiraffes)
                Units.Add(unit);
        }

        public override string ToString()
        {
            return "Клетка для жирафов " + Id.ToString();
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

        //public override string Info()
        //{
        //    string res = "\n\t";
        //    res += ToString();
        //    foreach (var item in Units)
        //    {
        //        res += item.Info();
        //    }
        //    return res;
        //}
    }
}
