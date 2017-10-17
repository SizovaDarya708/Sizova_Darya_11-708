using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulearn.Sem.ex13
{
    class Program
    {
        static void Main(string[] args)
        {
            double x;
            double y;
            string str = Console.ReadLine();
            double a;
            a = double.Parse(str.Substring(0, str.IndexOf(' ')));
            str = str.Substring(str.IndexOf(' ') + 1);
            double radius = double.Parse(str);
            if (a/2 >= radius)
            {
                double field = Math.Round(radius * radius * Math.PI, 3);
                Console.WriteLine(field);
            }
            else
            {
                if (Math.Pow(radius, 2) - Math.Pow(a/2, 2) >= Math.Pow(a/2, 2))
                {
                    double field = Math.Pow(a, 2);
                    Console.WriteLine(field);
                }
                else
                { 
                    x = Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(a/2, 2));
                    y = 2 * Math.Asin(x/radius);
                    double area = Math.Pow(radius, 2) * Math.PI - 4 * 0.5 * (y - Math.Sin(y)) * Math.Pow(radius, 2);
                    Console.WriteLine(Math.Round(area, 3));
                }
    }
}
