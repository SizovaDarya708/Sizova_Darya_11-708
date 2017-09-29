using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise
{
    class Program
    {
        static double GetDistance(double ax, double ay, double bx, double by)
        {
           return Math.Sqrt(Math.Abs((bx - ax) * (bx - ax) - (by - ay) * (by - ay)));
        }
        static double GetCentreOgSquareX(double ax, double bx)
        {
            return ((ax + bx) / 2);
        }
        static double GetCentreOgSquareY(double ay, double by)
        {
           return ((ay + by) / 2);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Поочередно введите координаты  1 точки квадрата");
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Поочередно введите координаты  2 точки квадрата");
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Поочередно введите координаты  3 точки квадрата");
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            Console.WriteLine("Поочередно введите координаты  4 точки квадрата");
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите координаты центра окружности");
            double x5 = double.Parse(Console.ReadLine());
            double y5 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите радиус");
            double r = double.Parse(Console.ReadLine());
            double centreOfSquareX, centreOfSquareY, sideOfSquare;

            double firstSide = (GetDistance(x1, y1, x2, y2));
            double secondSide = (GetDistance(x1, y1, x3, y3));
            double thirdSide = (GetDistance(x1, y1, x4, y4));

            if ((firstSide > secondSide) && (firstSide > thirdSide))
            {
                centreOfSquareX = (GetCentreOgSquareX(x1, x2));
                centreOfSquareY = (GetCentreOgSquareY(y1, y2));
               sideOfSquare = secondSide / 2;
            }
            else if ((secondSide > firstSide) && (secondSide > thirdSide))
            {
                centreOfSquareX = (GetCentreOgSquareX(x1, x3));
                centreOfSquareY = (GetCentreOgSquareY(y1, y3));
               sideOfSquare = firstSide / 2;
            }
            else
            {
                centreOfSquareX = (GetCentreOgSquareX(x1, x4));
                centreOfSquareY = (GetCentreOgSquareY(y1, y4));
                sideOfSquare = firstSide / 2;
            }
            Console.WriteLine((centreOfSquareX == x5) && (centreOfSquareY == y5) && (sideOfSquare == r));



             

        }
    }
}
