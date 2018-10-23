using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooUnits
{
    public abstract class AnimalFactory
    {
        public abstract Animal CreateAnimal();
        public abstract string ChooseName();

        public static Animal CreateRandomAnimal()
        {
            Random rand = new Random();
            int r = rand.Next(1, 5);
            AnimalFactory af;
            if (r == 1) af = new GiraffeFactory();
            else
            {
                if (r < 4) af = new WolfFactory();
                else af = new BearFactory();
            }
            return af.CreateAnimal();
        }
    }
}
