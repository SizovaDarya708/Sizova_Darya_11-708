using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulearn.Sem.ex11
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minute = int.Parse(Console.ReadLine());
            int gradus;

            minute = minute*6;
            hours = hours*30;
            
            if (hours > minute) // Для исключения получения отрицательных чисел
            { gradus = hours - minute; }
            else
            { gradus = minute - hours; }

            if (gradus > 180)
            { gradus = 360 - gradus; } // Для выражения острого угла

            Console.WriteLine(gradus);
            
        }
    }
}
