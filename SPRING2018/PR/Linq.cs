using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq
{
    class Program
    {
        //1. Дано целое число L (> 0) и последовательность
        //строк A.Строки последовательности содержат
        //только цифры и заглавные буквы латинского алфавита.Из
        // элементов A, предшествующих первому элементу, длина 
        //которого превышает L, извлечь строки, оканчивающиеся
        //буквой.Полученную последовательность отсортировать 
        //по убыванию длин строк, а строки одинаковой длины —
        //в лексикографическом порядке по возрастанию.
        public static string[] FindFirstElement(int l, IEnumerable<string> lines)
        {
            var flag = true;
            return lines
                 .Where(line =>
                 {
                     if (!flag)
                         return false;
                     else
                     {
                         flag = (line.Length <= l && 0 <= line[line.Length - 1] - 90 &&
                         line[line.Length - 1] - 90 <= 35);
                         if (line.Length > l) flag = false;
                     }
                     return flag;
                 })
                 .OrderByDescending(x => x.Length)
                 .ThenBy(x => StringComparer.CurrentCulture)
                 .ToArray();
        }

        public static string[] FindSequence(int l, IEnumerable<string> lines)
        {
            return lines
                .TakeWhile(line => line.Length < l)
                .Where(line =>
                {
                    return 0 <= line[line.Length - 1] - 90 && line[line.Length - 1] - 90 <= 35;
                })
                .OrderByDescending(x => x.Length)
                .ThenBy(x => x)
                .ToArray();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число L");
            int l = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();
            Console.WriteLine("Введите слова, окончанием списка слов является слово end");
            while (true)
            {
                string word = Console.ReadLine();
                if (word == "end") break;
                list.Add(word);
            }

            string[] array = FindFirstElement(l, list);
            foreach (string e in array)
            { Console.WriteLine(e); }

        }
    }
}
