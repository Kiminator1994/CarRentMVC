using System;
using System.Collections;
using System.Collections.Generic;

namespace Iteratoren.Iterator {
    class Examples {
        public void TestNonGeneric() {
            MyList list = new MyList();
            foreach (object elem in list) {
                /* ... */
            }
        }

        public void TestGeneric() {
            MyIntList list = new MyIntList();
            foreach (int elem in list) {
                /* ... */
            }
        }
    }

    class MyList : IEnumerable{
        private int[] data = new[] {1, 7, 4, 10, 2};

        public IEnumerator GetEnumerator() {
            return new MyEnumerator(data);
        }

        class MyEnumerator : IEnumerator{
            private readonly int[] data;
            private int idx = -1;

            public MyEnumerator(int[] data) {
                this.data = data;
            }

            public object Current {
                get {
                    return this.data[this.idx];
                }
            }
            public bool MoveNext() {
                this.idx++;
                return this.data.Length >= (this.idx + 1);
            }

            public void Reset() {
                this.idx = -1;
            }
        }
    }

    class MyIntList : IEnumerable<int> {
        private int[] data = new[] {1, 7, 4, 10, 2};

        public IEnumerator<int> GetEnumerator() {
            return new MyIntEnumerator(data);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        class MyIntEnumerator : IEnumerator<int> {
            private readonly int[] data;
            private int idx = -1;

            public MyIntEnumerator(int[] data) {
                this.data = data;
            }

            public int Current {
                get {
                    return this.data[this.idx];
                }
            }

            object IEnumerator.Current {
                get { return this.Current; }
            }

            public bool MoveNext() {
                this.idx++;
                return this.data.Length >= (this.idx + 1);
            }

            public void Reset() {
                this.idx = -1;
            }


            public void Dispose() {
                /* ... */
            }
        }
    }
}