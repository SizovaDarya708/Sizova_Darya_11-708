using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;



namespace Shell.Sort
{
    class Program
    {
        public static int ShellSortIterations = 0;
        public static int InsertSortIterations = 0;
        public static void ShellSort(int n, int[] array)
        {
            int i;
            int j;
            int step; // Расстояние между значениями, которые будут сравниваться 
            // ему первоначально присваивается длина массива
            int tmp = 0;
            for (step = n / 2; step > 0; step /= 2)
                for (i = step; i < n; i++)
                {
                    tmp = array[i];
                    for (j = i; j >= step; j -= step)
                    {
                        ShellSortIterations++;
                        if (tmp < array[j - step])
                            array[j] = array[j - step];
                        else
                            break;
                    }
                    array[j] = tmp;
                }
        }

        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int cur = array[i];
                int j = i;
                while (j > 0 && cur < array[j - 1])
                {
                    InsertSortIterations++;
                    array[j] = array[j - 1];
                    j--;
                } 
                array[j] = cur;
            }
        }

        static void Main(string[] args)
        {
            // Готовим массивы для сортировок
            Console.WriteLine("Введите необходимую размерность массива");
            Console.WriteLine("Например: 50, 100, 200, 300, 400, 500, 1000, 1500, 2000, ..., 10000");
            int arraySize = int.Parse(Console.ReadLine());
            int[] arrayOfRandomElements = new int[arraySize];
            int[] arrayOfRandomElements2 = new int[arraySize];
            Console.WriteLine(" ");
           
            // Ручное открытие файла в зависимости от размерности массива
            // Файл имя text."размерность массива".txt
            StreamReader text = File.OpenText("text.10000.txt");
            for (int i = 0; i < arrayOfRandomElements.Length; i++)
            {
                arrayOfRandomElements[i] = int.Parse(text.ReadLine());
            }
            text.Close();
            arrayOfRandomElements.CopyTo(arrayOfRandomElements2, 0);
            
            //Выводим на консоль, получившийся массив
            Console.WriteLine("Исходный массив");
            Console.WriteLine(" ");
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write(arrayOfRandomElements[i] + " ");
            }
            Console.WriteLine(" ");

            //Заводим секундомер
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ShellSort(arraySize, arrayOfRandomElements);
            watch.Stop();
            var elapsed = watch.ElapsedMilliseconds;

            //Массив после сортировки Шелла
            Console.WriteLine("Массив после сортировки Шелла");
            Console.WriteLine(" ");
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write(arrayOfRandomElements[i] + " ");
            }
            Console.WriteLine(elapsed);
            Console.WriteLine(" ");

            // Вновь заводим секундомер
            watch.Restart();
            InsertionSort(arrayOfRandomElements2);
            watch.Stop();
            var elapsedTwo = watch.ElapsedMilliseconds;

            // Массив после сортировки вставками
            Console.WriteLine("Массив после сортировки Вставками");
            Console.WriteLine(" ");
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write(arrayOfRandomElements2[i] + " ");
            }
            Console.WriteLine(elapsedTwo);
            
            Console.WriteLine("ShellSort iterations = " + ShellSortIterations.ToString());
            Console.WriteLine("InsertSort iterations = " + InsertSortIterations.ToString());
            Console.ReadKey();
        }
    }
}

