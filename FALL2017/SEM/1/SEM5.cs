using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEM5
{
    class Program
    {
        // Найти сумму всех простых делителей заданного натурального числа (<10000)
                static void Main()
        {
            Console.WriteLine("Введите натуральное число (меньше 10000)");
            int number = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= number; i++)
            {
                if ((number % i == 0) && (i % 2 != 0) && (number % 3 != 0) && (i % 5 != 0))
                    sum += i;
            }
            if (number % 2 == 0) sum += 2;
            if (number % 3 == 0) sum += 3;
            if (number % 4 == 0) sum += 4;

            Console.WriteLine(sum);
        }




    }
}

