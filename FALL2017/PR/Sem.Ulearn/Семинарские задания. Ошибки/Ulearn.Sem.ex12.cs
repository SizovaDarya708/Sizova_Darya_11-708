using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEM12
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());
            int t = int.Parse(Console.ReadLine());
            int v = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            double v1;
            double tMax, tMin;


            v1 = (double)h / t;
            if (v1 <= x)
            {
                tMax = h / (x + 1);
                tMin = 0;
            }
            else
            {
                tMax = t;
                tMin = (h - x * t) / (v - x);
            }
            Console.WriteLine(tMax);
            Console.WriteLine(tMin);

        } 
    }
}

