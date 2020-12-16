using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba12
{
    interface Products
    {
        void Message();
    }
    public class Goods
    {
        public Goods() {}
        public double price { get; set; }
        public string name { get; set; }
        public int weight { get; set; }

    }
    class Flowers : Goods, Products
    {
        public int numbers { get; set; }
        public Flowers() {}
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
        public void Str(string str)
        {
            Console.WriteLine(str);
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
        public Pastry() { }
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
        public void Str(string str)
        {
            Console.WriteLine(str);
        }
    }
    class Reflector
    {
        public void AllContent(Type type, string path)//все содержимое
        {
            StreamWriter write = new StreamWriter(path, true);//если равно true, то новые данные добавляются в конец файла.
            var content = type.GetMembers();//возвращает все члены типа в виде массива объектов
            write.WriteLine("Cодержимое класса:");
            foreach (var x in content)
            {
                write.WriteLine(x.Name);
            }
            write.WriteLine();
            write.Close();
        }
        public void AllMetods(Type type, string path)//все публичные методы класса
        {
            StreamWriter write = new StreamWriter(path, true);
            var content = type.GetMethods();//получает все методы типа в виде массива объектов
            write.WriteLine("Методы класса: ");
            foreach (var x in content)
            {
                write.WriteLine(x.Name);
            }
            write.WriteLine();
            write.Close();
        }
        public void AllInformation(Type type, string path)//поля и свойства класса
        {
            StreamWriter write = new StreamWriter(path, true);
            var content = type.GetFields();//возвращает все поля данного типа
            write.WriteLine("Поля класса: ");
            foreach (var x in content)
            {
                write.WriteLine(x.Name);
            }
            write.WriteLine();

            var content1 = type.GetProperties();//получает все свойства
            write.WriteLine("Свойства класса: ");
            foreach (var x in content1)
            {
                write.WriteLine(x.Name);
            }
            write.WriteLine();
            write.Close();
        }

        public void AllInterface(Type type, string path)//все интерфейсы
        {
            StreamWriter write = new StreamWriter(path, true);
            var content = type.GetInterfaces();//получает все реализуемые данным типом интерфейсы
            write.WriteLine("Интерфейсы класса: ");
            foreach (var x in content)
            {
                write.WriteLine(x.Name);
            }
            write.WriteLine();
            write.Close();
        }

        public void SpecialMethods(Type type, string path, string parameter)//методы с заданным типом параметра
        {
            StreamWriter write = new StreamWriter(path, true);
            var content = type.GetMethods();//получает все методы типа
            write.WriteLine("Методы с определенным типом: ");
            foreach (var x in content)
            {
                foreach (var i in x.GetParameters())//получает параметры метода
                {
                    if (i.ParameterType.Name == parameter)//свойство для отображения имени типа каждого параметра
                        write.WriteLine(i.Name);
                }
            }
            write.WriteLine();
            write.Close();
        }

        public void Method(Type type, string name)//прочитать значения параметра метода
        {
            StreamReader read = new StreamReader(@"C:\Users\1\Lab\Str.txt");
            string str = read.ReadLine();
            read.Close();
            var content = type.GetMethod(name);//получает определённый метод типа по имени
            //создаем экземпляры заданного типа
            object new1 = Activator.CreateInstance(type);
            // вызываем метод, передаем ему значения для параметров и получаем результат
            object res = content.Invoke(new1, new object[] { str });
            //Здесь первый параметр представляет объект, для которого вызывается метод
            //а второй - набор параметров в виде массива object[].
            Console.WriteLine(res);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\1\Lab\Laba12.txt";
            Reflector reflector = new Reflector();

            Type class1 = typeof(Flowers);

            reflector.AllContent(class1, path);
            reflector.AllInformation(class1, path);
            reflector.AllInterface(class1, path);
            reflector.AllMetods(class1, path);
            reflector.SpecialMethods(class1, path, "String");

            Type class2 = typeof(Pastry);

            reflector.AllContent(class2, path);
            reflector.AllInformation(class2, path);
            reflector.AllInterface(class2, path);
            reflector.AllMetods(class2, path);
            reflector.SpecialMethods(class2, path, "String");
            reflector.Method(class2, "Str");

            Console.ReadKey();
        }
    }
}
