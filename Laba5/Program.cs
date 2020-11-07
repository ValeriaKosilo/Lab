using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
    //Вариан 9 ---- Продукт, Кондитерское изделие, Товар, Цветы, Торт, Часы, Конфеты; 
    interface Products
    {
        void Message();
    }
    abstract class Goods
    {
        public double price { get; set; }
        public string date { get; set; }
    }
    class Product : Goods
    {
        public string productname { get; set; }
        public Product(double Price, string Date, string ProductName)
        {
            price = Price;
            date = Date;
            productname = ProductName;
        }
        public override string ToString()
        {
            return "Название продукта: " + productname + " Цена: " + price;
        }
    }

    class Flowers : Goods, Products
    {
        public string flowersname { get; set; }
        public int numbers { get; set; }
        public float length { get; set; }

        public Flowers(double Price, string Date, string FlowersName, int Numbers, float Length)
        {
            price = Price;
            date = Date;
            flowersname = FlowersName;
            numbers = Numbers;
            length = Length;
        }
        public void Message()
        {
            Console.WriteLine("Берите нечётное количество цветов!");
        }
        public override string ToString()
        {
            return "Название цветов: " + flowersname + " Цена: " + price;
        }
    }

    class Clock : Goods, Products
    {
        public string clockname { get; set; }
        public string color { get; set; }
        public Clock(double Price, string Date, string ClockName, string Color)
        {
            price = Price;
            date = Date;
            clockname = ClockName;
            color = Color;
        }
        public void Message()
        {
            Console.WriteLine("Часы без батарейки!");
        }
        public override string ToString()
        {
            return "Название часов: " + clockname + " Цена: " + price;
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
    class Pastry: SeeAll, ISeeAll
    {
        public string pastryname { get; set; }
        public int price { get; set; }
        public Pastry(int Price, string Pastryname)
        {
            price = Price;
            pastryname = Pastryname;
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
            return "Название продукта: " + pastryname + " Цена: " + price;
        }
    }
    sealed class Candy
    {
        public string candyname { get; set; }
        public int weight { get; set; }
        public Candy(string Candyname, int Weight)
        {
            candyname = Candyname;
            weight = Weight;
        }
        public override string ToString()
        {
            return "Название конфет: " + candyname + " Вес: " + weight;
        }
    }
    class Cake //переопределены все методы Object
    {
        public string cakename { get; set; }
        public string filling { get; set; }
        public int price { get; set; }
        public Cake(int Price, string CakeName, string Filling)
        {
            price = Price;
            cakename = CakeName;
            filling = Filling;
            
        }
        public override string ToString()
        {
            return "Название торта: " + cakename + " Цена: " + price + " Начинка: " + filling;
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
        public class Printer
        {
            public string IAmPrinting(Object obj)
            {
                return obj.ToString();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Product num1 = new Product(1.99, "29.10.2020", "Синия ручка");
                Console.WriteLine(num1.ToString());

                Flowers num2 = new Flowers(50.99, "28.10.2020", "Rosa", 15, 25);
                Console.WriteLine(num2.ToString());
                num2.Message();

                Clock num3 = new Clock(15.99, "12.10.2020", "Настенные", "Серебрянный");
                Console.WriteLine(num3.ToString());
                num3.Message();

                Pastry num4 = new Pastry(34, "Макарон");
                Console.WriteLine(num4.ToString());
                num4.Show();
                ((ISeeAll)num4).Show();

                Candy num5 = new Candy("Roshen", 2);
                Console.WriteLine(num5.ToString());

                Cake num6 = new Cake(12, "Наполеон", "Сгущёнка");
                Console.WriteLine(num6.ToString());
                Console.WriteLine(num6.GetHashCode());
                Console.WriteLine(num6.Equals(num5));

                Printer Printer = new Printer();
                Object[] mas = new Object[] {num1, num2, num3, num4, num5, num6};

                for (int i = 0; i < mas.Length; i++)
                {
                    Console.WriteLine(Printer.IAmPrinting(mas[i]));
                    Console.WriteLine();
                }

                if (num6 is Cake)
                {
                    Console.WriteLine("Это мой любимый торт!");
                }
                else
                {
                    Console.WriteLine("Это не мой любимый торт!");
                }
                Console.ReadKey();
            }
        }
    }
}
