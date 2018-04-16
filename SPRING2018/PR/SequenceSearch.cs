using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp27
{
    class Program
    {
        // Поиск максимальной суммы, если максимальная подпоследовательность 
        //находится в середине последовательности
        static int GetMaxSumOfMiddle(int i, int j, int middle, int[] array)
        {
            int maxLeft = 0;
            int sum = 0;
            //Поиск по левой части
            for (int a = middle - 1; a > i; a--)
            {
                sum += array[a];
                maxLeft = Math.Max(maxLeft, sum);
            }
            int maxRight = 0;
            sum = 0;
            //Поиск по правой части
            for (int b = middle; b < j; b++)
            {
                sum += array[b];
                maxRight = Math.Max(maxRight, sum);
            }
            // Возвращает максимальную последовательность с левой и правой части
            return (maxRight + maxLeft);
        }

        // Рекурсивный метод для поиска суммы максимальной подпоследовательность 
        static int GetMaxSum(int i, int j, int[] array)
        {
            if (i > j) return 0;
            else if (i == j)
            {
                return Math.Max(0, array[i]);
            }
            else
            {
                int length = (i + j + 1) / 2;
                int maxSequenseOfArray1 = GetMaxSum(i, length - 1, array);
                int maxSequenseofArray2 = GetMaxSum(length, j, array);
                int maxOfMiddle = GetMaxSumOfMiddle(i, j, length, array);
                int max = Math.Max(Math.Max(maxSequenseOfArray1, maxSequenseofArray2), maxOfMiddle);
                return max;
            }
        }
        
        
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов");
            int size = int.Parse(Console.ReadLine());
            int[] array = new int[size];
            Console.WriteLine("Введите элементы множества");
            for (int i = 0; i < size; i++)// Заполнение массива
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            var SumOfmaxSequence = GetMaxSum(0, array.Length - 1, array);
            Console.WriteLine("Сумма элементов максимальной подпоследовательности " + SumOfmaxSequence);
        }
    }
}              