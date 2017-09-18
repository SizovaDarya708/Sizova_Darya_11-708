
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulearn.Sem.ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()) - 1; // Числа, меньшие N
            int y = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            int a = ((n / x) + (n / y) - (n / (x * y)));
            Console.WriteLine(a);

        }
    }
}

           
