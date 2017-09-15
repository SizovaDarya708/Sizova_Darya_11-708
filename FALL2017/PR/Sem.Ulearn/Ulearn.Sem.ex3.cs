using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem.Ulearn2
{
    class Program
    {
        static void Main(string[] args)
        {

            int a = 123;
            string c = a.ToString();
            char[] b = c.ToCharArray(); // копия символов в Юникод
            Array.Reverse(b); // Зеркальное отображение 
            c = new string(b); 
            a = Convert.ToInt32(c);


            Console.WriteLine(a.ToString());

        }
    }
}
