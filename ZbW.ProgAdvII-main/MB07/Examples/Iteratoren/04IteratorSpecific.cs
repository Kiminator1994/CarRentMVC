using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Iteratoren.Specific {
    class Examples {
        public void TestStandard() {
            MyIntList list = new MyIntList();
            foreach (int elem in list) {
                Console.WriteLine(elem);
            }
        }

        public void TestEnumerator() {
            MyIntList list = new MyIntList();
            foreach (int elem in list.TestIteratorMethod()) {
                Console.WriteLine(elem);
            }

        }
        public void TestSpecificMethod() {
            MyIntList list = new MyIntList();
            foreach (int elem in list.Range(2, 7)) {
                Console.WriteLine(elem);
            }
        }

        public void TestSpecificProperty() {
            MyIntList list = new MyIntList();
            foreach (int elem in list.Reverse) {
                Console.WriteLine(elem);
            }
        }
    }

    public class TestEnumerator {
        // beliebige Klasse mit einer Methode, die GetEnumerator() heisst.
        // Diese Methode wiederum muss in Objekt zurückgeben,
        // welches Current und MoveNext() hat.
        public IEnumerator<int> GetEnumerator() {
            yield return 1;
            yield return 3;
            yield return 6;
        }

    }
    class MyIntList {
        private int[] data = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        // Standard Iterator
        public IEnumerator<int> GetEnumerator() {
            for (int i = 0; i < data.Length; i++)
                yield return data[i];
        }

        public TestEnumerator TestIteratorMethod() {
            // beliebiges Objekt, welches GetEnumerator() als Methode hat.
            // Diese Methode wiederum muss in Objekt zurückgeben,
            // welches Current und MoveNext() hat.
            return new TestEnumerator();
        }
        // Spezifische Iterator-Methode
        public IEnumerable<int> Range(int from, int to) {
            for (int i = from; i < to; i++)
                yield return data[i];
        }

        // Spezifisches Iterator-Property
        public IEnumerable<int> Reverse {
            get {
                for (int i = data.Length - 1; i >= 0; i--)
                    yield return data[i];
            }
        }
    }
}