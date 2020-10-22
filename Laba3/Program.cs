using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    public partial class Car //ВАРИАНТ 9
    {
        private readonly int id; //поле только для чтения
        private string brand { get; set; } //марка
        private string model { get; set; } //модель
        private int yearofissue { get; set; } //год выпуска
        private string color { get; set; } //цвет
        private double price { get; set; } //цена
        private const int registnumber = 440551; //поле-константа
        private static int quantity; //стат. поле

        static Car() //статический конструктор
        {
            quantity = 0;
        }

        public Car() //не содержит параметры
        {
            id = GetHashCode();
            quantity++;
            brand = "BMW";
            model = "l3050";
            color = "teal";
            price = 230.25;
            yearofissue = 2002;
        }

        public Car(string Brand, string Model, string Color, double Price, int yofi) //содержит параметры
        {
            id = GetHashCode();
            quantity++;
            brand = Brand;
            model = Model;
            color = Color;
            price = Price;
            yearofissue = yofi;
        }

        // private Car() {} - закрытый конструктор
        public int AgeoftheCar() //возраст машины 
        {
            return 2020 - yearofissue;
        }

        public override bool Equals(object obj) //сравнение объектов
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Car mark = (Car)obj;
            return (this.model == mark.model && this.brand == mark.brand && this.color == mark.color);
        }

        public override int GetHashCode()
        {
            Random random = new Random();
            int hash = random.Next(516, 531);
            hash = 217 + (hash * 3);
            return hash;
        }

        public override string ToString()//вывод строки
        {
            return id + " " + model + " " + brand + " " + yearofissue + " " + color + " " + price + " " + registnumber;
        }

        public static void Choosethebrand(ref Car[] Allcars)//авто заданной марки
        {
            Console.Write("Введите название марки - ");
            string brandname = Console.ReadLine();

            for (int i = 0; i < Allcars.Length; i++)
            {
                if (Allcars[i].brand == brandname)
                {
                    Console.WriteLine(Allcars[i]);
                    Console.WriteLine();
                }
            }

        }

        public static void ModelandYOI(ref Car[] Allcars)//авто зад. модели, кот экс-ся больше n лет
        {
            Console.Write("Введите модель автомобиля - ");
            string modelname = Console.ReadLine();
            Console.Write("Введите минимальный возраст машины - ");
            int years = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < Allcars.Length; i++)
            {
                if ((Allcars[i].model == modelname) && (Allcars[i].AgeoftheCar() > years))
                {
                        Console.WriteLine(Allcars[i]);
                        Console.WriteLine();
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car num1 = new Car();
            Console.WriteLine(num1.ToString());
            Console.WriteLine("Возраст машины - " + num1.AgeoftheCar());

            Car num2 = new Car("Audi", "L1010", "blue", 230.99, 2000);
            Console.WriteLine(num2.ToString());
            Console.WriteLine("Идентичность машин - " + num2.Equals(num1));
            Console.WriteLine("Возраст машины - " + num2.AgeoftheCar());

            Car num3 = new Car("Cadillac", "P9910", "black", 299.99, 2015);
            Console.WriteLine(num3.ToString());
            Console.WriteLine("Возраст машины - " + num3.AgeoftheCar());

            Car num4 = new Car("Audi", "L1010", "black", 233.99, 2006);
            Console.WriteLine(num4.ToString());
            Console.WriteLine("Возраст машины - " + num4.AgeoftheCar());

            Car num5 = new Car("Bentley", "L2010", "red", 430.99, 2008);
            Console.WriteLine(num5.ToString());
            Console.WriteLine("Возраст машины - " + num5.AgeoftheCar());

            Car[] Allcars = new Car[] { num1, num2, num3, num4, num5 };
            
            Console.WriteLine("Список автомобилей заданной марки. ");
            Car.Choosethebrand(ref Allcars);

            Console.WriteLine("Список автомобилей заданной модели, которые эксплуатируются больше n лет.");
            Car.ModelandYOI(ref Allcars);

            var num6 = new { brand = "Bentley", model = "L5070", color = "grey" }; //анонимный тип
            Console.WriteLine(num6.GetType());
            Console.WriteLine(num6.brand);
            Console.WriteLine(num6.model);

            Console.ReadKey();
        }
    }
}
