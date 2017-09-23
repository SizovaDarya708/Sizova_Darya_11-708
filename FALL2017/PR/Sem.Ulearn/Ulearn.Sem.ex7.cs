using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulearn.Sem.ex7
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
           
            Console.WriteLine("Перпендикулярный вектор:(" + (-x).ToString() + ";1)");
            Console.WriteLine("Параллельный вектор:(1;" + x.ToString() + ")");
        
        }
    }
}
