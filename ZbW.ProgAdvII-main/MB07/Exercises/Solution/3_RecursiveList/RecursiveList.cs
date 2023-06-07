using System;
using System.Collections.Generic;

namespace _3_RecursiveList {
    public class RecursiveList<T> {
        public class Node {
            public Node Next { get; set; }
            public T Value { get; private set; }

            public Node(T val) {
                Value = val;
            }
        }

        private Node root;
        private Node tail;

        public RecursiveList() {
            root = new Node(default(T));
            tail = root;
        }

        public void Append(T val) {
            tail.Next = new Node(val);
            tail = tail.Next;
        }

        private IEnumerable<T> TraverseInternal(Node curr) {
            if (curr != null) {
                yield return curr.Value;
                foreach (T t in TraverseInternal(curr.Next)) {
                    yield return t;
                }
            }
        }

        private IEnumerable<T> InverseInternal(Node curr) {
            if (curr != null) {
                foreach (T t in InverseInternal(curr.Next)) {
                    yield return t;
                }

                yield return curr.Value;
            }
        }


        public IEnumerable<T> Traverse {
            get { return TraverseInternal(root.Next); }
        }

        public IEnumerable<T> Inverse {
            get { return InverseInternal(root.Next); }
        }

        public void ForEach(Action<T> action) {
            if (action == null)
                return;

            foreach (T elem in Traverse) {
                action(elem);
            }
        }
    }
}