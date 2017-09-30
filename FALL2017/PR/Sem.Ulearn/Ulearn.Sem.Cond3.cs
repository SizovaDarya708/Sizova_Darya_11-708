using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cound3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер билета");
            int ticketsNumber = int.Parse(Console.ReadLine());
            if (((ticketsNumber + 1)%10 + ((ticketsNumber + 1)/10)%10 + ((ticketsNumber + 1)/100)%10 == ((ticketsNumber + 1)/1000)%10 + ((ticketsNumber + 1)/10000)%10 + ((ticketsNumber + 1)/100000)) ||
            ((ticketsNumber - 1)%10 + ((ticketsNumber - 1)/10)%10 + ((ticketsNumber - 1)/100)%10 == ((ticketsNumber - 1)/1000)%10 + ((ticketsNumber - 1)/10000)%10 + ((ticketsNumber - 1)/100000)))
                Console.WriteLine("true");
            else
                Console.WriteLine("true");
           
        }
    }
}