using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEM2._2
{ // Сизова Дарья 11-708. 
    class Program
    { // Реализовать статический метод, вычисляющий значение с точностью эпсилон.
        static double GetFunction(double k, double x)
        {
            return (Math.Pow(-1, k) * Math.Pow(x, 2 * k + 1)) / (2 * k + 1);
        }

        static double GetArcTg(double x, double epsilon) // Вычисление суммы ряда 
        {
            double k = 1;
            double sum = 0;
            double previousSum = 0; // Предыдущая сумма 
            for (; ; )
            {
                previousSum = sum;
                sum += GetFunction(k, x);
                if (Math.Abs(Math.Abs(sum)-Math.Abs(previousSum)) <= epsilon) // Нахождение приближенной точности
                {
                    break;
                } 
                k++;
            }
            return sum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение заданной точности");
            double epsilon = double.Parse(Console.ReadLine());
           
            double Pi = 4*(4*GetArcTg(1.0 / 5, epsilon) - GetArcTg(1.0 / 239, epsilon));

            Console.WriteLine("Значение Pi по формуле Джона Мэчина = " + Pi);
        }
    }
}
