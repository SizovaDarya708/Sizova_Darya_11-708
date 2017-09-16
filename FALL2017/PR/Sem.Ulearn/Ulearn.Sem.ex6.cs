using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem.Ulearn.ex6
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine()); // Уравнение прямой задается: ax + by + c = 0
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            double distance = ((Math.Abs(a * x + b * y + c)) / (Math.Sqrt(a * a + b * b)));
            Console.WriteLine(distance);
        }
    }
}
