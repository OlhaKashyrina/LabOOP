using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ZooUnits
{
    public class GiraffeFactory : AnimalFactory
    {
        public override Animal CreateAnimal()
        {
            Random rand = new Random();
            return new Giraffe(ChooseName(), rand.Next(200));
        }

        public override string ChooseName()
        {
            string[] names = { "Карл", "Юлий", "Гектор", "Родриго", "Байт" };
            Random rand = new Random();
            Thread.Sleep(rand.Next(1000));
            return names[rand.Next(0, 4)];
        }
    }
}
