using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooUnits
{
    public class Giraffe : Herbivorous
    {

        public Giraffe(string name, int weight) : base(name, weight)
        {

        }

        public override string Voice()
        {
            string res = String.Format("\n\t{0}: Иаааа!", Name);
            if (IsAwake)
                return res;
            else return String.Format("{0}{1}", WakeUp(), res);
        }

        public override string ToString()
        {
            return String.Format("Жираф {0} ({1}кг)", this.Name, this.Weight);
        }

        public override string Info()
        {
            return "\t\t" + ToString() + "\n";
        }
    }
}
