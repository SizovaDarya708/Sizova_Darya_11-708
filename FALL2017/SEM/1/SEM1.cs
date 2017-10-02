using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEM1
{
    class Program
    //  По паре координат шахматной доски (каждая координата на отдельной строке) определить, возможен ли ход из одной позиции в другую конём (YES|NO)
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты начального положения фигуры");
            x1 = int.Parse(Console.ReadLine()); // Координата точки первоначального нахождения шахматной фигуры(конь). 
            y1 = int.Parse(Console.ReadLine()); // Координата точки первоначального нахождения шахматной фигуры(конь).
            Console.WriteLine("Введите координаты начального положения фигуры");
            x2 = int.Parse(Console.ReadLine()); // Координата возможного перемещения шахматной фигуры (коня)
            y2 = int.Parse(Console.ReadLine()); // Координаты возможного перемещения шахматной фигуры (коня)

            if (x1 + 1==x1)
            {   if ((y1 + 2 == y2) | (y1 - 2 == y2)) 
                { c++; }
            }

            if (x1 - 1 == x2)
            {   if ((y1 + 2 == y2) | (y1 - 2 == y2))
                { c++; }
            }

            if (y1 + 1 == y2)
            {
                if ((x1 + 2 == x2) | (x1 - 2 == x2))
                { c++; }
            }

            if (c==1)
             Console.WriteLine("YES"); 
            else
             Console.WriteLine("NO"); 


    }
}
