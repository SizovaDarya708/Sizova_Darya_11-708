using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreu
{
    class Program

    {
        public static void FareiSequence(int n)
        {
            Console.WriteLine("{0} / {1}", 0, 1);
            FareiSequence(n, 0, 1, 1, 1);
            Console.WriteLine("{0} / {1}", 1, 1);
        }

        private static void FareiSequence(int n, int x, int y, int z, int t)
        {
            int a = x + z, b = y + t;
            if (b <= n)
            {
                FareiSequence(n, x, y, a, b);
                Console.WriteLine("{0} / {1}", a, b);
                FareiSequence(n, a, b, z, t);
            }
        }

        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            FareiSequence(k);
            Console.ReadKey();
        }

    }
}
