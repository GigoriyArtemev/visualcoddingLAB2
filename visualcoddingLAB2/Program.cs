using System;

namespace visualcoddingLAB2
{
    class Program
    {
        static void Main()
        {
            RomanNumber anynumber1 = new RomanNumber(10);
            RomanNumber anynumber2 = new RomanNumber(2);
            //Проверка исключений при делении/вычитании  0, и проверка конструктора.
            try
            {
                RomanNumber n = new RomanNumber(0);
            }
            catch (RomanNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                RomanNumber.Sub(anynumber2, anynumber1);
            }
            catch (RomanNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                RomanNumber.Div(anynumber2, anynumber1);
            }
            catch (RomanNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Проверка операций
          
            Console.WriteLine("anynumber_1 = " + anynumber1);
            Console.WriteLine("anynumber_2 = " + anynumber2);

            RomanNumber add = RomanNumber.Add(anynumber1, anynumber2);
            Console.WriteLine("add = " + add);

            RomanNumber sub = RomanNumber.Sub(anynumber1, anynumber2);
            Console.WriteLine("sub = " + sub);

            RomanNumber mul = RomanNumber.Mul(anynumber1, anynumber2);
            Console.WriteLine("mul = " + mul);

            RomanNumber div = RomanNumber.Div(anynumber1, anynumber2);
            Console.WriteLine("div = " + div);

            string str = anynumber1.ToString();
            Console.WriteLine("str = " + str);
            
            var clon = anynumber1;
            clon = RomanNumber.Add(anynumber1, anynumber1);
            Console.WriteLine("clon = " + clon);
            Console.WriteLine("test1 = " + anynumber1);

            RomanNumber[] digits = { anynumber1, anynumber2, add, sub, mul, div };
            Console.WriteLine("Начальный массив:");
            foreach (RomanNumber dig in digits)
            {
                Console.Write(dig.ToString() + " ");
            }
            Console.WriteLine();

            Array.Sort(digits);
            Console.WriteLine("Отсортированный массив:");
            foreach (RomanNumber dig in digits)
            {
                Console.Write(dig.ToString() + " ");
            }
            Console.WriteLine();

            
        }
    }
}