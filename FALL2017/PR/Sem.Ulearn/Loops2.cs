using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops2
{
    class Program
    { // Найти количество трехзначных натуральных чисел, сумма цифр которых равна N. 
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int J = 0; J < 10; J++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        if (i + J + k == N) count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}