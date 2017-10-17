using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops4
{ //В массиве чисел найдите самый длинный подмассив из одинаковых чисел.
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int count = 1;
            int number;
            int lastNumber; 
            int maxOfNumbers = 0;

            Console.WriteLine("Введите последнее число последовательности(массива)");
            lastNumber = int.Parse(Console.ReadLine());

            for (int i = 1; i < n; i++)
            {
                number = int.Parse(Console.ReadLine());
                if (number == lastNumber) count++;
                else
                {
                    lastNumber = number;
                    maxOfNumbers = Math.Max(count, maxOfNumbers);
                    count = 1;
                }

            }

            Console.WriteLine(Math.Max(maxOfNumbers, count));
        }
    }
}
