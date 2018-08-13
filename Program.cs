// https://code.sololearn.com/c4x9yU5Hc21c/#cs
//
// Simple Roman to Arabic (decimal) Numerals converter by Silvio Duka
// The name of Arabic numerals is also Hindu-Arabic numerals
// Convert numbers from 1 to 3999 (from I to MMMCMXCIX)
// https://en.wikipedia.org/wiki/Roman_numerals
// Some examples:
// CLV - 155
// MDCCCXXIII - 1823
// MMXVIII - 2018
// XIX - 19
//
// Last modified date: 2018-01-10
//
// Try to input value: CLV

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearn
{
    class Converter
    {
        static void Main(string[] args)
        {
            Converter c = new Converter();

            Console.Write("Input a valid Roman number: ");

            string number = Console.ReadLine().Trim().ToUpper();

            if (c.IsRomanNumberValid(number) == true)
            {
                if (c.ConvertFromRoman(number) == false)
                    Console.WriteLine("Please, enter a valid number...");
            }
            else
            {
                Console.WriteLine("Please, enter a valid number...");
            }
        }
        
        private bool IsRomanNumberValid(string roman)
        {
            char c; // current char
            char x; // next char
            char o; // old char
            int nI = 0; // number of digits in a string
            int nV = 0;
            int nX = 0;
            int nL = 0;
            int nC = 0;
            int nD = 0;
            int nM = 0;
            int niI = 0;
            int niX = 0;
            int niC = 0;
            int niM = 0;
            bool valid; // is valid digit

            o = ' ';

            for (var i = 0; i < roman.Length; i++)
            {
                valid = false;

                c = roman[i];
                if ((i + 1) < roman.Length)
                    x = roman[i + 1];
                else
                    x = ' ';

                if (c == 'I' && x == 'L') return false;
                if (c == 'I' && x == 'C') return false;
                if (c == 'I' && x == 'D') return false;
                if (c == 'I' && x == 'M') return false;
                if (c == 'V' && x == 'X') return false;
                if (c == 'V' && x == 'C') return false;
                if (c == 'V' && x == 'D') return false;
                if (c == 'V' && x == 'M') return false;
                if (c == 'X' && x == 'D') return false;
                if (c == 'X' && x == 'M') return false;

                if (c == 'I') { valid = true; nI++; if (o == c) niI++; }
                if (c == 'V') { valid = true; nV++; }
                if (c == 'X') { valid = true; nX++; if (o == c) niX++; }
                if (c == 'L') { valid = true; nL++; }
                if (c == 'C') { valid = true; nC++; if (o == c) niC++; }
                if (c == 'D') { valid = true; nD++; }
                if (c == 'M') { valid = true; nM++; if (o == c) niM++; }

                if (valid == false) return false;

                o = c;
            }

            if (nI > 4 || nX > 4 || nC > 4 || nM > 4) return false;
            if (nV > 1 || nL > 1 || nD > 1) return false;
            if (niI > 2 || niX > 2 || niC > 2 || niM > 2) return false;

            return true;
        }
        
        public bool ConvertFromRoman(string roman)
        {
            var arabic = 0; // result of conversion
            var n = 0; // current converted number
            var no = 1000; // last converted number
            char c; // current char
            char x; // next char
            bool d = false;

            for (var i = 0; i < roman.Length; i++)
            {
                c = roman[i];
                if ((i + 1) < roman.Length)
                    x = roman[i + 1];
                else
                    x = ' ';

                if (c == 'I') { n = 1;}
                if (c == 'V') { n = 5; }
                if (c == 'X') { n = 10; }
                if (c == 'L') { n = 50; }
                if (c == 'C') { n = 100; }
                if (c == 'D') { n = 500; }
                if (c == 'M') { n = 1000; }

                if (c == 'I' && x == 'V') { n = 4; i++; d = true; }
                if (c == 'I' && x == 'X') { n = 9; i++; d = true; }
                if (c == 'X' && x == 'L') { n = 40; i++; }
                if (c == 'X' && x == 'C') { n = 90; i++; }
                if (c == 'C' && x == 'D') { n = 400; i++; }
                if (c == 'C' && x == 'M') { n = 900; i++; }

                if ((n == no) && (d == true)) return false;
                if (n < 10 && no < 10 && d == true) return false;
                if (n > no) return false;

                arabic += n;
                no = n;
            }

            Console.WriteLine("The number " + roman + " converted in Arabic numeral is: " + arabic);

            return true;
        }
    }
}
