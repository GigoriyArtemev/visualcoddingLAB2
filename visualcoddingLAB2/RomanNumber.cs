using System;

namespace visualcoddingLAB2
{
    public class RomanNumber : ICloneable, IComparable
    {
        private string roman_number;
        public RomanNumber(ushort n)
        {
            if (n <= 0)
                throw new RomanNumberException("В конструктор передан 0.");
            roman_number = convert_to_roman(n);
        }
        private static ushort convert_to_arabic(string n)
        {
            ushort[] Arab = { 1000, 500, 100, 50, 10, 5, 1 };
            string[] Rom = { "M", "D", "C", "L", "X", "V", "I" };
            ushort new_Arab_num = 0;
            ushort temp_prev = 0;
            int j;

            for (int i = n.Length - 1; i >= 0; i--)
            {
                for (j = 0; j < Rom.Length; j++)
                    if (n[i] == Rom[j][0])
                        break;
                if (temp_prev > Arab[j])
                    new_Arab_num -= Arab[j];
                else
                    new_Arab_num += Arab[j];
                temp_prev = Arab[j];
            }

            return new_Arab_num;
        }
        private static string convert_to_roman(ushort n)
        {
            ushort[] Arab = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] Rom = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int i = 0;
            string new_Rom_num = "";
            while (n > 0)
            {
                if (n >= Arab[i])
                {
                    n -= Arab[i];
                    new_Rom_num += Rom[i];
                }
                else
                    i++;
            }
            return new_Rom_num;
        }
       
        //Сложение римских чисел
        public static RomanNumber Add(RomanNumber? n1, RomanNumber? n2)
        {
            ushort n_1 = convert_to_arabic(n1.roman_number);
            ushort n_2 = convert_to_arabic(n2.roman_number);
            int sum_arabic = (int)n_1 + (int)n_2;
            return new RomanNumber((ushort)sum_arabic);

        }
        //Вычитание римских чисел
        public static RomanNumber Sub(RomanNumber? n1, RomanNumber? n2)
        {
            ushort n_1 = convert_to_arabic(n1.roman_number);
            ushort n_2 = convert_to_arabic(n2.roman_number);
            if ((int)n_1 <= (int)n_2)
            {
                throw new RomanNumberException("Ошибка при вычитании, n1<=n2");
            }
            int sub_arabic = (int)n_1 - (int)n_2;
            return new RomanNumber((ushort)sub_arabic);

        }
        //Умножение римских чисел
        public static RomanNumber Mul(RomanNumber? n1, RomanNumber? n2)
        {
            ushort n_1 = convert_to_arabic(n1.roman_number);
            ushort n_2 = convert_to_arabic(n2.roman_number);
            int mul_arabic = (int)n_1 * (int)n_2;
            return new RomanNumber((ushort)mul_arabic);
        }
        //Целочисленное деление римских чисел
        public static RomanNumber Div(RomanNumber? n1, RomanNumber? n2)
        {
            ushort n_1 = convert_to_arabic(n1.roman_number);
            ushort n_2 = convert_to_arabic(n2.roman_number);
            if (((int)n_1 % (int)n_2 != 0) || ((int)n_1 < (int)n_2))
            {
                throw new RomanNumberException("Ошибка при делении!");
            }
            int div_arabic = (int)n_1 / (int)n_2;
            return new RomanNumber((ushort)div_arabic);
        }
        //Возвращает строковое представление римского числа
        public override string ToString()
        {
            return roman_number;
        }
        //Реализация интерфейса IClonable
        public object Clone()
        {
            ushort tmp = convert_to_arabic(roman_number);
            return new RomanNumber(tmp);
        }
        //Реализация интерфейса IComparable
        public int CompareTo(object? obj)
        {
            if (obj == null)
                throw new RomanNumberException("Ошибка в CompareTo!");
            int num_obj = (int)convert_to_arabic(obj.ToString());
            int Rom_num_arabic = (int)convert_to_arabic(roman_number);
            return Rom_num_arabic - num_obj;
        }

    }
}
