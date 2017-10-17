using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops1
{
    class Program
    { // Дано целое неотрицательное число N. Найти число, составленное теми же десятичными цифрами, что и N, но в обратном порядке. Запрещено использовать массивы.
        static void Main(string[] args)
        {
            string N = Console.ReadLine();
            char[] b = N.ToCharArray();
            Array.Reverse(b);
            N = new string(b);
            Console.WriteLine(N);
        }
    }
}
