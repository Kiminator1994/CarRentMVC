using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._1_UmbauGenerics {
    public class MyList : IEnumerable {
        protected Node head;
        protected Node current = null;

        protected class Node {
            public Node next;
            private object data;

            public Node(object t) {
                next = null;
                data = t;
            }

            public Node Next {
                get { return next; }
                set { next = value; }
            }

            public object Data {
                get { return data; }
                set { data = value; }
            }
        }

        public MyList() {
            head = null;
        }

        public void Add(object t) {
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