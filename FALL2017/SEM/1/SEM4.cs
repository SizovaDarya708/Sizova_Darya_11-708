using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEM4
{
    class Program
    { // На вход подаются n пар длин сторон прямоугольников. Нужно вывести сумму площадей трех прямоугольников с наименьшей площадью.

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количесво пар сторон прямоугольников");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите длины сторон прямоугольников");
            int length1;
            int length2;
            int area, sumOfArea;
            int minArea1 = int.MaxValue;
            int minArea2 = int.MaxValue;
            int minArea3 = int.MaxValue;

            for (int j = 0; j < n; j++)
            {
                length1 = int.Parse(Console.ReadLine());
                length2 = int.Parse(Console.ReadLine());
            
                area = length1 * length2;
                if ((area < minArea1) && (area < minArea2) && (area < minArea3))
                {
                    minArea3 = minArea2;
                    minArea2 = minArea1;
                    minArea1 = area;
                }
            }
            sumOfArea = minArea1 + minArea2 + minArea3;

            Console.WriteLine(sumOfArea);




                



        }
    }
}
