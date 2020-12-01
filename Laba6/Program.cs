using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Laba6
{
    //Вариан 9 ---- Продукт, Кондитерское изделие, Товар, Цветы, Торт, Часы, Конфеты; 
    interface Products
    {
        void Message();
    }
    public class Goods
    {
        public double price { get; set; }
        public string name { get; set; }
        public int weight { get; set; }

    }
    class Product : Goods
    {
        public Product(double Price, string ProductName, int Weight)
        {
            price = Price;
            name = ProductName;
            weight = Weight;
        }
        public override string ToString()
        {
            return "Название продукта: " + name + " Цена: " + price + " Вес: " + weight;
        }
    }

    class Flowers : Goods, Products
    {
        public int numbers { get; set; }

        public Flowers(double Price, string FlowersName, int Numbers, int Weight)
        {
            price = Price;
            name = FlowersName;
            numbers = Numbers;
            weight = Weight;
        }
        public void Message()
        {
            Console.WriteLine("Берите нечётное количество цветов!");
        }
        public override string ToString()
        {
            return "Название цветов: " + name + " Цена: " + price + " Вес: " + weight;
        }
    }

    class Clock : Goods, Products
    {
        public string color { get; set; }
        public Clock(double Price, string ClockName, string Color, int Weight)
        {
            price = Price;
            name = ClockName;
            color = Color;
            weight = Weight;
        }
        public void Message()
        {
            Console.WriteLine("Часы без батарейки!");
        }
        public override string ToString()
        {
            return "Название часов: " + name + " Цена: " + price + " Вес: " + weight;
        }
    }
    interface ISeeAll // одноименные методы
    {
        void Show();
    }
    abstract class SeeAll
    {
        public abstract void Show();
    }
    class Pastry : SeeAll, ISeeAll
    {
        public string pastryname { get; set; }
        public int price { get; set; }
        public int weight { get; set; }

        public Pastry(int Price, string Pastryname, int Weight)
        {
            price = Price;
            pastryname = Pastryname;
            weight = Weight;
        }
        void ISeeAll.Show()
        {
            Console.WriteLine("Кондитерские изделия лучшего качества!");
        }
        public override void Show()
        {
            Console.WriteLine("Скида 10% на первую покупку!");
        }
        public override string ToString()
        {
            return "Название продукта: " + pastryname + " Цена: " + price + " Вес: " + weight;
        }
    }
    sealed class Candy: Goods
    {
        public Candy(string Candyname, int Weight, double Price)
        {
            name = Candyname;
            weight = Weight;
            price = Price;
        }
        public override string ToString()
        {
            return "Название конфет: " + name + " Цена: " + price + " Вес: " + weight;
        }
    }
    class Cake //переопределены все методы Object
    {
        public string cakename { get; set; }
        public string filling { get; set; }
        public int price { get; set; }
        public int weight { get; set; }

        public Cake(int Price, string CakeName, string Filling, int Weight)
        {
            price = Price;
            cakename = CakeName;
            filling = Filling;
            weight = Weight;

        }
        public override string ToString()
        {
            return "Название торта: " + cakename + " Цена: " + price + " Начинка: " + filling + " Вес: " + weight;
        }

        public override int GetHashCode()
        {
            Random random = new Random();
            int hash = random.Next(45, 89);
            hash = ((hash + 230) * 12);
            return hash;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            obj = obj as Cake;
            if (obj != null)
                return true;
            else
                return false;
        }
    }
    public class Printer
    {
        public string IAmPrinting(Object obj)
        {
            return obj.ToString();
        }
    }
    //--------------------------6 лабораторная работа-------------------------------------
    struct Owner
    {
        public int id;
        public string name;
        public string organization;

        public Owner(int Id, string Name, string Organization)
        {
            id = Id;
            name = Name;
            organization = Organization;
        }
        public void Show()
        {
            Console.WriteLine("Вариант: " + id + " Имя: " + name + " Университет: " + organization);
        }
    }

    enum Podarok
    {
        Flowers, Candy, Clock, Cake
    }

    public static class Present
    {
        public static List<Goods> podarok = new List<Goods>();

        //Добавление элемента в список
        public static void AddElem(Goods elem)
        {
            podarok.Add(elem);
        }
        //Удаление эл-та из списка
        public static void DeleteElem(Goods elem)
        {
            podarok.Remove(elem);
        }
        //Вывод всех элементов списка
        public static void ShowElem()
        {
            foreach (object x in podarok)
            {
                Console.WriteLine($"{x} ");
            }
        }
    }

    public partial class Controller
    {
        static double full_cost = 0;
        static int min = 9999;

        // Полная стоимость подарка
        public static void CostOfPresent()
        {
            foreach (Goods i in Present.podarok)
            {
                full_cost += i.price;
            }
            Console.WriteLine("Цена подарка: " + full_cost);
        }

        //Сортировка по весу
        public static void Sort()
        {
            var SortTheList = Present.podarok.OrderBy(i => i.weight);
            //производит сортировку по возрастанию, принимает критерий сортировки                 
            foreach (var i in SortTheList)
                Console.WriteLine(i.name+ " - " + i.weight);
        }
    }

    class Program
        {
            static void Main(string[] args)
            {
            //---------------------------5 лабораторная работа-----------------------------
            Console.WriteLine("__________________5 лабораторная__________________");

            Product num1 = new Product(1.99, "Синия ручка", 100);
            Console.WriteLine(num1.ToString());
            Console.WriteLine();

            Flowers num2 = new Flowers(50.99, "Rose", 15, 3000);
            Console.WriteLine(num2.ToString());
            num2.Message();
            Console.WriteLine();

            Clock num3 = new Clock(15.99, "Настенные часы", "Серебрянный", 3500);
            Console.WriteLine(num3.ToString());
            num3.Message();
            Console.WriteLine();

            Pastry num4 = new Pastry(34, "Макарон", 200);
            Console.WriteLine(num4.ToString());
            num4.Show();
            ((ISeeAll)num4).Show();
            Console.WriteLine();

            Candy num5 = new Candy("Roshen", 500, 12.87);
            Console.WriteLine(num5.ToString());
            Console.WriteLine();

            Cake num6 = new Cake(12, "Наполеон", "Сгущёнка", 2000);
            Console.WriteLine(num6.ToString());
            Console.WriteLine(num6.GetHashCode());
            Console.WriteLine(num6.Equals(num5));
            Console.WriteLine();

            Printer Printer = new Printer();
            Object[] mas = new Object[] { num1, num2, num3, num4, num5, num6 };
            
            for (int i = 0; i < mas.Length; i++)
            {
                Console.WriteLine(Printer.IAmPrinting(mas[i]));
            }

            if (num6 is Cake)
            {
                Console.WriteLine("Это мой любимый торт!");
            }
            else
            {
                Console.WriteLine("Это не торт!");
            }

            //---------------------------6 лабораторная работа-----------------------------
            Console.WriteLine();
            Console.WriteLine("__________________6 лабораторная__________________");


            Console.WriteLine("Подарок состоит из ");
            foreach (object i in Podarok.GetNames(typeof(Podarok)))
            {
                Console.WriteLine(i + " ");
            }

            Console.WriteLine();
            Owner owner1 = new Owner(9, "Valeria Kosilo", "BSTU");
            owner1.Show();

            Console.WriteLine();
            Present.AddElem(num1);
            Present.AddElem(num2);
            Present.AddElem(num3);
            Present.AddElem(num5);
            Present.ShowElem();
            Console.WriteLine();

            Controller.CostOfPresent();
            Console.WriteLine();

            Controller.LessNumbOfMass();
            Console.WriteLine();

            Console.WriteLine("Сортировка по весу:");
            Controller.Sort();

            Console.ReadKey();
        }
    }
}