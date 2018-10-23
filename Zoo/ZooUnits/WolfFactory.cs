using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ZooUnits
{
    public class WolfFactory : AnimalFactory
    {
        public override Animal CreateAnimal()
        {
            Random rand = new Random();
            return new Wolf(ChooseName(), rand.Next(200));
        }

        public override string ChooseName()
        {
            string[] names = { "Люпин", "Дерек", "Скотт", "Стью", "К'хор'гаах" };
            Random rand = new Random();
            Thread.Sleep(rand.Next(1000));
            return names[rand.Next(0, 4)];
        }
    }
}
