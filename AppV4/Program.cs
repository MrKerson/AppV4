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
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            InPut put = new InPut();
            Console.WriteLine("1 - Ввод в ручную в консоли\n2 - Выбор файла\n");
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            switch (pressedKey.Key)
            {
                case ConsoleKey.D1:
                    Console.Write("\n");
                    put.ConsolePut();
                    break;
                case ConsoleKey.D2:
                    Console.Write("\n");
                    put.FilePut();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
    }

}
