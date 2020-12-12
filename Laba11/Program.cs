using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Laba11
{
    public class Car
    {
        public string brand { get; set; } //марка
        public int yearofissue { get; set; } //год выпуска
        public string color { get; set; } //цвет
        public int price { get; set; } //цена

        public Car(string Brand, string Color, int Price, int yofi)
        { 
            brand = Brand;
            color = Color;
            price = Price;
            yearofissue = yofi;
        }

        public int AgeoftheCar() //возраст машины 
        {
            return 2020 - yearofissue;
        }
    }

    public class Vector
    {
        public int[] vect;
        public Vector(int[] Vect)
        {
            vect = Vect;
        }
        public int Length()
        {
            return vect.Length;
        }
        public void Show()
        {
            for (int i = 0; i < vect.GetLength(0); i++)
            {
                    Console.Write(vect[i] + " ");
            }
        }

        public bool Have()
        {
            int kol = 0;
            for (int i = 0; i < vect.GetLength(0); i++)
            {
                if (vect[i] == 0)
                    kol++;
            }
            if (kol > 0)
                return true;
            else
                return false;
        }
        public double Modul()
        {
            double mod = 0;
            for (int i = 0; i < vect.GetLength(0); i++)
            {
                mod += (vect[i])^2;
            }
            mod = Math.Sqrt(mod);
            return mod;
        }

        public bool Minus()
        {
            double otr = 0;
            for (int i = 0; i < vect.GetLength(0); i++)
            {
                if (vect[i] < 0)
                    otr++;
            }
            if (otr > 0)
                return true;
            else
                return false;
        }
    }
    class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------1 задание-------------");
            string[] month = {"January", "February", "March","April", "May", "June", "July", "August", "September", "October", "November", "December"};
            string[] sum_win = { "December", "January", "Ferbruary", "June", "July", "August"};
            int n = 5;

            IEnumerable<string> first = month.Where(l => l.Length == n);
            Console.WriteLine("Длина строки равна 5:");
            foreach (string x1 in first)
            {
                Console.WriteLine(x1);
            }
            Console.WriteLine();

            IEnumerable<string> second = month.Intersect(sum_win);
            Console.Write("Зимние и летние месяцы:");
            foreach (string x2 in second)
            {
                Console.WriteLine(x2);
            }
            Console.WriteLine();

            IEnumerable<string> third = month.OrderBy(x => x);
            Console.WriteLine("В алфавитном порядке:");
            foreach (string x3 in third)
            {
                Console.WriteLine(x3);
            }
            Console.WriteLine();

            Console.WriteLine("Содержат букву u, не менее 4 символов:");
            IEnumerable<string> fourth = from x in month
                                        where x.Length >= 4 & x.Contains("u")
                                        select x;

            foreach (string x4 in fourth)
            {
                Console.WriteLine(x4);
            }
            Console.WriteLine();

            Console.WriteLine("----------------2 задание-------------");
            List<Car> task2 = new List<Car>
            {
                new Car("Opel", "Blue", 200 ,2010),
                new Car("Bentley", "Black", 800 ,2018),
                new Car("BMW", "Red", 500 ,2001),
            };

            IEnumerable<Car> car = from i in task2
                                   orderby i.brand
                                   select i;

            Console.WriteLine("List содержит: ");
            foreach (Car i in car)
            {
                Console.WriteLine(i.brand);
            }
            Console.WriteLine();

            Console.WriteLine("----------------3 задание-------------");
            Vector v1 = new Vector(new int[] {1, 2, 5, 4});
            Vector v2 = new Vector(new int[] {1, 0, -3});
            Vector v3 = new Vector(new int[] {-1, 0});
            Vector v4 = new Vector(new int[] {0, 2, 3, 7, 11});
            Vector v5 = new Vector(new int[] {3});

            List<Vector> vector = new List<Vector> { };
            vector.Add(v1);
            vector.Add(v2);
            vector.Add(v3);
            vector.Add(v4);
            vector.Add(v5);

            var zero_kol = from x in vector
                           where x.Have()
                           select x;

            Console.Write("Количество векторов, содержащих 0: " + zero_kol.Count() + "\n");
            foreach (var x in zero_kol)
            {
                x.Show();
                Console.WriteLine();
            }

            Console.WriteLine("C наим модулем: ");
            var mod = vector.OrderBy(x => x.Modul());
            var less_mod = mod.Take(2);
            foreach (var x in less_mod)
            {
                x.Show();
                Console.WriteLine();
            }

            Console.WriteLine("Упорядоченный список по размеру: ");
            var max = vector.OrderBy(x => x.Length());
            foreach (var x in max)
            {
                x.Show();
                Console.WriteLine();
            }

            Console.WriteLine("Максимальный вектор: ");
            var max1 = max.Skip(mod.Count() - 1);
            foreach (var x in max1)
            {
                x.Show();
                Console.WriteLine();
            }

            Console.WriteLine("Первый вектор с отр занчением: ");
            var otr = from x in vector
                      where x.Minus()
                      select x;

            var first_otr = otr.Take(1);
            foreach (var x in first_otr)
            {
                x.Show();
                Console.WriteLine();
            }

            Console.WriteLine("Массив векторов длины - 3, 4, 5: ");
            var massiv = from x in vector
                      where x.Length() == 3 | x.Length() == 4 | x.Length() == 5
                      select x;

            foreach (var x in massiv)
            {
                x.Show();
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("----------------4 задание-------------");

            string[] tas4 = { "October", "September", "May"};
            IEnumerable<string> task4 = from x in month
                                        .Where(f => f.Contains("a"))//квантор и уловие
                                        .Take(3) //разбиение
                                        .OrderBy(f => f) //упорядочивание
                                        .Except(tas4) //множество
                                        select x;

            foreach (string i in task4)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            Console.WriteLine("----------------5 задание-------------");

            List<Team> teams = new List<Team>()
            {
                new Team { Name = "Бавария", Country ="Германия" },
                new Team { Name = "Барселона", Country ="Испания" }
            };
            List<Player> players = new List<Player>()
            {
                new Player {Name="Месси", Team="Барселона"},
                new Player {Name="Неймар", Team="Барселона"},
                new Player {Name="Роббен", Team="Бавария"}
            };

            var result = from pl in players
                         join t in teams on pl.Team equals t.Name //общий критерий - название команды
                         select new { Name = pl.Name, Team = pl.Team, Country = t.Country };

            foreach (var item in result)
                Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");
            Console.ReadLine();
        }
    }
}
