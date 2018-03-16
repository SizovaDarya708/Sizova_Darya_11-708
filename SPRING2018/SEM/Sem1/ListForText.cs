using System;

namespace ListForText
{
    class Block
    {
        private int Pointer, Lenght;
        public int Ptr { get; set; }// Номер первого элемента
        public int Len { get; set; }// Длинна
        public Block()
        {
        }
        public Block(int Pointer, int Lenght)
        {
            this.Pointer = Pointer;
            this.Lenght = Lenght;
        }
    }
    public class VirtualRAM
    {
        private List<Block> MemoryList = new List<Block>();
        public VirtualRAM()
        {

        }

        //вспомогательный метод проверки двух блоков на пересечение
        public bool IsCreateble(int Pointer, int Lenght, int Pointer_, int Lenght_)
        {
            if (Pointer > Pointer_)
            {
                if (Pointer_ + Lenght_ - 1 >= Pointer)
                    return false;
                return true;
            }
            else if (Pointer < Pointer_)
            {
                if (Pointer + Lenght - 1 >= Pointer_)
                    return false;
                return true;
            }
            else
                return false;
        }

        //Метод для вставки элемента в список. Вставки нового элемента/блока в список с проверкой на пересечение
        public bool TakeMemory(int Pointer, int Length)
        {
            for (int i = 0; i < MemoryList.Count; i++)
            {
                if (IsCreateble(Pointer, Length, MemoryList[i].Ptr, MemoryList[i].Len))
                    continue;
                else
                    return false;
            }
            MemoryList.Push(new Block(Pointer, Length));
            return true;
        }

        // Удаления элемента из списка, освобождение
        public void Free(int Pointer, int Lenght)
        {
            for (int i = 0; i < MemoryList.Count; i++)
            {
                if (MemoryList[i].Ptr == Pointer && MemoryList[i].Len == Lenght)
                {
                    MemoryList.Delete(i);
                    return;
                }
            }
        }

        // Метод кодирования, создание списка
        public VirtualRAM(String command)
        {
            if (command == "console")
            {
                int space = 0;
                String input;
                while (true)
                {
                    input = Console.ReadLine();
                    if (input == "end")
                        break;
                    
                    while (input[space] != ' ')
                     space++;
                   TakeMemory(Convert.ToInt32(input.Substring(0, space)), Convert.ToInt32(input.Substring(space)));
                    space = 0;
                }
            }
        }

        // Метод декодирования: вывод значений элементов списка в текстовый файл(в данном случае работа с консолью) с освобождением выделенной динамической памяти;
        //выводит все блоки на экран,но при этом удаляет их
        public void PrintOut()
        {
            for (int i = 0; i < MemoryList.Count; i++)
            {
                Console.Write(MemoryList[i].Ptr);
                Console.Write(" ");
                Console.Write(MemoryList[i].Len);
                Console.WriteLine("");
            }
            MemoryList = new List<Block>();
        }

        // Метод формирование нового списка из блоков длины не менее L 
        public VirtualRAM CreateNewVirtualRAM(int Lenght)
        {
            VirtualRAM ans = new VirtualRAM();
            for (int i = 0; i < MemoryList.Count; i++)
            {
                if (MemoryList[i].Len >= Lenght)
                {
                    ans.TakeMemory(MemoryList[i].Ptr, MemoryList[i].Len);
                }
            }
            return ans;
        }

        // Метод слияния двух списков (например,  второй список может формироваться при завершении работы некоторой программы 
        public static VirtualRAM Merge(VirtualRAM a, VirtualRAM b)
        {
            VirtualRAM ans = new VirtualRAM();
            for (int i = 0; i < a.MemoryList.Count; i++)
            {
                ans.TakeMemory(a.MemoryList[i].Ptr, a.MemoryList[i].Len);
            }
            for (int i = 0; i < b.MemoryList.Count; i++) // выкидывает Exception при возможных ошибках(пересечение)
            {
                if (!ans.TakeMemory(b.MemoryList[i].Ptr, b.MemoryList[i].Len))
                    throw new Exception();
            }
            return ans;
        }

