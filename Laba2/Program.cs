using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    class Program
    {
		static void Main(string[] args)
		{
//--------------------------------------------------------Задание 1-------------------------------------------------------------
			sbyte bit1 = 100; //хранит целое число от -128 до 127
			short number1 = 2002; //хранит целое число от -32768 до 32767
			int age = 18; //целое число
			long numbers1 = -8748338647; //целое число
			byte bit2 = 255; //хранит целое число от 0 до 255
			ushort number2 = 2001; // хранит целое число от 0 до 65535
			uint al = 555555; //хранит целое число от 0 до 4294967295
			ulong numbers2 = 18446744073; //целое число
			char name1 = 'V'; //хранит одиночный символ
			bool fir = true; // логический тип
			float height = 160; //хранит число с плавающей точкой 
			double weight = 51.34; //хранит число с плавающей точкой 
			decimal something = 555; //хранит десятичное дробное число
			string name2 = "Valeria"; //хранит набор символов
			object word = "hello"; //хранит значение любого типа данных

			//неявное преобразование
			int i32 = 5;

			object ppp = i32;
			float l = i32;
			long papp = i32;
			double sp = i32;
			Decimal p = i32;
			
			//явное преобразование
			Byte b = (Byte)i32;
			short v = (short)sp;
			ulong с = (ulong)l;
			double q = (double)p;
			float w = (float)name1;

			//упаковка
			Object x = i32;
			//распаковка и привидение типа
			byte m = (byte)(int)x;


			var city = 12;
			Console.WriteLine("Type city: {0}", city.GetType());

			Nullable<int> last = 15;
			Console.WriteLine(last.Value);
			Console.WriteLine();

//--------------------------------------------------------Задание 2-------------------------------------------------------------

			string name = "Valeria";
			string surname = "Kosilo";
			Console.WriteLine(string.Compare(name, surname));

			string first = "Первая строка содержит";
			string second = "Вторая строка";
			string third = "Третья строка";
			Console.WriteLine(string.Concat(first, " ", second));
			string forth = string.Copy(third);
			Console.WriteLine(forth);
			Console.WriteLine(forth.Substring(2, 9));
			Console.WriteLine("Разделение 1 строки на слова:");
			string[] slov = first.Split(' ');
			foreach(string slov1 in slov)
			{
				Console.WriteLine(slov1);
			}
			Console.WriteLine(second.Insert(3, third));
			Console.WriteLine(second.Remove(3, 5));

			string s = "";
			string n = null;
			Console.WriteLine(String.IsNullOrEmpty(s));//возвр true если пустая или 0
			Console.WriteLine(String.IsNullOrWhiteSpace(n)); //Возвращает значение true, если параметр value равен null 

			StringBuilder abc = new StringBuilder("last exesize", 50);
			abc.Append(new char[] { '1', '2', '3' });
			abc.AppendFormat(" lolo int the end");
			abc.Remove(0, 2);
			Console.WriteLine();
//--------------------------------------------------------Задание 3-------------------------------------------------------------

			int[,] massiv = new int[2, 2] { { 1, 2 }, { 3, 4 } };
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 2; j++)
				{
					Console.WriteLine($"{ massiv[i, j]} \t");
				}
				Console.WriteLine();
			}

			string[] massiv2 = new[] { "write smth", "be careful", "main focus", "for today" };
			Console.WriteLine("Одномернный массив строк");
			for (int i = 0; i < massiv2.Length; i++)
			{
				Console.WriteLine(massiv2[i]);
			}
			Console.WriteLine("Длина массива" + massiv2.Length);
			Console.WriteLine("Введите позицию для смены эл-та");
			string ch = "change";
			int pos = Int32.Parse(Console.ReadLine()); //преобразовать строку к данному типу
			massiv2[pos] = ch;
			foreach (string d in massiv2)
			{
				Console.WriteLine(d);
			}

			double[][] a = new double[3][];
			a[0] = new double[2];
			a[1] = new double[3];
			a[2] = new double[4];

			Console.WriteLine("Введите элементы массива 1");
			for (int i = 0; i < 2; i++)
			{
				int elem = Int32.Parse(Console.ReadLine());
				a[0][i] = elem;
			}
			for (int i = 0; i < 2; i++)
				Console.Write(a[0][i] + " ");
			Console.WriteLine();

			Console.WriteLine("Введите элементы массива 2");
			for (int i = 0; i < 3; i++)
			{
				int elem = Int32.Parse(Console.ReadLine());
				a[1][i] = elem;
			}
			for (int i = 0; i < 3; i++)
				Console.Write(a[1][i] + " ");
			Console.WriteLine();

			Console.WriteLine("Введите элементы массива 3");
			for (int i = 0; i < 4; i++)
			{
				int elem = Int32.Parse(Console.ReadLine());
				a[2][i] = elem;
			}
			for (int i = 0; i < 4; i++)
				Console.Write(a[2][i] + " ");
			Console.WriteLine();


			var mass1 = new[] { 1, 2, 3 };
			var mass2 = new[] { "english", "russian" };
			Console.WriteLine($"Тип массива 1 - { mass1.GetType()}");
			Console.WriteLine($"Тип массива 2 - { mass2.GetType()}");
			Console.WriteLine();
//--------------------------------------------------------Задание 4-------------------------------------------------------------

			ValueTuple<int, string, char, string, ulong> kort = (1, "last try", 'z', "lolo lala", 55);
			Console.WriteLine(kort);
			Console.WriteLine($"Элементы 1, 3, 4 -- {kort.Item1+ " " + kort.Item3 + " "+ kort.Item4}");

			var (one, two, three) = (2, "las", 't');
			Console.WriteLine($"распаковка -  {one} {two} {three}");

			ValueTuple<int, string> kort1 = (1, "one");
			ValueTuple<int, string> kort2 = (2, "two");
			if (kort1 == kort2)
				Console.WriteLine("Кортежи равны");
			else
				Console.WriteLine("Кортежи не равны");
			Console.WriteLine();
//--------------------------------------------------------Задание 5-------------------------------------------------------------

			string str = "some words";
			int[] massiv4 = new int[3] { 1, 2, 3 };
			var result = GetResult(massiv4, str);
			Console.WriteLine(result);
			Console.Read();
		}

			static (int, int, string) GetResult(int[] massiv4, string str)
			{
				int max = 0;
				int min = 100;
				for (int i = 0; i < 3; i++)
				{
					if (massiv4[i] > max)
					{
						max = massiv4[i];
					}
				}
				for (int i = 0; i < 3; i++)
				{
					if (massiv4[i] < min)
					{
						min = massiv4[i];
					}
				}
				string firstl = str.Substring(0, 1);
				var result = (max, min, firstl);
				return result;
			}
	}
}
