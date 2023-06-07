using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Policy;

namespace Iteratoren {
    class ForeachLoop {
        public void TestBasic() {
            var list = new List<int> {1, 2, 3, 4, 5, 6};

            foreach (int i in list) {
                if (i == 3) continue;
                if (i == 5) break;
                Console.WriteLine(i);
            }









            // Compiler Output
            IEnumerator enumerator = list.GetEnumerator();
            try {
                while (enumerator.MoveNext()) {
                    int i = (int) enumerator.Current;

                    if (i == 3) continue;
                    if (i == 5) break;
                    Console.WriteLine(i);
                    ;
                }
            } finally {
                IDisposable disposable = enumerator as System.IDisposable;
                if (disposable != null) disposable.Dispose();
            }
        }














        public class Point {
            public int X;
            public int Y;
            public int Z;

            public IEnumerator<int> GetEnumerator() {
                //yield return this.X;
                //yield return this.Y;
                //if (DateTime.Today.DayOfWeek == DayOfWeek.Tuesday) {
                //    yield break;
                //}

                //yield return this.Z;
                //if (DateTime.Today.DayOfWeek == DayOfWeek.Friday) {
                //    yield return this.Z;
                //}
                return new MyEnumerator(this.X, this.Y, this.Z);
            }
        }

        public class MyEnumerator : IEnumerator<int> {
            private int x, y, z;
            private int currentIdx = -1;

            public MyEnumerator(int x, int y, int z) {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public bool MoveNext() {
                this.currentIdx++;
                return currentIdx <= 2;
            }

            public void Dispose() {
                //throw new NotImplementedException();
            }

            public void Reset() {
                throw new NotImplementedException();
            }

            public int Current {
                get {
                    switch (this.currentIdx) {
                        case 0:
                            return this.x;
                        case 1:
                            return this.y;
                        default:
                            return this.z;
                    }
                    //if (this.currentIdx == 0) {
                    //    return this.x;
                    //} else if (this.currentIdx == 1) {
                    //    return y;
                    //}

                    //return z;
                }
            }

            object IEnumerator.Current => throw new NotImplementedException();
        }

        public void TestOwn() {
            var p = new Point {X = 100, Y = 200, Z = 50};
            foreach (var item in p) {
                Console.WriteLine(item);
            }
        }
    }
}