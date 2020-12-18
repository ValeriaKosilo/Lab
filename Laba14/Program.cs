using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;


namespace Laba14
{
    interface Products
    {
        void Message();
    }

    [Serializable]
    public abstract class Goods
    {
        public double price { get; set; }
        public string date { get; set; }
    }

    [Serializable]
    public class Product : Goods
    {
        public Product() {}
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
    class Program
    {
        static void Main(string[] args)
        {
            Product num1 = new Product(20.99, "15.12.2020", "Candy");
            Product num2 = new Product(15.55, "16.12.2020", "Flowers");
            Product num3 = new Product(30.99, "11.12.2020", "Clock");
            Product num4 = new Product(10.99, "05.12.2020", "Cake");

            Console.WriteLine("----------Задание 1----------");
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(@"C:\Users\1\Lab\1.dat", FileMode.OpenOrCreate))//режим доступа: если файл существует, он открывается, если нет - создается новый
            {
                formatter.Serialize(fs, num1);//метод для сериализации, в качестве параметров принимает поток, 
                //куда помещает сериализованные данные и объект, который надо сериализовать.
            }

            using (FileStream fs = new FileStream(@"C:\Users\1\Lab\1.dat", FileMode.OpenOrCreate))
            {
                Product newnum = (Product)formatter.Deserialize(fs);//метод для десериализации, в качестве параметра принимает поток с сериализованными данными.
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newnum.productname} --- Цена: {newnum.price}");
            }

            // создаем объект SoapFormatter
            SoapFormatter formatter1 = new SoapFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(@"C:\Users\1\Lab\2.soap", FileMode.OpenOrCreate))
            {
                formatter1.Serialize(fs, num2);
            }

            // десериализация
            using (FileStream fs = new FileStream(@"C:\Users\1\Lab\2.soap", FileMode.OpenOrCreate))
            {
                Product newnum1 = (Product)formatter1.Deserialize(fs);//преобразуем объект к типу Product
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newnum1.productname} --- Цена: {newnum1.price}");
            }

            DataContractJsonSerializer formatter2 = new DataContractJsonSerializer(typeof(Product));
            using (FileStream fs = new FileStream(@"C:\Users\1\Lab\3.json", FileMode.OpenOrCreate))
            {
                formatter2.WriteObject(fs, num3);
            }

            using (FileStream fs = new FileStream(@"C:\Users\1\Lab\3.json", FileMode.OpenOrCreate))
            {
                Product newnum2 = (Product)formatter2.ReadObject(fs);
                Console.WriteLine("Объект десериализован: ");
                Console.WriteLine($"Имя: {newnum2.productname} --- Цена: {newnum2.price}");
            }

            // передаем в конструктор тип класса
            XmlSerializer formatter3 = new XmlSerializer(typeof(Product));
            using (StreamWriter fs = new StreamWriter(@"C:\Users\1\Lab\4.xml"))
            {
                formatter3.Serialize(fs, num4);
            }

            using (StreamReader fs = new StreamReader(@"C:\Users\1\Lab\4.xml"))
            {
                Product newnum3 = (Product)formatter3.Deserialize(fs);
                Console.WriteLine("Объект десериализован: ");
                Console.WriteLine($"Имя: {newnum3.productname} --- Цена: {newnum3.price}");
            }

            Console.WriteLine();
            Console.WriteLine("----------Задание 2----------");
            Product[] num = new Product[] { num1, num2 };

            BinaryFormatter formatter5 = new BinaryFormatter();
            using (FileStream fs = new FileStream(@"C:\Users\1\Lab\4.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, num);
            }

            using (FileStream fs = new FileStream(@"C:\Users\1\Lab\4.dat", FileMode.OpenOrCreate))
            {
                Product[] new1 = (Product[])formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                foreach (Product p in new1)
                {
                    Console.WriteLine($"Имя: {p.productname} --- Цена: {p.price}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("----------Задание 3----------");
            XmlDocument Doc = new XmlDocument();
            Doc.Load(@"C:\Users\1\Lab\5-1.xml");
            XmlElement elem = Doc.DocumentElement;

            XmlNodeList childnodes = elem.SelectNodes("*");//выбор всех дочерних узлов текущего узла
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.OuterXml);

            XmlNode childnode = elem.SelectSingleNode("//student/BALL");//выбор единственного узла из выборки
            foreach (XmlNode n in childnode)
                Console.WriteLine(n.OuterXml);

            Console.WriteLine();
            Console.WriteLine("----------Задание 4----------");
            XDocument xml1 = new XDocument();
            XElement xroot = new XElement("root");

            XElement first = new XElement("flowers");
            XAttribute fl1 = new XAttribute("rose", "red");
            XElement prod1 = new XElement("lenght", "30");
            XElement kol1 = new XElement("number", "15");

            first.Add(prod1);
            first.Add(fl1);
            first.Add(kol1);

            XElement second = new XElement("flowers");
            XAttribute fl2 = new XAttribute("rose", "white");
            XElement prod2 = new XElement("lenght", "45");
            XElement kol2 = new XElement("number", "21");

            second.Add(prod2);
            second.Add(fl2);
            second.Add(kol2);

            xroot.Add(first);
            xroot.Add(second);

            xml1.Add(xroot);

            xml1.Save(@"C:\Users\1\Lab\6.xml");

            var one = xml1.Element("root").Elements("flowers").OrderBy(x => x.Element("lenght").Value);
            foreach (var i in one)
                Console.WriteLine(i);

            Console.WriteLine();
            var two = xml1.Element("root").Elements("flowers").Where(x => x.Element("number").Value == "21");
            foreach (var i in two)
                Console.WriteLine(i);

            Console.ReadLine();
        }
    }
}
