using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Laba10
{
    public class Student
    {
        public string name;
        public string univ;
        public int course;

        public Student(string Name, string Univ, int Course)
        {
            name = Name;
            univ = Univ;
            course = Course;
        }

        public override string ToString()
        {
            return "Студент " + univ + " " + name + " " + course;
        }
    }

    abstract class Goods
    {
        public int price { get; set; }
        public string Name { get; set; }
    }
    class Product : Goods, IComparable
    {
        public Product(int Price, string ProductName)
        {
            price = Price;
            Name = ProductName;
        }
        public override string ToString()
        {
            return "Название продукта: " + Name + " Цена: " + price;
        }
        public int CompareTo(object o)
        {
            Product p = o as Product;
            return this.Name.CompareTo(p.Name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------Задание 1---------------------");
            ArrayList first = new ArrayList();

            //Добавляем 5 случайных чисел
            Random a = new Random();
            for (int i = 0; i < 5; i++)
            {
                int number = a.Next(0, 20);
                first.Add(number);
            }

            //Добавляем строку
            string str = "Добавь меня в коллекцию!";
            first.Add(str);

            //Добавляем объект класса
            Student numb1 = new Student("BSTU", "Anna", 2);
            first.Add(numb1);

            Console.WriteLine("Удалить элемент из коллекции, введите индекс элемента");
            int index = Convert.ToInt32(Console.ReadLine());
            if (index < first.Count)
            {
                first.RemoveAt(index);
                Console.WriteLine("Элемент удален!");
            }
            else
                Console.WriteLine("Элемента с таким индексом нет!");
            Console.WriteLine();

            Console.WriteLine("Количество элементов: " + first.Count);
            foreach (object x in first)
            {
                if (x is Student)
                {
                    Console.WriteLine(x.ToString());
                }
                else
                    Console.WriteLine(x);
            }

            Console.WriteLine();
            Console.WriteLine("Поиск значения 26: ");
            if (first.Contains(26))
                Console.WriteLine("Элемент найден!");
            else
                Console.WriteLine("Такого элемента нет!");
            Console.WriteLine();


            Console.WriteLine("-----------------Задание 2---------------------");
            SortedSet<float> second = new SortedSet<float>();
            second.Add(3.14F);
            second.Add(3.15F);
            second.Add(3.16F);
            second.Add(3.17F);
            second.Add(3.18F);

            Console.WriteLine("Количество элементов: ");
            foreach (object x in second)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            // удаляем элементы 1 и 2
            second.RemoveWhere(item => item == 3.14F || item == 3.15F);
            foreach (object x in second)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            second.Add(30.6F);
            second.Add(31.5F);

            Queue<float> second2 = new Queue<float>();
            foreach (float x in second)
            {
                second2.Enqueue(x);
            }

            Console.WriteLine("Элементы 2 коллекции: ");
            foreach (float x in second2)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            Console.WriteLine("Поиск значения 30.6F: ");
            if (second2.Contains(30.6F))
                Console.WriteLine("Элемент найден!");
            else
                Console.WriteLine("Такого элемента нет!");
            Console.WriteLine();


            Console.WriteLine("-----------------Задание 3---------------------");

            Product num1 = new Product(20, "Синия ручка");
            Product num2 = new Product(25, "Красная ручка");
            Product num3 = new Product(30, "Зелёная ручка");

            SortedSet<Product> third = new SortedSet<Product>();
            third.Add(num1);
            third.Add(num2);
            third.Add(num3);

            Console.WriteLine("Количество элементов: ");
            foreach (object x in third)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            third.RemoveWhere(item => item == num1 || item == num2);
            foreach (object x in third)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            Product num4 = new Product(35, "Желтая ручка");
            Product num5 = new Product(40, "Черная ручка");
            third.Add(num4);
            third.Add(num5);

            Queue<Product> second3 = new Queue<Product>();
            foreach (Product x in third)
            {
                second3.Enqueue(x);
            }

            Console.WriteLine("Элементы 2 коллекции: ");
            foreach (Product x in second3)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            Console.WriteLine("Поиск значения - черная речка: ");
            if (second3.Contains(num5))
                Console.WriteLine("Элемент найден!");
            else
                Console.WriteLine("Такого элемента нет!");
            Console.WriteLine();

            Console.WriteLine("-----------------Задание 4---------------------");

            ObservableCollection<Product> fourth = new ObservableCollection<Product>();

            fourth.CollectionChanged += CollChanged;

            fourth.Add(num1);
            fourth.Add(num2);
            fourth.Add(num3);

            fourth.RemoveAt(0);

            void CollChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add: // если добавление
                        Product add = e.NewItems[0] as Product;
                        Console.WriteLine($"Добавлен новый объект: {add.Name}");
                        break;
                    case NotifyCollectionChangedAction.Remove: // если удаление
                        Product delete = e.OldItems[0] as Product;
                        Console.WriteLine($"Удален объект: {delete.Name}");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
