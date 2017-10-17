using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulearn.Sem.Cond1
{
    class Program
    {
        static bool FigureCorrect(int x, int y, string typeOfFigure)
        {

            if (typeOfFigure == "Слон") return (x == y) && ((y == 0) && !((x == 0)));
            if (typeOfFigure == "Конь") return ((x == 2) && (y == 1)) || ((x == 1) && (y == 2));
            if (typeOfFigure == "Ладья") return (((x != 0) && (y == 0) || (y != 0) && (x == 0)));
            if (typeOfFigure == "Королева") return ((x == 0) || (y == 0) || (x == y)) && (!(x == 0) && (y == 0));
            if (typeOfFigure == "Король") return (x == 1) && (y == 1);
            return false;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Введите название фигуры");
            string figure = Console.ReadLine();
            Console.WriteLine("Введите начальное положение фигуры");
            string start = Console.ReadLine();
            Console.WriteLine("Введите положение, в которой должна оказаться фигура");
            string finish = Console.ReadLine();

            int distanceX = Math.Abs(start[0] - finish[0]);  // движение по оси абсцисс
            int distanceY = Math.Abs(start[1] - finish[1]); // движение по оси ординат

            Console.WriteLine(FigureCorrect(distanceX, distanceY, figure));


        }
    }
}
