using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEM6
{
    class Program
    {   // Найти последнюю цифру A^B (1<=A,B<=10000)
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число, возводимое в степень, где оно меньше или равно единице");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите степень числа, где оно меньше или равно 10000");
            int b = int.Parse(Console.ReadLine());

            a = a % 10;

	    // ---check--- вылет по памяти у вас
            Console.WriteLine((Math.Pow(a, b)) % 10); 

        }
    }
}
