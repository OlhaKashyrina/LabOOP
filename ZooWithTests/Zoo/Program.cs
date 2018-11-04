using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ZooUnits;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Menagerie zoo = new Menagerie();
            Console.WriteLine("Добро пожаловать в зверинец!\nv - добавить вольер\nc - добавить клетку\na - добавить животное\nd - удалить\no - опции\ni - информация");
            while (true)
            {
                var k = Console.ReadKey();
                switch (k.Key)
                {
                    case ConsoleKey.V:
                        bool isDone = true;
                        do
                        {
                            Console.WriteLine("\nh - вольер для травоядных\np - вольер для хищников");
                            var key = Console.ReadKey();
                            switch (key.Key)
                            {
                                case ConsoleKey.H:
                                    zoo.Add(new AviaryForHerbivorous<Herbivorous>());
                                    Done();
                                    isDone = true;
                                    break;
                                case ConsoleKey.P:
                                    zoo.Add(new AviaryForPredators<Predator>());
                                    Done();
                                    isDone = true;
                                    break;
                                default:
                                    isDone = false;
                                    break;
                            }
                        }
                        while (!isDone);
                        break;
                    case ConsoleKey.C:
                        isDone = true;
                        do
                        {
                            Console.WriteLine("\nКуда поместить клетку?\nz - в сам зверинец\nv - в вольер\nc - в другую клетку");
                            var key1 = Console.ReadKey();
                            switch (key1.Key)
                            {
                                case ConsoleKey.Z:
                                    Console.WriteLine("\nw - для волков\nb - для медведей\ng - для жирафов");
                                    var k2 = Console.ReadKey();
                                    zoo.Add(ChooseCage(k2));
                                    Done();
                                    isDone = true;
                                    break;
                                case ConsoleKey.V:
                                    List<Container> aviaries = zoo.GetAviaries();
                                    if (aviaries.Count == 0) Console.WriteLine("\nВ зверинце нет вольеров!");
                                    else
                                    {
                                        Console.WriteLine("\nw - для волков\nb - для медведей\ng - для жирафов");
                                        k2 = Console.ReadKey();
                                        Console.WriteLine("\nВыберите вольер:");
                                        int i = 1;
                                        foreach (var item in aviaries)
                                        {
                                            Console.WriteLine(i + " - " + item.ToString());
                                            i++;
                                        }
                                        int a = 0;
                                        try
                                        { a = Convert.ToInt32(Console.ReadLine()); }
                                        catch (FormatException ex)
                                        {
                                            Console.WriteLine("\nЦифру введи, дубина!");
                                            isDone = false;
                                            break;
                                        }
                                        var av = aviaries[a - 1];
                                        i = av.Units.Count;
                                        try
                                        {
                                            av.Add(ChooseCage(k2));
                                            Done();
                                        }
                                        catch (ZooException ex)
                                        {
                                            Fail(ex);
                                        }
                                    }
                                    isDone = true;
                                    break;

                                case ConsoleKey.C:
                                    List<Container> cages = zoo.GetCages();
                                    if (cages.Count == 0) Console.WriteLine("\nВ зверинце нет клеток!");
                                    else
                                    {
                                        Console.WriteLine("\nw - для волков\nb - для медведей\ng - для жирафов");
                                        k2 = Console.ReadKey();
                                        Console.WriteLine("\nВыберите клетку:");
                                        int i = 1;
                                        foreach (var item in cages)
                                        {
                                            Console.WriteLine(i + " - " + item.ToString());
                                            i++;
                                        }
                                        int a = 0;
                                        try
                                        { a = Convert.ToInt32(Console.ReadLine()); }
                                        catch (FormatException ex)
                                        {
                                            Console.WriteLine("\nЦифру введи, дубина!");
                                            isDone = false;
                                            break;
                                        }
                                        var av = cages[a - 1];
                                        i = av.Units.Count;
                                        try
                                        {
                                            av.Add(ChooseCage(k2));
                                            Done();
                                        }
                                        catch(ZooException ex)
                                        {
                                            Fail(ex);
                                        }
                                    }
                                    isDone = true;
                                    break;
                                default:
                                    isDone = false;
                                    break;
                            }
                        } while (!isDone);
                        break;
                    case ConsoleKey.A:
                        List<Container> avs = zoo.GetAviaries();
                        List<Container> cs = zoo.GetCages();
                        if(avs.Count == 0 && cs.Count == 0)
                        {
                            Console.WriteLine("\nВ зоопарке пусто, некуда поселить животное!");
                            break;
                        }
                        isDone = true;
                        Animal animal = AnimalFactory.CreateRandomAnimal();
                        Console.WriteLine("\nСоздано животное " + animal.ToString());
                        do
                        {
                            Console.WriteLine("\nКуда поместить животное?\nv - в вольер\nc - в клетку");
                            var key2 = Console.ReadKey();
                            switch (key2.Key)
                            {
                                case ConsoleKey.V:
                                    List<Container> aviaries = zoo.GetAviaries();
                                    if (aviaries.Count == 0) Console.WriteLine("\nВ зверинце нет вольеров!");
                                    else
                                    {
                                        Console.WriteLine("\nВыберите вольер:");
                                        int i = 1;
                                        foreach (var item in aviaries)
                                        {
                                            Console.WriteLine(i + " - " + item.ToString());
                                            i++;
                                        }
                                        int a = 0;
                                        try
                                        { a = Convert.ToInt32(Console.ReadLine()); }
                                        catch (FormatException ex) 
                                        { 
                                            Console.WriteLine("\nЦифру введи, дубина!");
                                            isDone = false;
                                            break;
                                        }
                                        var av = aviaries[a - 1];
                                        i = av.Units.Count;
                                        try
                                        {
                                            av.Add(animal);
                                            Done();
                                        }
                                        catch(ZooException ex)
                                        {
                                            Fail(ex);
                                        }
                                    }
                                    isDone = true;
                                    break;

                                case ConsoleKey.C:
                                    List<Container> cages = zoo.GetCages();
                                    if (cages.Count == 0) Console.WriteLine("\nВ зверинце нет клеток!");
                                    else
                                    {
                                        Console.WriteLine("\nВыберите клетку:");
                                        int i = 1;
                                        foreach (var item in cages)
                                        {
                                            Console.WriteLine(i + " - " + item.ToString());
                                            i++;
                                        }
                                        int a = 0;
                                        try
                                        { a = Convert.ToInt32(Console.ReadLine()); }
                                        catch (FormatException ex)
                                        { 
                                            Console.WriteLine("\nЦифру введи, дубина!");
                                            isDone = false;
                                            break;
                                        } 
                                        var av = cages[a - 1];
                                        i = av.Units.Count;
                                        try
                                        {
                                            av.Add(animal);
                                            Done();
                                        }
                                        catch(ZooException ex)
                                        {
                                            Fail(ex);
                                        }
                                    }
                                    isDone = true;
                                    break;
                                default:
                                    isDone = false;
                                    break;
                            }
                        } while (!isDone);
                        break;
                    case ConsoleKey.I:
                        Console.WriteLine(zoo.Info());
                        break;
                    case ConsoleKey.D:
                        isDone = true;
                        do
                        {
                            Console.WriteLine("\na - животное\nc - клетку");
                            var k2 = Console.ReadKey();
                            switch(k2.Key)
                            {
                                case ConsoleKey.A:
                                    Animal[] animals = zoo.GetAnimals().ToArray();
                                    if (animals.Length > 0)
                                    {
                                        for (int i = 0; i < animals.Length; i++)
                                            Console.WriteLine("{0} - {1}", i + 1, animals[i]);
                                        int a = 0;
                                        try
                                        {
                                            a = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch (FormatException ex)
                                        {
                                            Console.WriteLine("\nЦифру введи, дубина!");
                                            isDone = false;
                                            break;
                                        }
                                        zoo.Remove(animals[a - 1]);
                                        Done();
                                    }
                                    else
                                        Console.WriteLine("\nВ зверинце нет животных!");
                                    isDone = true;
                                    break;
                                case ConsoleKey.C:
                                    Container[] cages = zoo.GetCages().ToArray();
                                    if (cages.Length > 0)
                                    {
                                        for (int i = 0; i < cages.Length; i++)
                                            Console.WriteLine("{0} - {1}", i + 1, cages[i]);
                                        int b = 0;
                                        try
                                        {
                                            b = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch (FormatException ex)
                                        {
                                            Console.WriteLine("\nЦифру введи, дубина!");
                                            isDone = false;
                                            break;
                                        }
                                        zoo.Remove(cages[b - 1]);
                                        Done();
                                    }
                                    else
                                        Console.WriteLine("\nВ зверинце нет клеток!");
                                    isDone = true;
                                    break;
                                default:
                                    isDone = false;
                                    break;
                            }
                        }
                        while (!isDone);
                        break;
                    case ConsoleKey.O:
                        isDone = true;
                        do
                        {
                            Console.WriteLine("\nd - сменить время суток\nv - подать голос\nw - средний вес\nc - общий вес");
                            var k3 = Console.ReadKey();
                            switch (k3.Key)
                            {
                                case ConsoleKey.D:
                                    zoo.ChangeTime();
                                    Done();
                                    Console.WriteLine("Текущее время суток: {0}", zoo.CurrentTimeOfDay == Menagerie.TimeOfDay.Day ? "день" : "ночь");
                                    isDone = true;
                                    break;
                                case ConsoleKey.V:
                                    Console.WriteLine(zoo.Voice());
                                    isDone = true;
                                    break;
                                case ConsoleKey.W:
                                    Console.WriteLine("Средний вес животного в зверинце: {0}", zoo.GetAverageWeight().ToString());
                                    isDone = true;
                                    break;
                                case ConsoleKey.C:
                                    Console.WriteLine("Общий вес животных в зверинце: {0}", zoo.GetWeight().ToString());
                                    isDone = true;
                                    break;
                                default:
                                    isDone = false;
                                    break;
                            }
                        }
                        while (!isDone);
                        break;
                }
            }
            Console.ReadKey();
        }

        public static Container ChooseCage(ConsoleKeyInfo key)
        {
            switch(key.Key)
            {
                case ConsoleKey.W:
                    return new CageForWolves();
                case ConsoleKey.B:
                    return new CageForBears();
                case ConsoleKey.G:
                    return new CageForGiraffes();
                case ConsoleKey.H:
                    return new AviaryForHerbivorous<Herbivorous>();
                case ConsoleKey.P:
                    return new AviaryForPredators<Predator>();
                default: return null;
            }
        }

        public static void Done()
        {
            Console.WriteLine("\nГотово!");
        }

        public static void Fail(Exception ex)
        {
            Console.WriteLine("\nНе удалось! " + ex.Message);
        }
    }
}
