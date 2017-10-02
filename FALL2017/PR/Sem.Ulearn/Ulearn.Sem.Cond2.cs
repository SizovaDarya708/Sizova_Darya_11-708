using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulearn.Sem.Cond2
{   // Пролезет ли брус со сторонами x, y, z в отверстие со сторонами a, b, если его разрешается поворачивать на 90 градусов?
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ширину бруска");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите длину бруска");
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите высоту бруска");
            int z = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите ширину отверстия");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите высоту отверстия");
            int b = int.Parse(Console.ReadLine());
            
            if (((x <= a || x <= b) && (y <= a || y <= b)) || ((x <= a || x <= b) && (z <= a || z <= b)) || ((y <= a || y <= b) && (z <= a || z <= b)))
                Console.WriteLine("Брусок пройдет в отверстие");
            else Console.WriteLine("Брусок не пройдет в отверстие");

           
        }
    }
}
