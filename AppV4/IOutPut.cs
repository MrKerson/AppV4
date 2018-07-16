using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppV4
{
    interface IOutPut
    {
        void FileOut(string s, int num);
        void ConsoleOut(string s, int num);
    }
}
