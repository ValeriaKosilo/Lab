using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba9
{
    class Programmer
    {

        List<string> proger = new List<string>();

        public delegate void Example(string mes);
        public event Example Delete;
        public event Example ChangeLevel;

        public void AddElem(string item)
        {
            proger.Add(item);
        }

        public void InsertElem(int index, string item)
        {
            proger.Insert(index, item);
        }

        //Удаление эл-та из списка по заданному индексу
        public void RemoveElem(int index)
        {
            proger.RemoveAt(index);
        }

        //Вывод всех элементов списка
        public void Show()
        {
            foreach (string x in proger)
            {
                Console.WriteLine($"{x} ");
            }
        }
        //получение эл-та по индексу
        public string Elements(int i)
        {
            return proger[i];
        }
        //кол-во эл-тов в списке
        public int Count()
        {
            return proger.Count();
        }

        public void ProgDelete(string Name, Programmer proger)
        {
                int p = 0;
                for (int i = 0; i < proger.Count(); i++)
                {
                    if (Name == proger.Elements(i))
                    {
                        proger.RemoveElem(i);
                        p = 1;
                    }
                }
                if (p == 1)
                {
                    Delete.Invoke($"Программист { Name } удален из списка!");
                }
                else
                {
                    Delete.Invoke("Невозможно выполнить операцию!");
                }
        }

        public void ProgLevelUp(Programmer proger, int num)
        {
            if (num <= proger.Count())
            {
                    proger.InsertElem(0, proger.Elements(num));
                    proger.RemoveElem(num+1);

                    ChangeLevel.Invoke("Порядок списка программистов изменён!");
            }
            else
            {
                ChangeLevel.Invoke("Невозможно выполнить операцию!");
            }
        }
    }
        public class Stroke
        {
            public static string DoubleSpace(string a)
            {
                return a.Replace("  "," ");
            }

            public static string LowerCase(string a)
            {
                return a.ToLower();
            }

            public static string SubString(string a)
            {
                return a.Substring(0, 5);
            }

            public static string UpperCase(string a)
            {
                return a.ToUpper();
            }

            public static string AddDot(string a)
            {
                a += ".";
                return a;
            }

        public static void AddSym(string a)
        {
            a += "!";
            Console.WriteLine(a);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Programmer spisok1 = new Programmer();
            spisok1.AddElem("Карина");
            spisok1.AddElem("Максим");
            spisok1.AddElem("Егор");
            spisok1.AddElem("Валера");
            spisok1.Show();

            spisok1.Delete += mes => Console.WriteLine(mes);// Добавляем обработчик для события
            spisok1.ChangeLevel += mes => Console.WriteLine(mes);// Добавляем обработчик для события
            Console.WriteLine();

            Console.WriteLine();
            spisok1.ProgLevelUp(spisok1, 3);
            spisok1.ProgDelete("Максим", spisok1);
            spisok1.Show();


            Console.WriteLine();
            Programmer spisok2 = new Programmer();
            spisok2.AddElem("Кристина");
            spisok2.AddElem("Виктор");
            spisok2.AddElem("Яна");
            spisok2.AddElem("Оля");
            spisok2.Show();

            Console.WriteLine();
            spisok2.Delete += mes => Console.WriteLine(mes);// Добавляем обработчик для события
            spisok2.ChangeLevel += mes => Console.WriteLine(mes);// Добавляем обработчик для события

            Console.WriteLine();
            spisok2.ProgDelete("Вероника", spisok2);
            spisok2.ProgLevelUp(spisok2, 15);
            spisok2.Show();

            Console.WriteLine();
            string a = " Это  Последнее  Задание";
            Console.WriteLine(a);
            Console.WriteLine();

            //стандартный тип делегата
            Func<string, string> Str = Stroke.AddDot; // делегат указывает на метод AddDot
            Console.WriteLine(Str(a));

            Str = Stroke.DoubleSpace;
            Console.WriteLine(Str(a));

            Str = Stroke.SubString;
            Console.WriteLine(Str(a));

            Str = Stroke.UpperCase;
            Console.WriteLine(Str(a));

            Str = Stroke.LowerCase;
            Console.WriteLine(Str(a));

            Console.WriteLine();
            Action<string> Str1 = Stroke.AddSym;
            Str1(a);

            Console.ReadKey();

        }
    }
}
