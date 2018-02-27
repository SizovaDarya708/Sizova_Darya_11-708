using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Связность
{
    

    class Program
    {

        public static bool FindConnectivity(int i, int j, int[] arrayOfConnectivy)
        {

        }



        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество вершин");
            int tops = int.Parse(Console.ReadLine());
            int[] array = new int[tops];
            Console.WriteLine("Введите количество пар чисел связности");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine("Введите пару чисел");
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                array[a] = b;
            }

            
            
        }
    }
}
