using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Lab13
{
    public class KVVLog 
    { 
        public static void AddSmth(string str)//Добавление записи в файл
        {
            StreamWriter write = new StreamWriter(@"C:\Users\1\source\repos\KVVlogfile.txt", true);
            write.WriteLine(str + " " + DateTime.Now);
            write.Close();
        }
        public static void Show()//Вывод всех записей
        {
            StreamReader read = new StreamReader(@"C:\Users\1\source\repos\KVVlogfile.txt");
            Console.WriteLine(read.ReadToEnd());
            read.Close();
        }
        public static int Kol()//количество записей в файле
        {
            StreamReader read = new StreamReader(@"C:\Users\1\source\repos\KVVlogfile.txt");
            string str = read.ReadLine();
            int kol = 0;
            while (str != null)//читаем по одной линии(строке)
            {
                kol++;
                str = read.ReadLine();
            }
            return kol;
        }
        public static void Inf()
        {
            StreamReader read = new StreamReader(@"C:\Users\1\source\repos\KVVlogfile.txt");
            Console.WriteLine("Информация: 1-Время, 2-Дата, 3-Ключ.слово");
            string find = Console.ReadLine();
            switch (find)
            {
                case "1":
                    {
                        Console.WriteLine("Введите начало времени:");
                        string time1 = Console.ReadLine();
                        int hour1 = Convert.ToInt32(time1);
                        Console.WriteLine("Введите конец времени:");
                        string time2 = Console.ReadLine();
                        int hour2 = Convert.ToInt32(time2);
                        while (!read.EndOfStream)
                        {
                            string str = read.ReadLine();
                            int symbol = str.IndexOf(":");
                            string hour = str.Substring(symbol - 2, 2);
                            int Hour = Convert.ToInt32(hour);
                            if (Hour >= hour1 && Hour <= hour2)
                            {
                                    Console.WriteLine(str);
                            }
                        }
                        read.Close();
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Введите дату для поиска:");
                        string data = Console.ReadLine();
                        while (!read.EndOfStream)
                        {
                            string str = read.ReadLine();
                            if (str.Contains(data))
                            {
                                Console.WriteLine(str);
                            }
                        }
                        read.Close();
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("Введите ключевое слово: ");
                        string word = Console.ReadLine();
                        while (!read.EndOfStream)
                        {
                            string str = read.ReadLine();
                            if (str.Contains(word))
                            {
                                Console.WriteLine(str);
                            }
                        }
                        read.Close();
                        break;
                    }
            }
        }
        public static void Delete() //Запись за текущий час
        {
            DateTime date = new DateTime();
            date = DateTime.Now;
            string time = Convert.ToString(date);
            int symbol = time.IndexOf(":");//первого вхождения отдельного символа
            int hour = Convert.ToInt32(time.Substring(symbol - 2, 2));
            int hourtime = hour + 1;
            StreamReader read = new StreamReader(@"C:\Users\1\source\repos\KVVlogfile.txt");
            FileInfo file = new FileInfo(@"C:\Users\1\Lab\Newone");
            StreamWriter new1 = File.CreateText(file.FullName);
            while (!read.EndOfStream)
            {
                string str = read.ReadLine();
                int index = str.IndexOf(":");
                string hour2 = str.Substring(index - 2, 2);
                int Hour = Convert.ToInt32(hour2);
                if (Hour >= hour && Hour <= hourtime)
                {
                    new1.WriteLine(str);
                }
            }
            new1.Close();
            read.Close();
        }
    }

    public class KVVDiskInfo
    {
        public static void FreeSpace(string name)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            KVVLog.AddSmth("Работа с дисками");
            foreach (DriveInfo drive in drives)
            {
                if (drive.Name.Contains(name) && drive.IsReady)
                {
                    Console.WriteLine($" Имя: {drive.Name} - Свободное пространство: {drive.TotalFreeSpace}");
                }
                Console.WriteLine();
            }
        }

        public static void FileSystem(string name)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            KVVLog.AddSmth("Работа с дисками");
            foreach (DriveInfo drive in drives)
            {
                if (drive.Name.Contains(name) && drive.IsReady)
                {
                    Console.WriteLine($" Имя: {drive.Name} - Файловая система: {drive.DriveFormat}");
                }
                Console.WriteLine();
            }
        }

        public static void DiskInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            KVVLog.AddSmth("Работа с дисками");
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    Console.WriteLine($"Название: {drive.Name}");
                    Console.WriteLine($"Объем диска: {drive.TotalSize}");
                    Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
                Console.WriteLine();
            }
        }
    }

    public class KVVFileInfo 
    {
        public static void FullPath(string path)
        {
            KVVLog.AddSmth("Работа с файлами");
            FileInfo file = new FileInfo(path);
            if (file.Exists)
                Console.WriteLine($"Имя: {file.Name} - Полный путь: {file.FullName}");
        }
        public static void Info(string path)
        {
            KVVLog.AddSmth("Работа с файлами");
            FileInfo file = new FileInfo(path);
            if (file.Exists)
                Console.WriteLine($"Имя: {file.Name} - Размер: {file.Length} - Расширение: {file.Extension}");
        }
        public static void FileTime(string path)
        {
            KVVLog.AddSmth("Работа с файлами");
            FileInfo file = new FileInfo(path);
            if (file.Exists)
                Console.WriteLine($"Имя: {file.Name} - Время создания: {file.CreationTime}");
        }
    }

    public class KVVDirInfo
    {
        public static void NumOfFiles(string path)
        {
            KVVLog.AddSmth("Работа с директорием");
            DirectoryInfo DirInfo = new DirectoryInfo(path);
            if (DirInfo.Exists)
                Console.WriteLine($"Имя: {DirInfo.Name} - Кол-во файлов: {DirInfo.GetFiles().Length}");
        }
        public static void DirTime(string path)
        {
            KVVLog.AddSmth("Работа с директорием");
            DirectoryInfo DirInfo = new DirectoryInfo(path);
            if (DirInfo.Exists)
                Console.WriteLine($"Имя: {DirInfo.Name} - Время создания: {DirInfo.CreationTime}");
        }
        public static void DirFiles(string path)
        {
            KVVLog.AddSmth("Работа с директорием");
            DirectoryInfo DirInfo = new DirectoryInfo(path);
            if (DirInfo.Exists)
                Console.WriteLine($"Имя: {DirInfo.Name} - Кол-во поддиректориев: {DirInfo.GetDirectories().Length}");
        }
        public static void DirParent(string path)
        {
            KVVLog.AddSmth("Работа с директорием");
            DirectoryInfo DirInfo = new DirectoryInfo(path);
            if (DirInfo.Exists)
                Console.WriteLine($"Имя: {DirInfo.Name} - Родительские директории: {DirInfo.Parent}");
        }
    }

    public class KVVFileManager
    {
        public static void FTask(string name)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.Name.Contains(name) && drive.IsReady)
                {
                    Console.WriteLine($" Имя: {drive.Name}");
                    DirectoryInfo DirInfo = new DirectoryInfo(drive.Name);
                    if (DirInfo.Exists)
                    {
                        foreach (var x in DirInfo.GetFiles())
                        {
                            Console.WriteLine($"Файл - {x}");
                        }
                        foreach (var x in DirInfo.GetDirectories())
                        {
                            Console.WriteLine($"Папки - {x}");
                        }
                        DirectoryInfo NewDir = new DirectoryInfo(@"C:\Users\1\Lab");
                        NewDir.CreateSubdirectory("KVVInspect");
                        FileInfo NewFile = new FileInfo(@"C:\users\1\Lab\KVVInspect\kvvdirinfo.txt");
                        StreamWriter write = File.CreateText(NewFile.FullName);
                        write.WriteLine("Задание № 5 п. 1");
                        write.Close();
                        NewFile.CopyTo(@"C:\users\1\Lab\KVVInspect\new.txt", true);
                        NewFile.Delete();
                    }
                }
            }
        }
        public static void STask(string path)
        {
            DirectoryInfo NewDir = new DirectoryInfo(@"C:\users\1\Lab");
            NewDir.CreateSubdirectory("KVVFiles");

            DirectoryInfo DirInfo = new DirectoryInfo(path);
            var AllFiles = DirInfo.GetFiles("*.txt");
            foreach (var x in AllFiles)
            {
                x.CopyTo($@"C:\users\1\Lab\KVVFiles\{x.Name}", true);
            }

            DirectoryInfo Dir = new DirectoryInfo(@"C:\users\1\Lab\KVVInspect");
            var newdir = Dir.GetFiles();
            foreach (var x in newdir)
            {
                x.CopyTo($@"C:\Users\1\source\{x.Name}", true);
            }

            string zipName = @"C:\users\1\Lab\KVVFiles1.zip";
            string zipFoulder = @"C:\users\1\Lab\KVVFiles";
            ZipFile.CreateFromDirectory(zipFoulder, zipName);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            KVVDiskInfo.FreeSpace("C");
            KVVDiskInfo.FileSystem("C");
            KVVDiskInfo.DiskInfo();

            KVVFileInfo.FileTime(@"C:\Users\1\Lab\Str.txt");
            KVVFileInfo.FullPath(@"C:\Users\1\Lab\Str.txt");
            KVVFileInfo.Info(@"C:\Users\1\Lab\Str.txt");

            KVVDirInfo.NumOfFiles(@"C:\Users\1\Lab");
            KVVDirInfo.DirFiles(@"C:\Users\1\Lab");
            KVVDirInfo.DirParent(@"C:\Users\1\Lab");
            KVVDirInfo.DirTime(@"C:\Users\1\Lab");

            KVVFileManager.FTask("D");
            KVVFileManager.STask(@"C:\Users\1\KVV");

            Console.WriteLine("Количество записей: " + KVVLog.Kol());
            KVVLog.Inf();
            KVVLog.Inf();
            KVVLog.Inf();

            KVVLog.Delete();

            Console.ReadKey();
        }
    }
}
