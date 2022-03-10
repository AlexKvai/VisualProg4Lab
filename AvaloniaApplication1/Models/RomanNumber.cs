using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Models
{
    public class RomanNumber : ICloneable, IComparable
    {

        private ushort _num;
        private static int[] values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private static string[] roman = new string[]
            { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        public RomanNumber(ushort n)
        {
            if (n <= 0) throw new RomanNumberException($"Число {n} меньше либо равно 0");
            else this._num = n;
        }
        public static RomanNumber operator +(RomanNumber? num1, RomanNumber? num2)
        {
            int num = num1._num + num2._num;
            if (num <= 0) throw new RomanNumberException("Ne udalosb slojitb 2 chisla!");
            else
            {
                return new RomanNumber((ushort)num);
            }
        }
        public static RomanNumber operator -(RomanNumber? num1, RomanNumber? num2)
        {
            int num = num1._num - num2._num;
            if (num <= 0) throw new RomanNumberException("Rezult vichitania <= 0!");
            else
            {
                return new RomanNumber((ushort)num);
            }
        }
        public static RomanNumber operator *(RomanNumber? num1, RomanNumber? num2)
        {
            int num = num1._num * num2._num;
            if (num <= 0) throw new RomanNumberException("Ne udalosb umnojitb 2 chisla");
            else
            {
                return new RomanNumber((ushort)num);
            }
        }

        public static RomanNumber operator /(RomanNumber? num1, RomanNumber? num2)
        {

            if (num2._num == 0) throw new RomanNumberException("Error delenia!");
            else
            {
                int num = num1._num / num2._num;
                if (num == 0) throw new RomanNumberException("Error delenia!");
                else
                {
                    return new RomanNumber((ushort)num);
                }
            }
        }
        public override string ToString()
        {
            int tmp = _num;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 13; i++)
            {
                while (tmp >= values[i])
                {
                    tmp -= (ushort)values[i];
                    result.Append(roman[i]);
                }
            }
            if (result.ToString() == "")
                throw new RomanNumberException("Perevod ne voznojen");
            else
                return result.ToString();

        }

        public object Clone()
        {

            return new RomanNumber(_num);
        }

        public int CompareTo(object obj)
        {
            if (obj is RomanNumber roman)
                return _num.CompareTo(roman._num);
            else
                throw new RomanNumberException("object is not a RomanNumber");
        }

    }
}
