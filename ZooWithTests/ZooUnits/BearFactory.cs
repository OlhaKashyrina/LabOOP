using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ZooUnits
{
    public class BearFactory : AnimalFactory
    {
        public override Animal CreateAnimal()
        {
            Random rand = new Random();
            return new Bear(ChooseName(), rand.Next(200));
        }

        public override string ChooseName()
        {
            string[] names = { "Иван", "Георгий", "Тимофей", "Акакий", "Огнеслав" };
            Random rand = new Random();
            Thread.Sleep(rand.Next(1000));
            return names[rand.Next(0, 4)];
        }

        
    }
}
