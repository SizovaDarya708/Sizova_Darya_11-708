using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace SEM2_1._2_
{ // Сизова Дарья. 11-708.
    class Program
    // Вычислить сумму ряда с заданной точностью и определить, 
    // на каком шаге начинает до стигаться эта точнось. 
    // Алгоритм суммирования в отдельном статистическом методе. 

    {
        public static double GetFactorial(double number)
        {
            if (number > 1)
            {
                return GetFactorial(number - 2) * number;
            }
            else return 1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение переменной X");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение заданной точности");
            double epsilon = double.Parse(Console.ReadLine());
            int k = 0; // шаг 
            double previousSum = 0;
            double sum = 0;
            for (; ; )
            {
                previousSum = sum;
                 sum = ((Math.Pow(-1, k)) * (Math.Pow(x, k)) * (GetFactorial(GetFactorial(2*k + 1)))) / (GetFactorial(GetFactorial(2*k))) + sum;
                if (Math.Abs(Math.Abs(sum) - Math.Abs(previousSum)) <= epsilon) break;
                k++;             
            }
            Console.WriteLine();
            Console.WriteLine("Сумма = " + sum);
            Console.WriteLine();
            k++;
            Console.WriteLine("Номер шага, достигаемой точности = " + k);
        }
    }
}
