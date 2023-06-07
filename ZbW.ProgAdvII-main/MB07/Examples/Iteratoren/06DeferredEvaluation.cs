using System.Collections.Generic;

namespace Iteratoren.DeferredEvaluation {
    class Examples {
        public void TestDeferredEvaluation() {
            MyIntList list = new MyIntList();

            // Keine Ausführung
            IEnumerator<int> e1 = list.GetEnumerator();
            IEnumerable<int> e21 = list.Range(1, 10);
            IEnumerator<int> e22 = e21.GetEnumerator();

            e1.MoveNext(); // Ausführung
            int i1 = e1.Current;

            e22.MoveNext(); // Ausführung
            int i2 = e21.GetEnumerator().Current;

            // Ausführung
            foreach (int i in e21) {
                /* ... */
            }
        }

        public void TestDeferredEvaluationChained() {
            MyIntList list = new MyIntList();

            // Keine Ausführung
            IEnumerable<int> range = list.Range(0, 10);
            // Keine Ausführung
            IEnumerable<int> rangeEven = list.Even(range);

            // Ausführung
            foreach (int i in rangeEven) {
                /* ... */
            }
        }
    }

    class MyIntList {
        public IEnumerator<int> GetEnumerator() {
            for (int i = 0; i < 10; i++)
                yield return i;
        }

        public IEnumerable<int> Range(int from, int to) {
            for (int i = from; i < to; i++)
                yield return i;
        }

        public IEnumerable<int> Even(IEnumerable<int> e) {
            foreach (int i in e) {
                if (i % 2 == 0)
                    yield return i;
            }
        }
    }
}