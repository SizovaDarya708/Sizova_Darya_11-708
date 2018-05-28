using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1.Var4
{
    class Program
    {
        /* 4. Даны строковые последовательности A и B, 
         * все строки в каждой из них имеют ненулевую длину. 
         * Сформировать последовательностей строк вида «a.b», 
         * где а – строка из А, b – либо строка из B с совпадающим количеством букв "q", что и в строке a, 
         * либо строка из одного символа “!”. 
         * Расположить элементы получившейся последовательности 
         * в лексикографическом порядке по убыванию.*/
        public static IEnumerable<string> FindSequence(IEnumerable<string> seqA, IEnumerable<string> seqB)
        {
            // Проводим конкатенацию
            var item = seqA
            .Select(x => x)
            .Concat(seqB.Select(y => y));
            return item
                // Группируем для объединения
            .GroupJoin(item, x => FindLenght(x), y => FindLenght(y)
            .(x, y) => y.DefaultIfEmpty("!").Select(z => x + "." + z)
            .OrderBy(x => x);
        }

        public static int FindLenght(string item)
        {
            var count = 0;
            foreach (var it in item)
            {
                if (it == q.Lenght) count++;
            }
            return count;
        }
        static void Main(string[] args)
        {
            var A = new[] { "aaa", "a", "Aaaaaa", "!", "aa" };
            var B = new[] { "bb", "bbbb", "bbbbbbbb", "b", "bb" };

           
                

        }
    }
}


