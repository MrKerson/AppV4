using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace AppV4
{
    class Result
    {
        public void Massege(string s)
        {
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

            MassClass massClass = new MassClass();

            Console.WriteLine($"Количество слов в тексте: {massClass.LengthAllMass(num, s)}");
            Console.WriteLine($"Количество уникальные слова, длина которых больше {num}: {massClass.LengthMass(num, s)}");
            Console.WriteLine($"Уникальные слова, длина которых больше {num}:");
            massClass.StringMass(num, s);
            Console.ReadLine();
        }
    }

    class MassClass
    {
        string[] textMass;
        public void StringMass(int num, string s)
        {
            textMass = s.Split(' ', ',', '.', ';', ':');

            var selectedMass = textMass.Where(m => m.Length > num);
            foreach (string Mass in selectedMass)
            {
                Console.WriteLine(Mass);
            }
        }

        public int LengthMass(int num, string s)
        {
            int _mass = 0;
            textMass = s.Split(' ', ',', '.', ';', ':');
            foreach (string Mass in textMass)
            {
                if (Mass.Length > num)
                {
                    _mass = Mass.Length;
                }
            }
            return _mass;
        }

        public int LengthAllMass(int num, string s)
        {
            textMass = s.Split(' ', ',', '.', ';', ':');
            return textMass.Length;
        }
    }

    class Program
    {
        [STAThread]
        static void Main(string[] args)
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
            StreamReader sr = new StreamReader(_file);
            while (sr.EndOfStream != true)
            {
                s = sr.ReadLine();
            }

            Result result = new Result();
            result.Massege(s);
            sr.Close();
        }
    }

}
