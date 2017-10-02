using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEM2
{
    class Program
    {   // По первому члену арифметической прогрессии f и шагу прогрессии s определить каким по порядковый номер числа n в прогрессии (или вывести -1, если число не принадлежит ей)
        static void Main(string[] args)
        {
            Console.WriteLine("Введите член прогрессии");
            int a = int.Parse(Console.ReadLine()); // Член арифметической прогрессии, который необходимо проверить
            Console.WriteLine("Введите первый член прогрессии");
            int f = int.Parse(Console.ReadLine()); // Первый член арифметической прогрессии
            Console.WriteLine("Введите шаг арифметической прогрессии");
            int s = int.Parse(Console.ReadLine()); // Шаг арифметической прогрессии

            double n = (a - f) / s + 1;
            int crashNumber = (int)n; // Переменная для тестирования числа на наличие дробной части
            if ((crashNumber - n) == 0) // Проверка числа на наличие дробной части
                Console.WriteLine(n);
            else Console.WriteLine(-1);

        }
    }
}

