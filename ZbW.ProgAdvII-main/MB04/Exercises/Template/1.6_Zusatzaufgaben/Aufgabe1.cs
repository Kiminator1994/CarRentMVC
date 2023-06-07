using System;

namespace _1._6_Zusatzaufgaben {
    [Serializable]
    class Node {
        public static bool operator >(Node lhs, Node rhs) {
            int res = lhs.Item.CompareTo(rhs.Item);
            return res > 0;
        }

        public static bool operator <(Node lhs, Node rhs) {
            int res = lhs.Item.CompareTo(rhs.Item);
            return res < 0;
        }

        public Node() {
            RightNode = LeftNode = null;
            Item = Int32.MinValue; // erstzen durch Default-Wert von T;
        }

        public Node(int item) {
            RightNode = LeftNode = null;
            Item = item;
        }

        public Node(int item, Node right, Node left) {
            RightNode = right;
            LeftNode = left;
            Item = item;
        }

        public Node LeftNode;
        public Node RightNode;
        public int Item; //int durch T ersetzen
    }

    public class BinaryTreeInt {
        Node m_Root;

        public BinaryTreeInt() {
            m_Root = new Node();
        }

        public void Add(params int[] items) {
            foreach (int t in items) {
                Add(t);
            }
        }

        public void Add(int item) {
            Add(new Node(item), m_Root);
        }

        void Add(Node newNode, Node root) {
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

        void TraceInOrder(Node root) {
            if (root.LeftNode != null)
                TraceInOrder(root.LeftNode);

            Console.WriteLine(root.Item.ToString());

            if (root.RightNode != null)
                TraceInOrder(root.RightNode);
        }

        void TracePostOrder(Node root) {
            Console.WriteLine(root.Item.ToString());

            if (root.LeftNode != null)
                TracePostOrder(root.LeftNode);

            if (root.RightNode != null)
                TracePostOrder(root.RightNode);
        }
    }
}