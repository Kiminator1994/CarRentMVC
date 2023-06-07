using System;
using System.Collections.Generic;

namespace _1._6_Zusatzaufgaben {
    public static class Operators {
        #region Aufgabe 2 - ForAll

        //public static void ForAll...

        public static void TestForAll() {
            //ForAll(
            //    new int[] { 1, 2, 3, 4 },
            //    delegate(int i) { return i > 2; },
            //    delegate(int i) { Console.WriteLine(i); }
            //);
        }

        #endregion

        #region Aufgabe 3 - Comparison

        //public static int DefaultCompare...

        public static void TestComparer() {
            //Comparison<int> comparer = DefaultCompare;
            //Console.WriteLine(comparer(7, 7));
        }

        #endregion

        #region Aufgabe 4 - Combiner

        // public delegate TOut MyConverter...

        // Implementation mit eigenem Delegate "MyConverter"
        //public static TOut[] CombineAll...

        public static void TestCombineAll() {
            //int[] res = CombineAll<int, int, int>(
            //    new int[] { 2, 3, 4 },
            //    new int[] { 1, 2, 5 },
            //    delegate(int a, int b) { return a * b; }
            //);
            //foreach (int i in res)
            //{
            //    Console.WriteLine(i);
            //}

            //string[] res1 = CombineAll<int, string, string>(
            //    new int[] { 2, 3, 4 },
            //    new string[] { "abc", "ef", "uv" },
            //    delegate(int a, string b) { return b + a.ToString(); }
            //);
            //foreach (string s in res1)
            //{
            //    Console.WriteLine(s);
            //}
        }

        #endregion

        #region Aufgabe 5 - Bubble Sort

        //public static void BubbleSort

        public static void TestSort() {
            //int[] array = new int[] { 1, 23, 2, -10, 10, 1000, 23, 100000, -12 };
            //BubbleSort(array.Length,
            //       delegate(int i) { return array[i]; },
            //        delegate(int i, int e) { array[i] = e; },
            //        DefaultCompare<int>);
            //foreach (int e in array)
            //{
            //    Console.WriteLine(e);
            //}
        }

        #endregion

        #region Aufgabe 6 - FoldR

        public delegate T FoldHandler<T>(T p1, T p2);

        public static T FoldR<T>(T start, IEnumerable<T> elements, FoldHandler<T> foldHandler) {
            T akt = start;
            foreach (T element in elements) {
                akt = foldHandler(akt, element);
            }

            return akt;
        }

        //Minimumbestimmung mit Fold
        //public static T Smallest...

        //Variante mit IComparable
        //public static T Smallest...

        public static void TestFold() {
            //int[] array = new int[] { 1, 23, 2, -10, 10, -1000, 23 };
            //Console.WriteLine(
            //    Smallest(
            //        int.MaxValue,
            //        array,
            //        delegate(int v1, int v2) { return ((IComparable)v1).CompareTo(v2); }
            //    )
            //);
            //Console.WriteLine(
            //    Smallest(
            //        int.MaxValue,
            //        array
            //    )
            //);
        }

        #endregion
    }
}