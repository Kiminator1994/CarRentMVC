using System;

namespace _1._6_Zusatzaufgaben {
    [Serializable]
    class Node<T> where T : IComparable<T> {
        public static bool operator >(Node<T> lhs, Node<T> rhs) {
            int res = lhs.Item.CompareTo(rhs.Item);
            return res > 0;
        }

        public static bool operator <(Node<T> lhs, Node<T> rhs) {
            int res = lhs.Item.CompareTo(rhs.Item);
            return res < 0;
        }

        public Node() {
            RightNode = LeftNode = null;
            Item = default(T);
        }

        public Node(T item) {
            RightNode = LeftNode = null;
            Item = item;
        }

        public Node(T item, Node<T> right, Node<T> left) {
            RightNode = right;
            LeftNode = left;
            Item = item;
        }

        public Node<T> LeftNode;
        public Node<T> RightNode;
        public T Item;
    }

    public class BinaryTree<T> where T : IComparable<T> {
        Node<T> m_Root;

        public BinaryTree() {
            m_Root = new Node<T>();
        }

        public void Add(params T[] items) {
            foreach (T t in items) {
                Add(t);
            }
        }

        public void Add(T item) {
            Add(new Node<T>(item), m_Root);
        }

        void Add(Node<T> newNode, Node<T> root) {
            if (newNode > root) {
                if (root.RightNode == null) {
                    root.RightNode = newNode;
                    return;
                }

                Add(newNode, root.RightNode);
            }

            if (newNode < root) {
                if (root.LeftNode == null) {
                    root.LeftNode = newNode;
                    return;
                }

                Add(newNode, root.LeftNode);
            }
        }

        public void TraceTree() //Test
        {
            Console.WriteLine("Trace In-Order");
            TraceInOrder(m_Root.RightNode);
            Console.WriteLine("Trace Post-Order");
            TracePostOrder(m_Root.RightNode);
        }

        void TraceInOrder(Node<T> root) {
            if (root.LeftNode != null)
                TraceInOrder(root.LeftNode);

            Console.WriteLine(root.Item.ToString());

            if (root.RightNode != null)
                TraceInOrder(root.RightNode);
        }

        void TracePostOrder(Node<T> root) {
            Console.WriteLine(root.Item.ToString());

            if (root.LeftNode != null)
                TracePostOrder(root.LeftNode);

            if (root.RightNode != null)
                TracePostOrder(root.RightNode);
        }
    }
}