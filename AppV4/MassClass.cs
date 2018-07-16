using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppV4
{
    class MassClass
    {
        string[] textMass;
        public List<string> StringMass(int num, string s)
        {
            textMass = s.Split(new Char[] { ' ', '\0', '\a', '\b', '\f', '\n', '\t', '\r', '\v', ',', '.', ':', ';', '!', '?', '-', ')', '(', '"', '\'', '*', '\'', '|' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> arraymass = new List<string>();
            var selectedmass = textMass.Where(m => m.Length > num);

            //return selectedmass;
            foreach (string mass in selectedmass)
            {
                arraymass.Add(mass);
            }
            return arraymass;
        }

        public int LengthMass(int num, string s)
        {
            int _mass = 0;
            textMass = s.Split(new Char[] { ' ', '\0','\a','\b', '\f', '\n', '\t', '\r', '\v', ',', '.', ':', ';', '!', '?', '-', ')', '(', '"', '\'', '*', '\'', '|' }, StringSplitOptions.RemoveEmptyEntries);
            var selectedMass = textMass.Where(m => m.Length > num);
            foreach (string Mass in selectedMass)
            {
                _mass++;
            }
            //foreach (string Mass in textMass)
            //{
            //    if (Mass.Length > num)
            //    {
            //        _mass = Mass.Length;
            //    }
            //}
            return _mass;
        }

        public int LengthAllMass(int num, string s)
        {
            textMass = s.Split(new Char[] { ' ', '\0', '\a', '\b', '\f', '\n', '\t', '\r', '\v', ',', '.', ':', ';', '!', '?', '-', ')', '(', '"', '\'', '*', '\'', '|' }, StringSplitOptions.RemoveEmptyEntries);
            return textMass.Length;
        }
    }
}
