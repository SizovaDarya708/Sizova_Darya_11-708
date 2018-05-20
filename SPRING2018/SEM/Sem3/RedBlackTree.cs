﻿using System;

namespace RedBlackTree
{
    // Красно-чёрное дерево — это одно из самобалансирующихся двоичных деревьев поиска, 
    //гарантирующих логарифмический рост высоты дерева от числа узлов
    public enum Colors
    {
        Black,// черный цвет узла(его потомки могут быть красн/черн)
        Red,// Красный цвет узла(может быть потомком или родителем только  черных узлов)
        DoubleBlack// внешний узел(всегда черного цвета, этот узел не хранит значения)
    };

    public class Node<TKey, TVal>
    {
        private Colors color;
        private TKey key;// Дерево имеет доступ к значениям по ключу
        private TVal value;
        // Левые и правые ветви(красно-черн. дерево всегда имеет обе ветви, достигается засчет внешних узлов)
        private Node<TKey, TVal> left;
        private Node<TKey, TVal> right;
        private Node<TKey, TVal> parent;
        // Левые узлы
        public Node<TKey, TVal> Left
        {
            get { return left; }
            set
            {
                left = value;
            }
        }
        //Правые узлы
        public Node<TKey, TVal> Right
        {
            get { return right; }
            set
            {
                right = value;
            }
        }
        public Node<TKey, TVal> Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        public TVal Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        public Colors Color
        {//Цвета, помогающие при самобалансировки
            get { return color; }
            set { color = value; }
        }
        public TKey Key
        {
            get { return key; }
            set { key = value; }
        }
        public Node(Colors color, TKey key, TVal value, Node<TKey, TVal> parent)
        {
            this.color = color;
            this.key = key;
            this.value = value;
            this.parent = parent;
            left = null;
            right = null;
        }
    }
    // Класс Красно-черного дерева
    public class RBTree<TKey, TVal>
    {
        private Node<TKey, TVal> Root;
        private Func<TKey, TKey, int> Comp;   // T1 < T2 = 1 , T1 == T2 = 0 , T1 > T2 = -1
        //Вставка узла, при этом по правилам красн-черн. дерева вставляемый узел всегда красный
        private Node<TKey, TVal> PutToPlace(Node<TKey, TVal> Current, TKey key, TVal value)
        {
            if (Current == null)
                return new Node<TKey, TVal>(Colors.Red, key, value, null);
            if (Comp(Current.Key, key) == 1 && Current.Right == null)
            {
                Current.Right = new Node<TKey, TVal>(Colors.Red, key, value, Current);
                return Current.Right;
            }
            if (Comp(Current.Key, key) == -1 && Current.Left == null)
            {
                Current.Left = new Node<TKey, TVal>(Colors.Red, key, value, Current);
                return Current.Left;
            }

            if (Comp(Current.Key, key) == 1)
                return PutToPlace(Current.Right, key, value);
            else if (Comp(Current.Key, key) == -1)
                return PutToPlace(Current.Left, key, value);
            return null;
        }
        // узел: "Родитель родителя"
        private Node<TKey, TVal> Grandparent(Node<TKey, TVal> from)
        {
            if ((from != null) && (from.Parent != null))
                return from.Parent.Parent;
            else
                return null;
        }
        // узел: "Дядя"
        private Node<TKey, TVal> Uncle(Node<TKey, TVal> From)
        {
            if (From.Parent != null)
            {
                if (From.Parent.Parent != null)
                {
                    return Sibling(From.Parent);
                }
            }
            return null;
        }
        // Поворот в левую сторону
        private Node<TKey, TVal> LeftRotate(Node<TKey, TVal> Current)
        {
            Node<TKey, TVal> Root = Current.Parent.Parent;
            Node<TKey, TVal> NewRoot = Root.Right;
            if (Root.Left == null && Current == Root.Right.Left)
            {
                Node<TKey, TVal> sRoot = Current.Parent;
                Node<TKey, TVal> sNewRoot = sRoot.Left;

                sRoot.Left = sNewRoot.Right;
                sNewRoot.Right = sRoot;

                sNewRoot.Parent = sRoot.Parent;
                sRoot.Parent = sNewRoot;
                if (sNewRoot.Parent != null)
                {
                    if (Root.Left == sRoot)
                        sNewRoot.Parent.Left = sNewRoot;
                    else
                        sNewRoot.Parent.Right = sNewRoot;
                }
                Current = sRoot;
                NewRoot = sNewRoot;
            }
            Root.Right = NewRoot.Left;
            NewRoot.Left = Root;

            NewRoot.Parent = Root.Parent;
            Root.Parent = NewRoot;
            Current.Parent = NewRoot;
            if (NewRoot.Parent != null)
            {
                if (NewRoot.Parent.Left == Root)
                    NewRoot.Parent.Left = NewRoot;
                else
                    NewRoot.Parent.Right = NewRoot;
            }

            NewRoot.Color = Colors.Black;
            NewRoot.Left.Color = Colors.Red;
            NewRoot.Right.Color = Colors.Red;
            return NewRoot;
        }
        // Поворот в правую сторону
        private Node<TKey, TVal> RightRotate(Node<TKey, TVal> Current)
        {
            Node<TKey, TVal> Root = Current.Parent.Parent;
            Node<TKey, TVal> NewRoot = Root.Left;
            if (Root.Right == null && Current == Root.Left.Right)
            {
                Node<TKey, TVal> sRoot = Current.Parent;
                Node<TKey, TVal> sNewRoot = sRoot.Right;

                sRoot.Right = sNewRoot.Left;
                sNewRoot.Left = sRoot;

                sNewRoot.Parent = sRoot.Parent;
                sRoot.Parent = sNewRoot;
                if (sNewRoot.Parent != null)
                {
                    if (Root.Right == sRoot)
                        sNewRoot.Parent.Right = sNewRoot;
                    else
                        sNewRoot.Parent.Left = sNewRoot;
                }
                Current = sRoot;
                NewRoot = sNewRoot;
            }
            Root.Left = NewRoot.Right;
            NewRoot.Right = Root;

            NewRoot.Parent = Root.Parent;
            Root.Parent = NewRoot;
            Current.Parent = NewRoot;
            if (NewRoot.Parent != null)
            {
                if (NewRoot.Parent.Left == Root)
                    NewRoot.Parent.Left = NewRoot;
                else
                    NewRoot.Parent.Right = NewRoot;
            }

            NewRoot.Color = Colors.Black;
            NewRoot.Left.Color = Colors.Red;
            NewRoot.Right.Color = Colors.Red;
            return NewRoot;
        }
        // Поиск корня
        private Node<TKey, TVal> FindRoot(Node<TKey, TVal> Current)
        {
            if (Current.Parent == null)
                return Current;
            return FindRoot(Current.Parent);
        }
        // Потомок-узел от одного родителя-узла
        private Node<TKey, TVal> Sibling(Node<TKey, TVal> Current)
        {
            if (Current == Current.Parent.Left)
                return Current.Parent.Right;
            else if (Current == Current.Parent.Right)
                return Current.Parent.Left;
            else if (Current.Parent.Right == null && Current.Parent.Left != null)
                return Current.Parent.Left;
            else if (Current.Parent.Right != null && Current.Parent.Left == null)
                return Current.Parent.Right;
            else
                return null;
        }
        //Проверка узла на его конечность/внешность, отсутствие потомков
        private bool IsLeaf(Node<TKey, TVal> Current)
        {
            if (Current.Left == null && Current.Right == null)
                return true;
            return false;
        }
        //Проверка того, что узел является единственным потомком родителя
        private Node<TKey, TVal> IsOneChild(Node<TKey, TVal> From)
        {
            if (From.Right != null && From.Left == null)
                return From.Right;
            else if (From.Right == null && From.Left != null)
                return From.Left;
            else return null;
        }
        private void Case2_2(Node<TKey, TVal> Current)//Красный брат
        {
            Current.Parent.Parent.Color = Colors.Red;
            Current.Parent.Color = Colors.Black;
            Uncle(Current).Color = Colors.Black;
            Case1(Current.Parent.Parent);
        }
        private void Case2_1(Node<TKey, TVal> Current) //Красный и черный брат
        {
            Node<TKey, TVal> ans;
            if (Current.Parent == Current.Parent.Parent.Right)
                ans = LeftRotate(Current);
            else
                ans = RightRotate(Current);
            if (ans.Parent == null)
                Root = ans;
        }
        private void Case2(Node<TKey, TVal> Current)//Красный родитель и его потомок
        {
            if (Current.Parent == null)
                return;
            Node<TKey, TVal> Uncle_ = Uncle(Current);
            if (Uncle_ == null || Uncle_.Color == Colors.Black)
                Case2_1(Current);
            else
                Case2_2(Current);
        }
        private void Case1(Node<TKey, TVal> Current) //Черный родитель и красный потомок 
        {
            if (Current.Parent != null)
            {
                if (Current.Parent.Color == Colors.Red)
                {
                    Case2(Current);
                }
            }
        }
        // Добавление значения и ключа в узел
        public void Add(TKey key, TVal value)
        {
            if (Root == null)
                Root = PutToPlace(Root, key, value);
            else
                Case1(PutToPlace(Root, key, value));
            Root.Color = Colors.Black;
        }
        private Node<TKey, TVal> DelLeftRotate(Node<TKey, TVal> Current)
        {
            Node<TKey, TVal> Root = Current;
            Node<TKey, TVal> NewRoot = Root.Right;
            Root.Right = NewRoot.Left;
            NewRoot.Left = Root;

            NewRoot.Parent = Root.Parent;
            Root.Parent = NewRoot;
            Current.Parent = NewRoot;
            if (Root.Left != null)
                Root.Left.Parent = Root;
            if (Root.Right != null)
                Root.Right.Parent = Root;
            if (NewRoot.Left != null)
                NewRoot.Left.Parent = NewRoot;
            if (NewRoot.Right != null)
                NewRoot.Right.Parent = NewRoot;
            if (NewRoot.Parent != null)
            {
                if (NewRoot.Parent.Left == Root)
                    NewRoot.Parent.Left = NewRoot;
                else
                    NewRoot.Parent.Right = NewRoot;
            }
            this.Root = FindRoot(Root);
            return NewRoot;
        }
        private Node<TKey, TVal> DelRightRotate(Node<TKey, TVal> Current)
        {
            Node<TKey, TVal> Root = Current;
            Node<TKey, TVal> NewRoot = Root.Left;
            Root.Left = NewRoot.Right;
            NewRoot.Right = Root;

            NewRoot.Parent = Root.Parent;
            Root.Parent = NewRoot;
            Current.Parent = NewRoot;
            if (Root.Left != null)
                Root.Left.Parent = Root;
            if (Root.Right != null)
                Root.Right.Parent = Root;
            if (NewRoot.Left != null)
                NewRoot.Left.Parent = NewRoot;
            if (NewRoot.Right != null)
                NewRoot.Right.Parent = NewRoot;
            if (NewRoot.Parent != null)
            {
                if (NewRoot.Parent.Left == Root)
                    NewRoot.Parent.Left = NewRoot;
                else
                    NewRoot.Parent.Right = NewRoot;
            }
            this.Root = FindRoot(Root);
            return NewRoot;
        }
        // Поиск места удаления узла
        private Node<TKey, TVal> FindPlaceToDelete(Node<TKey, TVal> Current)
        {
            if (Current.Left != null && Current.Right != null)
                Current = Current.Left;
            while (Current.Right != null)
                Current = Current.Right;
            if (Current.Parent.Left == Current)
                Current.Parent.Left = null;
            else
                Current.Parent.Right = null;
            return Current;
        }
        // Случаи удаления 
        private void DCase3_6S(Node<TKey, TVal> Current)
        {
            if (Sibling(Current).Color == Colors.Black &&
                Current.Parent.Left == null &&
                Sibling(Current).Right.Color == Colors.Red)
            {
                DelLeftRotate(Current.Parent);
                Current.Parent.Color = Colors.Black;
                Current.Parent.Parent.Right.Color = Colors.Black;
                return;
            }
            else if (Sibling(Current).Color == Colors.Black &&
                Current.Parent.Right == null &&
                Sibling(Current).Left.Color == Colors.Red)
            {
                DelRightRotate(Current.Parent);
                Current.Parent.Color = Colors.Black;
                Current.Parent.Parent.Left.Color = Colors.Black;
                return;
            }
            DCase1(Current);
        }
        private void DCase3_5(Node<TKey, TVal> Current) //Черный родитель и брат, один племянник красный
        {
            if (Current.Parent.Color == Colors.Black &&
               (Sibling(Current).Left != null && Sibling(Current).Left.Color == Colors.Red) &&
               (Sibling(Current).Right == null || Sibling(Current).Right.Color == Colors.Black) &&
               Current.Parent.Left == null &&
               Sibling(Current).Color == Colors.Black)  //если левый племянник красный
            {
                DelRightRotate(Sibling(Current));
                //перекрашивание узла для сохранения порядка и черной глубины
                Sibling(Current).Color = Colors.Black;
                Sibling(Current).Right.Color = Colors.Red;
                DCase3_6S(Current);
            }
            else if (Current.Parent.Color == Colors.Black &&
               (Sibling(Current).Right != null && Sibling(Current).Right.Color == Colors.Red) &&
               (Sibling(Current).Left == null || Sibling(Current).Left.Color == Colors.Black) &&
               Current.Parent.Right == null &&
               Sibling(Current).Color == Colors.Black) //если правый племянник красный
            {
                DelLeftRotate(Sibling(Current));
                //перекрашивание
                Sibling(Current).Color = Colors.Black;
                Sibling(Current).Left.Color = Colors.Red;
                DCase3_6S(Current);
            }
            else
                DCase3_6S(Current);
        }
        private void DCase3_4S(Node<TKey, TVal> Current)
        {
            if (Current.Parent.Color == Colors.Red &&
                (Sibling(Current).Left == null || Sibling(Current).Left.Color == Colors.Black) &&
                (Sibling(Current).Right == null || Sibling(Current).Right.Color == Colors.Black) &&
                Sibling(Current).Color == Colors.Black)
            {
                Current.Parent.Color = Colors.Black;
                Sibling(Current).Color = Colors.Red;
                return;
            }
            else
                DCase3_5(Current);
        }
        private void DCase3_3(Node<TKey, TVal> Current) //Черный племянник, брат и родитель
        {
            if (Current.Parent.Color == Colors.Black &&
                (Sibling(Current).Left == null || Sibling(Current).Left.Color == Colors.Black) &&
                (Sibling(Current).Right == null || Sibling(Current).Right.Color == Colors.Black) &&
                Sibling(Current).Color == Colors.Black)
            {
                Sibling(Current).Color = Colors.Red;
                DCase3_1S(Current.Parent);
            }
            else
                DCase3_4S(Current);
        }
        private void DCase3_2(Node<TKey, TVal> Current) //Черный родитель, красный брат, черный племянник
        {
            if (Current.Parent.Color == Colors.Black &&
                (Sibling(Current).Left == null || Sibling(Current).Left.Color == Colors.Black) &&
                (Sibling(Current).Left == null || Sibling(Current).Right.Color == Colors.Black) &&
                Sibling(Current).Color == Colors.Red)
            {
                if (Current.Parent.Left == null && Current.Parent.Right != null)
                {
                    DelLeftRotate(Current.Parent);
                }
                else if (Current.Parent.Left != null && Current.Parent.Right == null)
                {
                    DelRightRotate(Current.Parent);
                }
                Current.Parent.Color = Colors.Red;
                Current.Parent.Parent.Color = Colors.Black;
                DCase3_1S(Current);
            }
            else
                DCase3_3(Current);
        }
        private void DCase3_1S(Node<TKey, TVal> Current) //Корень дерева
        {
            if (Current.Parent == null)
            {
                Current.Color = Colors.Black;
                return;
            }
            else
                DCase3_2(Current);
        }
        private void DCase2(Node<TKey, TVal> Current)   //Черный узел с красным потомком
        {
            Node<TKey, TVal> Child = IsOneChild(Current);
            if (Child != null && Child.Color == Colors.Red)
            {
                Current.Value = Child.Value;
                Current.Key = Child.Key;
                DCase1(Child);
            }
            else
                DCase3_1S(FindPlaceToDelete(Current));
        }
        private void DCase1(Node<TKey, TVal> Current)   //Красный лист
        {
            if (IsLeaf(Current) && Current.Color == Colors.Red)
            {
                if (Current.Parent.Left == Current)
                    Current.Parent.Left = null;
                else
                    Current.Parent.Right = null;
            }
            else
                DCase2(Current);
        }
        // Удаление
        public void Delete(TKey key)
        {
            Node<TKey, TVal> Current = GetNodeByKey(Root, key);
            DCase1(Current);
        }
        // Получение значения узла по ключу
        private Node<TKey, TVal> GetNodeByKey(Node<TKey, TVal> Current, TKey key)
        {
            if (Comp(Current.Key, key) == 0)
                return Current;
            else if (Comp(Current.Key, key) == 1)
                return GetNodeByKey(Current.Right, key);
            else if (Comp(Current.Key, key) == -1)
                return GetNodeByKey(Current.Left, key);
            return null;
        }
        //значение
        public TVal this[TKey key]
        {
            get
            {
                return GetNodeByKey(Root, key).Value;
            }
        }
        //Функция сравнения
        public RBTree(Func<TKey, TKey, int> Comp)
        {
            Root = null;
            this.Comp = Comp;
        }
    }
    class Program
    {
       // вспомогательные методы сравнения
        public static int CompSTR(string a, string b)
        {
            if (a.Length < b.Length)
                return 1;
            else if (a.Length > b.Length)
                return -1;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < b[i])
                    return 1;
                else if (a[i] > b[i])
                    return -1;
            }
            return 0;
        }
        public static int CompINT(int a, int b)
        {
            if (a < b)
                return 1;
            else if (a > b)
                return -1;
            else return 0;
        }
        static void Main(string[] args)
        {
            RBTree<int, string> tree = new RBTree<int, string>(CompINT);
            tree.Add(1, "a");
            tree.Add(3, "c");
            tree.Add(4, "c");
            tree.Add(2, "c");
            tree.Delete(4);
            Console.WriteLine(tree[8]);
        }
    }
}