        //Изменения элемента списка (при запросе оперативной памяти - запрос осуществляет пользователь)
        // или ее освобождении

        public bool Modification(int Pointer, int Lenght, int newPoiner, int newLenght)
        {
            int index = -1;
            for (int i = 0; i < MemoryList.Count; i++)
            {
                if (MemoryList[i].Ptr == Pointer && MemoryList[i].Len == Lenght)
                    index = i;
            }
            if (index == -1)
                return false;
            if (newPoiner == 0 && newLenght == -1)
            {
                MemoryList.Delete(index);
                return false;
            }
            for (int i = 0; i < MemoryList.Count; i++)
            {
                if (i != index)
                {
                    if (IsCreateble(MemoryList[i].Ptr, MemoryList[i].Len, newPoiner, newLenght))
                        continue;
                    else
                        return false;
                }
            }
            MemoryList[index].Ptr = newPoiner;
            MemoryList[index].Len = newLenght;
            return true;
        }
    }

    class Node<T>
    {
        public void SetNextNode(Node<T> _nextNode)
        {
            this.next = _nextNode;
        }
        public T Element
        {
            get
            {
                return this.element;
            }
            set
            {
                this.element = value;
            }
        }

        public Node<T> Next
        {
            get
            {
                return this.next;
            }
        }

        private Node<T> next;
        private T element;
    }
    class List<T>
    {
        public List()
        {
            // создание пустого списка 
            this.headNode = null;
            this.tailNode = this.headNode;
            this.Count = 0;
        }
        //Метод добавления в список элемента 
        public void Push(T _element)
        {
            if (headNode == null)// Выполнение при создании списка 
            {
                // создать узел, сделать его головным 
                this.headNode = new Node<T>();
                this.headNode.Element = _element;
                // этот же узел и является хвостовым 
                this.tailNode = this.headNode;
                // следующего узла нет 
                this.headNode.SetNextNode(null);
            }
            else
            {
                // создать временный узел 
                Node<T> newNode = new Node<T>();
                // следующий за предыдущим хвостовым узлом - это временный новый узел 
                this.tailNode.SetNextNode(newNode);
                // сделать его же новым хвостовым 
                this.tailNode = newNode;
                this.tailNode.Element = _element;
                // следующего узла пока нет 
                this.tailNode.SetNextNode(null);
            }

            ++this.Count;
        }
        public T this[int index]
        {
            get
            {
                Node<T> tempNode = this.headNode;
                for (int i = 0; i < index; ++i)
                    // переходим к следующему узлу списка 
                    tempNode = tempNode.Next;
                return tempNode.Element;
            }
            set { }
        }
        public void Delete(int index)
        {
            if (index == 0)
                headNode = headNode.Next;
            else if (index == Count - 1)
            {
                Node<T> tempNode = this.headNode;
                for (int i = 0; i < index - 1; ++i)
                    // переходим к следующему узлу списка 
                    tailNode = tempNode;
            }
            else
            {
                Node<T> tempNode = this.headNode;
                for (int i = 0; i < index - 1; ++i)
                    // переходим к следующему узлу списка 
                    tempNode = tempNode.Next;
                tempNode.SetNextNode(tempNode.Next.Next);
            }
            Count--;
        }
        public int Count { get; private set; }
        private Node<T> headNode;
        private Node<T> tailNode;
    }
    class Program
    {
        static void Main(string[] args)
        {
            int pointer = 1;
            int pointer_ = 2;
            int length = 3;
            int length = 3;
            int index = 0;
            VirtualRAM ram = new VirtualRAM("console");
            VirtualRAM sad = new VirtualRAM("console"), merg;
            merg = VirtualRAM.Merge(sad, ram);
            merg.PrintOut();
            merg.IsCreateble(pointer, length, pointer_, Lenght_);
            merg.Modification(index, pointer, length);
            merg.TakeMemory(pointer, length);
        }
    }
}
