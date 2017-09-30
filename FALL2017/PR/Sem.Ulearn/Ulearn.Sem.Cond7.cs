using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cound7
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            int minOfVoices = (int)Math.Floor((x - y)*n / (y - 1)) + 1;
            Console.WriteLine(minOfVoices);
        }
    }
}