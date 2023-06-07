using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Iteratoren.Yield {
    class Examples {
        public void TestYield() {
            MyIntList list = new MyIntList();
            foreach (object elem in list) {
                /* ... */
            }
        }
    }

    class MyIntList {
        public IEnumerator<int> GetEnumerator() {
            yield return 1;
            yield return 3;
            yield return 6;
        }
    }

    /// <summary>
    /// Compileroutput
    /// </summary>
    class MyIntListOutput {
        static IEnumerable<int> GetEnumerator() {
            return new __Enumerable1();
        }

        class __Enumerable1 :
            IEnumerable<int>, IEnumerable,
            IEnumerator<int>, IEnumerator {
            int __state;
            int __current;

            public IEnumerator<int> GetEnumerator() {
                __Enumerable1 result = this;
                if (Interlocked.CompareExchange(ref __state, 1, 0) != 0) {
                    result = new __Enumerable1();
                    result.__state = 1;
                }

                return result;
            }

            IEnumerator IEnumerable.GetEnumerator() {
                return (IEnumerator) GetEnumerator();
            }

            public int Current {
                get { return __current; }
            }

            object IEnumerator.Current {
                get { return __current; }
            }

            public bool MoveNext() {
                switch (__state) {
                    case 0:
                        __state = -1;
                        __current = 1;
                        __state = 1;
                        return true;
                    case 1:
                        __state = -1;
                        __current = 3;
                        __state = 2;
                        return true;
                    case 2:
                        __state = -1;
                        __current = 6;
                        __state = 3;
                        return true;
                    case 4:
                        __state = -1;
                        break;
                }

                return false;
            }

            public void Dispose() {
                __state = 2;
            }

            void IEnumerator.Reset() {
                throw new NotSupportedException();
            }
        }
    }
}