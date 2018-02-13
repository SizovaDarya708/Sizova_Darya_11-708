using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEM2._3
{ // Сизова Дарья 11-708.
    class Program
    { // Вычислить приближенное значение определенного интеграла функции по различным формулам(методам):

        static double Function(double x) // Данная функция
        {
            double y = Math.Cos(Math.Sin(x));
            return y;
        }

        static double GetIntegralWithLeftRectangle(double lenght) // Вычисление интеграла по формуле левых прямоугольников
        {
            double sqrtOfRectangle = 0;
            for (double i = 1; i <= 3; i += lenght) // Передвижение по оси абсцисс с помощью шага 
            {
                sqrtOfRectangle = Function(i) * lenght + sqrtOfRectangle; // Вычисление суммы площадей прямоугольников
            }
            return sqrtOfRectangle;
        }

        static double GetIntegralWithRightRectangle(double lenght) // Вычисление итеграла по формулам Правых прямоугольников
        {
            double i = 0;
            double sqrtOfRectangle = 0;
            for (i = 3; i>= 1; i -= lenght) // Передвижение по оси абсцисс с помощью шага 
            {
                sqrtOfRectangle = Function(i) * lenght + sqrtOfRectangle; // Вычисление суммы площадей прямоугольников
            }
            return sqrtOfRectangle;
        }

        static double GetIntegralWithTrapeze(double hight) // Вычисление интеграла по формуле трапеций
        {
            double sqrtOfRectangle = 0;
            for (double i = 1-hight; i <= 3; i += hight)
            {
                sqrtOfRectangle += ((Function(i) + Function(i + hight)) / 2) * hight; // Вычисление суммы площадей трапеций 
            }
            return sqrtOfRectangle;
        }

        static double GetintegerWithSimpson(double step) // Вычисление интеграла методом Симпсона
        {
            double hight = 2 / step;
            step = step / 2;
			//---check--- почему не одним циклом?
            double firstSumOfSqrt = 0;
            for (int i = 1; i < step; i++)
                firstSumOfSqrt += Function(1 + 2 * i * hight);
            double secondSumOfSqrt = 0;
            for (int i = 1; i <= step; i++)
                secondSumOfSqrt += Function(1 + (2 * i - 1) * hight);
            return hight / 3 * (Function(1) + Function(3) + 2 * firstSumOfSqrt + 4 * secondSumOfSqrt);
        }

        static double GetIntegralWithMonteCarlo(double n) // Вычисление интеграла методом Монте-Карло
        {
			//---check--- какая-то не такая реализация у вас
            double delta = 2 / n;
            double sum = 0;
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                sum += Function(1 + rnd.NextDouble() * 2);
            }
            return sum * delta;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите шаг");
            double step = double.Parse(Console.ReadLine());

            Console.WriteLine("Вычисление интеграла по формуле Левых прямоугольников");
            double integral = GetIntegralWithLeftRectangle(step);
            Console.WriteLine("Значение интеграла по формулам Левых прямоугольников = " + integral);
            Console.WriteLine();
            

            Console.WriteLine("Вычисление интеграла по формуле Правых прямоугольников");
            integral = GetIntegralWithRightRectangle(step);
            Console.WriteLine("Значение интеграла по формулам Правых прямоугольников = " + integral);
            Console.WriteLine();

           
            Console.WriteLine("Вычисление интеграла по формуле Трапеций");
            integral = GetIntegralWithRightRectangle(step);
            Console.WriteLine("Значение интеграла по формулам Трапеций = " + integral);   
            Console.WriteLine();

            Console.WriteLine("Введите количество отрезков для вычисление интеграла по методу Симпсона");
            double n = double.Parse(Console.ReadLine());
            Console.WriteLine("Вычисление интеграла по методу Симпсона");
            integral = GetintegerWithSimpson(n);
            Console.WriteLine("Значение интеграла по методу Симпсона = " + integral);
            Console.WriteLine();

            Console.WriteLine("Вычисление интеграла методом Монте-Карло");
            Console.WriteLine("Введите количество точек");
            double countOfPoint = double.Parse(Console.ReadLine());
            integral = GetIntegralWithMonteCarlo(countOfPoint);
            Console.WriteLine("Значение интеграла методом Монте-Карло = " + integral);
            Console.WriteLine();

        }
           


            
    }
}
