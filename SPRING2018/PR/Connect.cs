using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите колличество вершин");
            int tops = int.Parse(Console.ReadLine());
            int[] array = new int[tops]; // Массив с предыдущем элементом
            int[] arrayOfCount = new int[tops]; // Массив с числом вершин

            for (int i = 0; i < tops; i++)
            {
                array[i] = i;
                arrayOfCount[i] = 1;
            }
            
            for(; ;)
            {
                Console.WriteLine("Введите числа связности");
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                int x = a;
                int y = b;

                while (x != array[x]) // Числа не связны
                {
                    array[x] = array[array[x]]; // изменение ссылки на предыдущий элемент
                    x = array[x];
                }

                while (y != array[y])
                {
                    array[y] = array[array[y]];
                    y = array[y];
                }

                if (x != y) // Если вершины не связны
                {
                    Console.WriteLine(a + "связан с " + b);

                    if (arrayOfCount[x] >= arrayOfCount[y]) // Проводим сравнение графов
                    {
                        array[y] = x;
                        arrayOfCount[x] += arrayOfCount[y];
                    }
                    else
                    {
                        array[x] = y;
                        arrayOfCount[y] += arrayOfCount[x];        
                    }
                }
                else Console.WriteLine("Ошибка связности");
            }
        }
    }
}
