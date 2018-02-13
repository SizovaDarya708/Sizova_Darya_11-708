using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEM2._4
{
    class Program
    {
        static int GetNumberOfElementsInArray(int n, int m) // Метод поиска количества элеменетов массива
        {
            int count = 0;
            if (n > m)
                count = n;
            else count = m;
            return count;
        }

        static string[] GetArrayOfString(string N, int valueN, int valueM, int deltaNM, int count) // Метод перевода числа(в строковом ввиде) в массив типа string
        {
            string[] n = new string[count];
            if (valueN >= valueM)
                for (int i = 0; i <= count; i++)
                {
					// ---check--- Здесь выход за границы массива
                    n[i] = N.Substring(i, 1);      
                }
            else
            {
                for (int i = 0; i <= deltaNM; i++)
                {
                    if (i <= deltaNM) n[i] = "0";
                    else
                    {
                        n[i] = N.Substring(i, 1);
                    }
                }
            }
            return n;
        }

        static int[] GetIntArray(string[] array, int elementsOfArray) // Метод перевода массива типа string в массив типа int
        {
            bool tryParse = true;
            int[] A = new int[elementsOfArray];
            for (int i = 0; i <= elementsOfArray-1; i++)
            {
                if (tryParse = int.TryParse(array[i], out A[i]))
                    A[i] = int.Parse(array[i]);
                else A[i] = 0;
            }
            return A;
        }

        static bool ComparisonAMoreThenB(int[] a, int[] b) // Метод проверки неравенства, что первое число больше или равно второму
        {
            bool comparison = true;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < b[i])
                {
                    comparison = false;
                    break;
                }
            }
            return comparison;
        }

        static bool ComparisonAEquallyB(int[] a, int[] b) // Метод проверки равенства двух чисел 
        {
            bool comparison = true;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    comparison = false;
                    break;
                }
            }
            return comparison;
        }

        static int[] ASubtractionB(int[] a, int[] b) // Метод разности двух чисел
        {
            int[] result = new int[a.Length];
            for (int i = b.Length - 1; i >= 0; i -= 1)
            {
                if (a[i] >= b[i])
                    result[i] = a[i] - b[i];
                else
                {
                    a[i - 1] -= 1;
                    a[i] += 10;
                    result[i] = a[i] - b[i];
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество разрядов в числе N");
            int numberOfDigitsN = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество разрядов в числе M");
            int numberOfDigitsM = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите число N");
            string stringN = Console.ReadLine();
            Console.WriteLine("Введите число M");
            string stringM = Console.ReadLine();
            int numberOfDigits = GetNumberOfElementsInArray(numberOfDigitsN, numberOfDigitsM);
            int deltaOfDigits = Math.Abs(numberOfDigitsN - numberOfDigitsM); // Разница количества разрядов числа 

            string[] N = GetArrayOfString(stringN, numberOfDigitsN, numberOfDigitsM, deltaOfDigits, numberOfDigits); // Массив строк для записи чисел
            string[] M = GetArrayOfString(stringM, numberOfDigitsN, numberOfDigitsM, deltaOfDigits, numberOfDigits);

            int[] arrayN = GetIntArray(N, numberOfDigits);
            int[] arrayM = GetIntArray(M, numberOfDigits);

            while (ComparisonAEquallyB(arrayN, arrayM) == false)
            {
                if (ComparisonAMoreThenB(arrayN, arrayM))
                {
                    arrayN = ASubtractionB(arrayN, arrayM);
                }
                else arrayM = ASubtractionB(arrayM, arrayN);
                if (arrayN[arrayN.Length - 1] == 1) Console.WriteLine("Числа N и M являются простыми");
                else Console.WriteLine("Числа N и M не являются взаимо простыми");
            }
        }
    }
}
