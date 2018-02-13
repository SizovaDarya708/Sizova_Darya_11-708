using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEM2_1._3_
{ // Сизова Дарья. 11-708.
    class Program
    // Вычислить сумму ряда с заданной точностью и определить, 
    //на каком шаге начинает до стигаться эта точнось. 
    // Алгоритм суммирования в отдельном статистическом методе.

    {
        public static double GetFactorial(double number)
        {
            if (number > 0)
            {
                return GetFactorial(number - 1) * number;
            }
            else return 1;
        }
        static double GetConstant(double epsilon)
        {
            long k = 0;
            double sum = 0;
            double G = 0;
            double previousG = 0;
            for (; ; )
            {
                previousG = G;
				// ---check--- всё те же самое, что и в предыдущих задачах
                sum += Math.Pow(GetFactorial(k), 2) / (GetFactorial(2 * k) * Math.Pow(2 * k + 1, 2));
                G = ((Math.PI) / 8) * Math.Log(Math.Sqrt(3.0) + 2.0) + (3.0 / 8.0) * sum;
                if (Math.Abs(previousG - G) <= epsilon) break;
                k++;
            }
            Console.WriteLine("Значение шага, достигаемой точности = " + k);
            return G;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение заданной точности");
            double epsilon = double.Parse(Console.ReadLine());

            double G = GetConstant(epsilon);
            Console.WriteLine();
            Console.WriteLine("Константа Каталана G = " + G);

        }

    }
}
