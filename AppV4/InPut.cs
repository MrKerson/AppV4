using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppV4
{
    class InPut : IInPut
    {
        public void ConsolePut()
        {
            Console.WriteLine("Введите строку из слов:");
            string s = "";
            s = Console.ReadLine();
            Console.WriteLine("Введите длину слова:");

            var rule = @"[0-9]";
            var sb = new StringBuilder();
            List<char> stringChar = new List<char>();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }

                if (Regex.IsMatch(key.KeyChar.ToString(), rule))
                {
                    sb.Append(key.KeyChar);
                    Console.Write(key.KeyChar);
                }
            }

            int num = int.Parse(sb.ToString());

            Result result = new Result();
            Console.WriteLine("1 - Вывод в консоль\n2 - Вывод в файл\n");
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            
            switch (pressedKey.Key)
            {
                case ConsoleKey.D1:
                    Console.Write("\n");
                    result.ConsoleOut(s, num);
                    break;
                case ConsoleKey.D2:
                    Console.Write("\n");
                    result.FileOut(s, num);
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
            
        }

        
        public void FilePut()
        {
            Console.WriteLine("Выбирете файл:");
            string _file = "";
            string s = "";
            Thread.Sleep(1000);
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Text files(*.txt)|*.txt";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in OPF.FileNames)
                {
                    _file = file;
                }
            }
            Console.WriteLine($"Выбран файл: {_file}");
            if (_file != "")
            {
                StreamReader sr = new StreamReader(_file);
                while (sr.EndOfStream != true)
                {
                    s = sr.ReadLine();
                }

                Console.WriteLine("Введите длину слова:");

                var rule = @"[0-9]";
                var sb = new StringBuilder();
                List<char> stringChar = new List<char>();
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                        break;
                    }

                    if (Regex.IsMatch(key.KeyChar.ToString(), rule))
                    {
                        sb.Append(key.KeyChar);
                        Console.Write(key.KeyChar);
                    }
                }

                int num = int.Parse(sb.ToString());

                Result result = new Result();
                Console.WriteLine("1 - Вывод в консоль\n2 - Вывод в файл\n");
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.D1:
                        result.ConsoleOut(s, num);
                        break;
                    case ConsoleKey.D2:
                        result.FileOut(s, num);
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
                sr.Close();
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}
