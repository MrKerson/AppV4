using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AppV4
{
    class Result: IOutPut
    {

        private List<string> _arraymass;
        private int _length;
        private int _lengthall;
        public void ConsoleOut(string s, int num)
        {
            MassClass massClass = new MassClass();

            _lengthall = massClass.LengthAllMass(num, s);
            Console.WriteLine($"Количество слов в тексте: {_lengthall}");
            _length = massClass.LengthMass(num, s);
            Console.WriteLine($"Количество уникальные слова, длина которых больше {num}: {_length}");
            _arraymass = massClass.StringMass(num, s);
            Console.WriteLine($"Уникальные слова, длина которых больше {num}:");
            foreach (string mass in _arraymass)
            {
                Console.WriteLine(mass);
            }
            Console.ReadLine();
        }

        //public void FileOut(string s, int num)
        //{
        //    MassClass massClass = new MassClass();

        //    string text = "Количество слов в тексте: " + $"{massClass.LengthAllMass(num, s)}\n" + $"Количество уникальные слова, длина которых больше {num}:" +$"{massClass.LengthMass(num, s)}\n";
        //    text += $"Уникальные слова, длина которых больше {num}:" + $"massClass.StringMass(num, s)\n";
        //    using (FileStream fstream = new FileStream(@"D:/Практика/AppV4/AppV4/File/Result.txt", FileMode.OpenOrCreate))
        //    {
                
        //        // преобразуем строку в байты
        //        byte[] array = System.Text.Encoding.Default.GetBytes(text);
        //        // запись массива байтов в файл
        //        fstream.Write(array, 0, array.Length);
        //        Console.WriteLine("Текст записан в файл\n");
        //        Thread.Sleep(1000);
        //    }
        //}


        public void FileOut(string s, int num)
        {
            MassClass massClass = new MassClass();

            //string text = "Количество слов в тексте: " + $"{massClass.LengthAllMass(num, s)}\n" + $"Количество уникальные слова, длина которых больше {num}:" + $"{massClass.LengthMass(num, s)}\n";
            //text += $"Уникальные слова, длина которых больше {num}:" + $"massClass.StringMass(num, s)\n";
            StreamWriter write_text;  //Класс для записи в файл
            FileInfo file = new FileInfo("D:/Практика/AppV4/AppV4/File/Result.txt");
            file.Delete();
            write_text = file.AppendText(); //Дописываем инфу в файл, если файла не существует он создастся
            _lengthall = massClass.LengthAllMass(num, s);
            write_text.WriteLine($"Количество слов в тексте: {_lengthall}");
            _length = massClass.LengthMass(num, s);
            write_text.WriteLine($"Количество уникальные слова, длина которых больше {num}: {_length}");
            _arraymass = massClass.StringMass(num, s);
            write_text.WriteLine($"Уникальные слова, длина которых больше {num}:");
            foreach (string mass in _arraymass)
            {
                write_text.WriteLine(mass);
            }
            write_text.Close(); // Закрываем файл
            Console.WriteLine("\nТекст записан в файл\n");
            Thread.Sleep(1000);
            
        }
    }
}
