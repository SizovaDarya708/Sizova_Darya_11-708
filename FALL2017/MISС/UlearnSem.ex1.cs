using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem.Ulearn1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 7;

            b = b - a; // Значение 2
            a = a + b; // Значение 7
            b = a - b; // Значение 5
            Console.WriteLine(a.ToString() + ", " + b.ToString());
            
           

            
        }
    }
}
