using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;                 
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
       /* Быстрая сортировка относится к алгоритмам «разделяй и властвуй».
        Алгоритм состоит из трёх шагов:

        1)Выбрать элемент из массива.Назовём его опорным.
        2)Разбиение: перераспределение элементов в массиве таким образом,
        что элементы меньше опорного помещаются перед ним, а больше или равные после.
        3)Рекурсивно применить первые два шага к двум подмассивам слева и справа от опорного элемента. 
        Рекурсия не применяется к массиву, в котором только один элемент или отсутствуют элементы.*/
    {
        // Разбиение - разделение массива
        public static int ToDivide(int[] array, int start, int end)
        {
            int temp;//помощник обмена
            int marker = start;//делит левый и правый подмассивы
            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end]) //array[end] является опорным элементом
                {
                    temp = array[marker]; // замена
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            //положение опорного элемента(array[end]) между левой и правой частью подмассива
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }

        // реализация самой сортировки слияния
        public static void Quicksort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            // применение рекурсии 
            int pivot = ToDivide(array, start, end);
            Quicksort(array, start, pivot - 1);
            Quicksort(array, pivot + 1, end);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов сортировки");
            int size = int.Parse(Console.ReadLine());
            int[] array = new int[size];
            
            StreamReader text = File.OpenText("text.10000.txt");
            for (int i = 0; i < size; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            text.Close();

            // Вывод на консоль неотсортированных элементов
            Console.WriteLine("Исходные данные:");
            for (int i = 0; i < size; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine(" ");

            //Заводим секундомер
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Quicksort(array, 0, size-1);
            watch.Stop();
            var elapsed = watch.ElapsedMilliseconds;

            Console.WriteLine("Отсортированные элементы:");
            for (int i = 0; i < size; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine(" ");
            Console.WriteLine("Время работы программы: " + elapsed);

            Console.ReadKey();
        }
    }
}
