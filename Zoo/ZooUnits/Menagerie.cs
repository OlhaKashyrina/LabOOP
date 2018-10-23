using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooUnits
{
    public class Menagerie : Container
    {
        public enum TimeOfDay
        {
            Day,
            Night
        }

        public TimeOfDay CurrentTimeOfDay;
        public Menagerie()
        {
            CurrentTimeOfDay = Menagerie.TimeOfDay.Day;
        }

        public void ChangeTime()
        {
            List<Animal> animals = this.GetAnimals();
            if (CurrentTimeOfDay == TimeOfDay.Day)
            {
                CurrentTimeOfDay = TimeOfDay.Night;
                foreach (var a in animals)
                    a.Goodnight();
            }
            else
            {
                CurrentTimeOfDay = TimeOfDay.Day;
                foreach (var a in animals)
                    a.WakeUp();
            }
        }

        public double GetAverageWeight()
        {
            return (double)GetWeight() / GetAmountOfAnimals();
        }

        public override string Voice()
        {
            string voices = "";
            if(CurrentTimeOfDay == TimeOfDay.Day)
            {
                foreach (var item in Units)
                {
                    voices += item.Voice();
                }
            }
            else
            {
                foreach (var item in Units)
                {
                    if (item is Animal && !(item as Animal).IsAwake)
                        voices += (item as Animal).WakeUp();
                    voices += item.Voice();
                }
            }
            return voices;
        }
    }
}
