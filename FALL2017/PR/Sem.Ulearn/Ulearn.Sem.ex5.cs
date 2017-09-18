
﻿using System;
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
            int years = lastYear - firstYear;
            int visocos = ((years / 4) + (years / 100) - (years / (400)));

            Console.WriteLine(visocos);

        }
    }
}

