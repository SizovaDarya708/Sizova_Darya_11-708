using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulearn.Sem.ex8
{
    class Program
    {
        static void Main(string[] args)
        {
          double a1 = int.Parse(Console.ReadLine());
          double b = int.Parse(Console.ReadLine());
          double x = int.Parse(Console.ReadLine()); // абсцисса точки, через которую проводится перпендикуляр к прямой
          double y = int.Parse(Console.ReadLine()); // ордината точки, через которую проводится перпендикуляр к прямой
            double a2 = Math.Round(-1 /a1, 2); // нахождение коэффицента прямой(перпендикулярной данной)
            double b2 = Math.Round((y - a2*x), 2); // нахождение перехода перпендикуляра
            double x1 = Math.Round(((b2 - b)/(a1 - a2)), 2); // находим абсциссу точки пересечения прямых
            double y1 = Math.Round((x1*a2 + b2), 2);// находим ординату точки пересечения прямых
            Console.WriteLine("Точка пересечения прямой и перпендикуляра, проведенного к ней: ({0};{1})", x1, y1);
        }
    }
}
