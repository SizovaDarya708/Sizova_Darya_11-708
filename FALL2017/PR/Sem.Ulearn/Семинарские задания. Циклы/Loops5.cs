using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops5
{
    class Program
    { // Дана строка из символов '(' и ')'.Определить, является ли она корректным скобочным выражением. Определить максимальную глубину вложенности скобок.
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку скобок");
            var str = Console.ReadLine();

            int nesting = 0,  // начальная вложенность
                maxNesting = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                    nesting++;
                if (nesting > maxNesting)
                    maxNesting = nesting;
                if (str[i] == ')')
                    nesting--;
            }
            if (nesting == 0)
                Console.WriteLine("Максимальная вложенность скобок" + maxNesting);
            else Console.WriteLine("Некорректный ввод строки");

        }
    }
}
