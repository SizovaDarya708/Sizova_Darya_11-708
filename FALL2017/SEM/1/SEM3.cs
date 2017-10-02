using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEM3
{   // Найти произведение цифр в k-ичной системе счисления (k от 2 до 10) десятичного натурального числа n (n<=10^7)
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите натуральное десятичное число");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите систему счисления k (диапозона от 2 до 10)");
            int k = int.Parse(Console.ReadLine());
            int multiplication = 1; // Переменная, хранящая произведение цифр в k-ной системе счисления

            for (int m = n; m > 0;)
            {
                multiplication = (n % k)*multiplication;
                double division = n / k;
                n = (int)(Math.Truncate(division));

            }
            Console.WriteLine(multiplication);

            
        }
    }
}
