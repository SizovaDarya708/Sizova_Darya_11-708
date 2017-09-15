using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulearn.Sem.ex5
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstYear = int.Parse(Console.ReadLine()); // C этого года
            int lastYear  = int.Parse(Console.ReadLine()); // По этот год
            int Years = lastYear - firstYear;
            int Visocos = ((Years / 4) + (Years / 100) - (Years / (400)));

            Console.WriteLine(Visocos);

        }
    }
}
