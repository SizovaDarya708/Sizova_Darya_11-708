using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulearn.Sem.Cond4
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            if (Math.Max(b-c, d-a) <= ((b-a) + (d-c)))
            {
                Console.WriteLine(Math.Min(b, d) - Math.Max(a, c));
            }
            else Console.WriteLine(0);
        }
    }
}
