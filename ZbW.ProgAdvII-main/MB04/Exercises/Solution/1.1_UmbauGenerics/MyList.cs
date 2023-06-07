using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._1_UmbauGenerics {
    public class MyList<T>  {
        protected Node head;
        protected Node current = null;

        protected class Node {
            public Node next;
            private T data;

            public Node(T t) {
                next = null;
                data = t;
            }

            public Node Next {
                get { return next; }
                set { next = value; }
            }

            public T Data {
                get { return data; }
                set { data = value; }
            }
        }

        public MyList() {
            head = null;
        }

        public void Add(T t) {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }

        public IEnumerator GetEnumerator() {
            Node curr = head;
            while (curr != null) {
                yield return curr.Data;
                curr = curr.Next;
            }
        }


    }
}