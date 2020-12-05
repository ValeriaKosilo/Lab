using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Laba8
{
    class OutOfRange : Exception //исключение
    {
        public OutOfRange(string message) : base(message) { }
    }
    interface IAll<T> //обощенный интерфейс
    {
        void AddElem(T elem);

        void Delete(T elem);

        void ShowElem();
    }

    public class Good { }
    public class Example<T> where T : Good { }
    //должен быть классом Good или его наследником

    public class CollectionType<T> : IAll<T>
    {
        List<T> str = new List<T>(); 

        //Добавление элемента в конец
        public void AddElem(T elem)
        {
            str.Add(elem);
        }

        //Удаление эл-та по заданному индексу
        public void DeleteElem(int index)
        {
            if (index > str.Count())//!!!!!!!!!!!!!!!!!!!
                throw new OutOfRange("Такого индекса нет!");
            else
                str.RemoveAt(index);
        }

        //Удаление зданного эл-та 
        public void Delete(T elem)
        {
            str.Remove(elem);
        }

        //Вывод всех элементов
        public void ShowElem()
        {
            foreach (T x in str)
            {
                Console.WriteLine($"{x} ");
            }
        }
        //получение эл-та по индексу
        public T Elements(int i)
        {
            return str[i];
        }
        //кол-во эл-тов
        public int Count()
        {
            return str.Count();
        }

        //проверка на равенство
        public static bool operator ==(CollectionType<T> str1, CollectionType<T> str2)
        {
            int x = 0;
            if (str1.Count() != str2.Count())
                return false;
            else
            {
                for (int i = 0; i < str1.Count(); i++)
                {
                    if (str1.str.Contains(str2.Elements(i)))
                        x++;
                }
                if (x == str1.Count())
                    return true;
                else
                    return false;
            }
        }
        //проверска на неравенство
        public static bool operator !=(CollectionType<T> str1, CollectionType<T> str2)
        {
            int x = 0;
            if (str1.Count() != str2.Count())
                return true;
            else
            {
                for (int i = 0; i < str1.Count(); i++)
                {
                    if (str1.str.Contains(str2.Elements(i)))
                        x++;
                }
                if (x == str1.Count())
                    return false;
                else
                    return true;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            return true;
        }

        public override int GetHashCode()
        {
            Random random = new Random();
            int hash = random.Next(516, 531);
            hash = 217 + (hash * 3);
            return hash;
        }

        //проверка, пустой ли список
        public static bool operator true(CollectionType<T> str1)
        {
            int x = str1.Count();
            if (x == 0)
                return true;
            else
                return false;
        }
        //проверка, непустой ли список
        public static bool operator false(CollectionType<T> str1)
        {
            int x = str1.Count();
            if (x == 0)
                return false;
            else
                return true;
        }
    }

    abstract class Goods
    {
        public double price { get; set; }
        public string date { get; set; }
        public string productname { get; set; }
    }
    class Product : Goods
    {
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

    class Program
    { 
        static void Main(string[] args)
        {
            CollectionType<int> num1 = new CollectionType<int>();
            num1.AddElem(1);
            num1.AddElem(2);
            num1.AddElem(3);

            Console.WriteLine("Вывод элементов списка:");
            num1.ShowElem();
            Console.WriteLine();

            Console.WriteLine("Удаление элемента списка - 3:");
            num1.Delete(3);
            num1.ShowElem();

            CollectionType<string> num2 = new CollectionType<string>();
            num2.AddElem("1");
            num2.AddElem("2");
            num2.AddElem("3");
            Console.WriteLine();


            Console.WriteLine("Вывод элементов списка:");
            num2.ShowElem();
            Console.WriteLine();

            Console.WriteLine("Удаление элемента списка - 3:");
            num2.Delete("3");
            num2.ShowElem();
            Console.WriteLine();

            CollectionType<Product> num3 = new CollectionType<Product>();
            Product num4 = new Product(23.99, "23.11.2020", "Cake");
            Product num5 = new Product(25.9, "20.11.2020", "Clock");
            num3.AddElem(num4);
            num3.AddElem(num5);
            Console.WriteLine("Вывод элементов списка:");
            num3.ShowElem();
            Console.WriteLine();

            Console.WriteLine("Проверка на равенство 2 списков");
            if(num4 == num5)
                Console.WriteLine("Равны");
            else
                Console.WriteLine("Не равны");
            Console.WriteLine();

            Console.WriteLine("Проверка пустой список или нет");
            if (num1)
                Console.WriteLine("Список пуст");
            else
                Console.WriteLine("Список не является пустым");
            Console.WriteLine();


            try
            {
                num3.DeleteElem(5);
            }

            catch(OutOfRange ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                Console.WriteLine("Конец!");
            }

            Console.ReadLine();
        }
    }
}
