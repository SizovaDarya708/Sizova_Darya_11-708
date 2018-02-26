using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите необходимую размерность листа");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите в консоль индекс искомого элемента");
            int elementForSearch  = int.Parse(Console.ReadLine());


            var elenent = new MyList();

            for (int i = 0; i < n; i++)
            {
                elenent.Push(i);
            }
            Console.WriteLine(elenent.Search(elementForSearch));

            Console.WriteLine(elenent.Count());
            elenent.PrintOut();

        }
    }

   

    public class MyList
    {
        public Node tail;
        public Node head;
        public Node element;

       public void Push(int data)
        {
            if (head != null)
            {
                element = new Node(data);
                tail.Next = element;
                tail = element;
                
            }
            else
            {
                tail = head = new Node(data);
            }

        }

       

        public class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }

            public Node(int elem)
            {
                Data = elem;
                Next = null;
            }
        }

        public int Count()
        {
            element = head;
            int i = 0;
            while (element.Next != null)
            {
                i++;
                element = element.Next;
            }
            return i;
        }

        public int Pop()
        {
            if (head == null)
            {
                Console.WriteLine("Ошибка");
            }
            var res = head.Data;

            head = head.Next;

            if (head == null)
            {
                tail = null;
            }
            return res;
        }

        public int Search(int value)
        {
            if (head == null)
            {
                Console.WriteLine("Ошибка");
            }

            int i = 0;
            element = head;

            while (value != element.Data)
            {
                element = element.Next;
                i++;
           }
           return i+1;
       }

        

        public void PrintOut()
        {
            element = head;
            if (element == null)
            {
                Console.WriteLine("Ошибка");
            }
            Console.WriteLine(element.Data);
            while (element.Next != null)
            {
                element = element.Next;
                Console.WriteLine(element.Data);
                
            }
            
        }
       


    }


}
