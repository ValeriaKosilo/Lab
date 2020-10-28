using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    public class Spisok
    {
        List<string> str = new List<string>(); //создание списка, для объектов типа string
        //Основные методы
        //Добавление элемента в конец списка
        public void AddElem(string item)
        {
            str.Add(item);
        }
        //вставка эл-та item в список на позицию index
        public void InsertElem(int index, string item)
        {
            str.Insert(index, item);
        }
        //Удаление эл-та из списка по заданному индексу
        public void RemoveElem(int index)
        {
            str.RemoveAt(index);
        }
        //Вывод всех элементов списка
        public void Show()
        {
            foreach (string x in str)
            {
                Console.WriteLine($"{x} ");
            }
        }
        //получение эл-та по индексу
        public string Elements(int i)
        {
            return str[i];
        }
        //кол-во эл-тов в списке
        public int Count()
        {
            return str.Count();
        }
        //Очистка списка
        public void ClearTheList()
        {
            str.Clear();
        }

        //соединение 2-х списков
        public static Spisok operator +(Spisok str1, Spisok str2)
        {
            int x = str2.Count();
            for (int i = 0; i < x; i++)
            {
                string elem = str2.Elements(i);
                str1.AddElem(elem);
            }
            return str1;
        }

        //удалить элемент из начала
        public static Spisok operator --(Spisok str1)
        {
            str1.RemoveElem(0);
            return str1;
        }

        //проверка на равенство
        public static bool operator ==(Spisok str1, Spisok str2)
        {
            int x = 0;
            if (str1.Count() != str2.Count())
                return false;
            else
            {
                for (int i = 0; i < str1.Count(); i++)
                {
                    if (str1.Elements(i) == str2.Elements(i))
                        x++;
                }
                if (x == str1.Count())
                    return true;
                else
                    return false;
            }
        }
        //проверска на неравенство
        public static bool operator !=(Spisok str1, Spisok str2)
        {
            int x = 0;
            if (str1.Count() != str2.Count())
                return true;
            else
            {
                for (int i = 0; i < str1.Count(); i++)
                {
                    if (str1.Elements(i) == str2.Elements(i))
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
        public static bool operator true(Spisok str1)
        {
            int x = str1.Count();
            if (x == 0)
                return true;
            else
                return false;
        }
        //проверка, непустой ли список
        public static bool operator false(Spisok str1)
        {
            int x = str1.Count();
            if (x == 0)
                return false;
            else
                return true;
        }

        public class Owner
        {
            public int id = 9;
            public string name = "Valeria Kosilo";
            public string organization = "BSTU";
        }

        public class Date
        {
            public string date;
            public Date()
            {
                date = DateTime.Now.ToString();
            }
        }

    }
    public static class StatisticOperation
    { 
        //сумма
        public static void Summ(Spisok str1)
        {
            string StrSum = "";
            for(int i = 0; i < str1.Count(); i++)
            {
                StrSum += str1.Elements(i);
            }
            Console.WriteLine("Весь список - " + StrSum);
        }

        //разница между max и min эл-тами списка
        public static void Difference(Spisok str1)
        {
            int max = 0, min = 999;
            for(int i = 0; i < str1.Count(); i++)
            {
                string oop = str1.Elements(i);
                if (oop.Length > max)
                    max = oop.Length;
                if (oop.Length < min)
                    min = oop.Length;
            }
            int diff = max - min;
            Console.WriteLine("Разница между max и min эл-тами - " + diff);
        }

        //кол-во эл-тов списка
        public static void NumberOfElements(Spisok str1)
        {
            int x = str1.Count();
            Console.WriteLine("Количество эл-тов в списке - " + x);
        }
        //выделение последнего числа строки
        public static void LastNumber(this string str3)
        {
            int x = 0;
            for (int i = 0; i < str3.Length; i++)
            {
                if (Char.IsNumber(str3, i))//является ли символ числом
                {
                    x = i;
                }
            }
            Console.WriteLine("Последнее число в строке" + str3[x]);
        }
        //Удаление заданного эл-та списка
        public static void DeleteElement(this Spisok str1)
        {
            Console.WriteLine("Введите элемент, который нужно удалить");
            string delete = Console.ReadLine();
            for(int i = 0; i < str1.Count(); i++)
            {
                string elem = str1.Elements(i);
                if (delete == elem)
                    str1.RemoveElem(i);
            }
        }
    }
    class Program
        {
        static void Main(string[] args)
        {
            Spisok.Owner i = new Spisok.Owner();
            Console.WriteLine(i.id + " " + i.name + " " + i.organization);

            Spisok.Date time = new Spisok.Date();
            Console.WriteLine(time.date);

            Spisok str1 = new Spisok();
            str1.AddElem("Врач");
            str1.AddElem("Программист");
            str1.AddElem("Учитель");
            str1.AddElem("Дизайнер");

            Console.WriteLine("Весь список:");
            str1.Show();

            Console.WriteLine("Удаление элемента из начала списка");
            str1 = str1--;
            str1.Show();


            Console.WriteLine("Проверка, пустой ли список");
            if (str1)
                Console.WriteLine("Список пустой");
            else
                Console.WriteLine("Список не является пустым");


            Spisok str2 = new Spisok();
            str2.AddElem("Журналист");
            str2.AddElem("Тренер");
            str2.AddElem("Дворник");


            Console.WriteLine("Проверка на равенство: ");
            bool equal = str1 == str2;
            if (equal)
                Console.WriteLine("Списки равны");
            else
                Console.WriteLine("Списки не равны");


            Console.WriteLine("Объединение 2-х списков");
            str1 = str1 + str2;
            str1.Show();

            StatisticOperation.NumberOfElements(str1);
            StatisticOperation.Summ(str1);
            StatisticOperation.Difference(str1);

            string str3 = "Blala 78 lala 45 lolo 8";
            str3.LastNumber();

            str1.DeleteElement();
            Console.WriteLine("Удаление заданного эл-та: ");
            str1.Show();

            Console.ReadKey();
        }
    }
}
