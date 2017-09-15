using System;
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
           int N = int.Parse(Console.ReadLine()) - 1; // Числа, меньшие N
           int Y = int.Parse(Console.ReadLine());
           int X = int.Parse(Console.ReadLine());
           int A = ((N / X) + (N / Y) - (N / (X * Y)));
            Console.WriteLine(A);



           



        }
    }
}
