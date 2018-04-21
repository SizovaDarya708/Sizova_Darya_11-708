using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace TimSort
{
    class Program
    {
        //Timsort — гибридный алгоритм сортировки, 
        //сочетающий сортировку вставками и сортировку слиянием
        
        /////////////////Суть алгоритма//////////////////////////////
        /*По специальному алгоритму входной массив разделяется на подмассивы.
        Каждый подмассив сортируется сортировкой вставками.
        Отсортированные подмассивы собираются в единый массив
        с помощью модифицированной сортировки слиянием.*/

        //Число minrun (минимальный размер упорядоченной последовательности)
        //Оптимальная величина для N(minrun) - это степень числа 2 (или близким к нему). 
        //Это требование обусловлено тем, что алгоритм слияния 
        //подмассивов наиболее эффективно работает на подмассивах примерно равного размера.
        public static int MinRun(List<int> Array)
        {
            int result = 1;
            if (Array[0] > Array[1])
            {
                for (int i = 0; i < Array.Count - 1; i++)
                {
                    if (Array[i] > Array[i + 1])
                    {
                        result++;
                        continue;
                    }
                    break;
                }
                Array.Reverse(0, result);
            }
            else
            {
                for (int i = 0; i < Array.Count - 1; i++)
                {
                    if (Array[i] < Array[i + 1])
                    {
                        result++;
                        continue;
                    }
                    break;
                }
            }
            return result;
        }
        public static void InsertSort(List<int> Array, int FirstIndex)
        {
            for (int i = FirstIndex; i < Array.Count; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (Array[i] <= Array[j])
                    {
                        if (j == 0)
                        {
                            Array.Insert(j, Array[i]);
                            Array.RemoveAt(i + 1);
                            break;
                        }
                        else
                            continue;
                    }
                    else
                    {
                        Array.Insert(j + 1, Array[i]);
                        Array.RemoveAt(i + 1);
                        break;
                    }
                }
            }
        }

        //Первый шаг: Разбиение списка на части и их(частей) сортировка.
        public static void FirstStep(List<int> Array, List<List<int>> Result)
        {
            int cur = 2;
            Result.Capacity = (int)Math.Log(Array.Count, 2);
            if ((int)Math.Log(Array.Count, 2) < (float)Math.Log(Array.Count, 2))
                Result.Capacity++;
            for (int i = 0; i < Result.Capacity; i++)
            {
                Result.Add(new List<int>());
                Result[i].Capacity = (int)Math.Pow(2, i);
            }
            if ((int)Math.Log(Array.Count, 2) < (float)Math.Log(Array.Count, 2))
            {
                Result[Result.Count - 1].Capacity = Array.Count - (int)Math.Pow(2, Result.Count - 1);
            }
            Result[0].Add(Array[0]);
            Result[0].Add(Array[1]);
            for (int i = 1; i < Result.Capacity; i++)
            {
                for (int j = 0; j < Result[i].Capacity; j++)
                {
                    Result[i].Add(Array[cur]);
                    if (cur + 1 != Array.Count)
                        cur++;
                }
            }

            for (int i = 0; i < Result.Count; i++)
            {
                InsertSort(Result[i], MinRun(Result[i]));
            }
        }

        // Слияние
        public static List<int> SecondStep(List<List<int>> Array)
        {
            List<int> Result = new List<int>();
            Result = Array[0];
            for (int i = 1; i < Array.Count; i++)
            {
                Result = Merge(Result, Array[i]);
            }
            return Result;
        }

        // Реализация самого алгоритма слияния
        public static List<int> Merge(List<int> a, List<int> b)
        {
            int i = 0, j = 0;
            List<int> Result = new List<int>();
            while (i < a.Count && j < b.Count)
            {
                if (a[i] <= b[j])
                {
                    Result.Add(a[i]);
                    i++;
                }
                else
                {
                    Result.Add(b[j]);
                    j++;
                }

            }
            if (i == a.Count && j != b.Count)
            {
                for (; j < b.Count; j++)
                    Result.Add(b[j]);
            }
            else if (i != a.Count && j == b.Count)
            {
                for (; i < a.Count; i++)
                    Result.Add(a[i]);
            }
            return Result;
        }
        
        // Сама сортировка, совмещение двух шагов
        public static List<int> TimSort(List<int> array)
        {
            if (array.Count <= 1)
                return array;
            List<List<int>> Result = new List<List<int>>();
            FirstStep(array, Result);
            return SecondStep(Result);
        }
        static void Main(string[] args)
        {
            List<int> Array = new List<int>();
            Console.WriteLine("Введите количество элементов сортировки");
            int countOfElements = int.Parse(Console.ReadLine());

            StreamReader text = File.OpenText("text.10000.txt");
            for (int i = 0; i < countOfElements; i++)
            {
                Array.Add(int.Parse(text.ReadLine()));
            }
            text.Close();

            // Вывод на консоль неотсортированных элементов
            Console.WriteLine("Исходные данные:");
            for (int i = 0; i < countOfElements; i++)
            {
                Console.Write(Array[i] + " ");
            }
            Console.WriteLine(" ");
           
            //Заводим секундомер
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Array = TimSort(Array);
            watch.Stop();
            var elapsed = watch.ElapsedMilliseconds;

            Console.WriteLine("Отсортированные элементы:");
            for (int i = 0; i < countOfElements; i++)
            {
                Console.Write(Array[i] + " ");
            }
            Console.WriteLine(" ");
            Console.WriteLine("Время работы программы: " + elapsed);

            Console.ReadKey();
        }
    }
}
