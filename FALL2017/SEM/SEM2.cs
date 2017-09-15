using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEM._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int f = int.Parse(Console.ReadLine()); // Первый член арифметической прогрессии
            int s = int.Parse(Console.ReadLine()); // Шаг прогрессии
            int a = int.Parse(Console.ReadLine()); // Сам член прогрессии
            int n = (a - f) / s + 1;

            Console.WriteLine(n);
        }
    }
}
