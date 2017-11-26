using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEM2._1._1_
{ // Сизова Дарья. 11-708.
    class Program
    // Вычислить сумму ряда с заданной точностью и определить, 
    //на каком шаге начинает до стигаться эта точнось. 
    // Алгоритм суммирования в отдельном статистическом методе.

    {
        public static double GetFunction(double k, double x) // Метод возвращения значения функции
        {
            double y = (Math.Pow(-1, k) * Math.Pow(x, 2 * k)) / (GetFactorial(2 * k));
            return y;
        }
        public static double GetFactorial(double number) // Рекурсивный метод получения факториала заданного числа
        {
            if (number > 0)
            {
                return GetFactorial(number - 1) * number;
            }
            else return 1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение переменной X");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение заданной точности");
            double epsilon = double.Parse(Console.ReadLine());
            double sum = 0;
            double k = 0; // Шаг 

            for (; ; )
            {
                sum += GetFunction(k, x);
                k++;
                if (Math.Abs(GetFunction(k-1, x)) <= epsilon) break;
            }
            Console.WriteLine("Шаг, достигаемой точности = " + k);

            Console.WriteLine("Сумма ряда = " + sum);
        }
    }
}

