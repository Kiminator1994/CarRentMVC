using System;
using System.Collections.Generic;

namespace _1._6_Zusatzaufgaben {
    public static class Operators {
        #region Aufgabe 2 - ForAll

        public static void ForAll<T>(IEnumerable<T> elements, Predicate<T> p, Action<T> a) {
            foreach (T element in elements) {
                if (p(element)) {
                    a(element);
                }
            }
        }

        public static void TestForAll() {
            ForAll(
                new int[] {1, 2, 3, 4},
                delegate(int i) { return i > 2; },
                delegate(int i) { Console.WriteLine(i); }
            );
        }

        #endregion

        #region Aufgabe 3 - Comparison

        public static int DefaultCompare<T>(T p1, T p2) where T : IComparable<T> {
            return p1.CompareTo(p2);
        }

        public static void TestComparer() {
            Comparison<int> comparer = DefaultCompare;
            Console.WriteLine(comparer(7, 7));
        }

        #endregion

        #region Aufgabe 4 - Combiner

        public delegate TOut MyConverter<TIn1, TIn2, TOut>(TIn1 elem1, TIn2 elem2);

        // Implementation mit eigenem Delegate "MyConverter"
        public static TOut[] CombineAll<TIn1, TIn2, TOut>(
            TIn1[] array1,
            TIn2[] array2,
            MyConverter<TIn1, TIn2, TOut> converter) {
            TOut[] result = new TOut[array1.Length];
            for (int i = 0; i < array1.Length; i++) {
                result[i] = converter(array1[i], array2[i]);
            }

            return result;
        }

        // Implementation mit .NET Standard Delegate "Func"
        //public static TOut[] CombineAll<TIn1, TIn2, TOut>(
        //    TIn1[] array1,
        //    TIn2[] array2,
        //    Func<TIn1, TIn2, TOut> converter)
        //{
        //    TOut[] result = new TOut[array1.Length];
        //    for (int i = 0; i < array1.Length; i++)
        //    {
        //        result[i] = converter(array1[i], array2[i]);
        //    }
        //    return result;
        //}

        public static void TestCombineAll() {
            int[] res = CombineAll<int, int, int>(
                new int[] {2, 3, 4},
                new int[] {1, 2, 5},
                delegate(int a, int b) { return a * b; }
            );
            foreach (int i in res) {
                Console.WriteLine(i);
            }

            string[] res1 = CombineAll<int, string, string>(
                new int[] {2, 3, 4},
                new string[] {"abc", "ef", "uv"},
                delegate(int a, string b) { return b + a.ToString(); }
            );
            foreach (string s in res1) {
                Console.WriteLine(s);
            }
        }

        #endregion

        #region Aufgabe 5 - Bubble Sort

        public static void BubbleSort<T>(int count, Func<int, T> getter, Action<int, T> setter, Comparison<T> cmp) {
            for (int io = 0; io < count - 1; io++) {
                for (int ii = 0; ii < count - io - 1; ii++) {
                    T e1 = getter(ii);
                    T e2 = getter(ii + 1);

                    if (cmp(e1, e2) > 0) {
                        setter(ii, e2);
                        setter(ii + 1, e1);
                    }
                }
            }
        }

        public static void TestSort() {
            int[] array = new int[] {1, 23, 2, -10, 10, 1000, 23, 100000, -12};
            BubbleSort(
                array.Length,
                delegate(int i) { return array[i]; },
                delegate(int i, int e) { array[i] = e; },
                DefaultCompare<int>
            );
            foreach (int e in array) {
                Console.WriteLine(e);
            }
        }

        #endregion

        #region Aufgabe 6 - FoldR

        public delegate T FoldHandler<T>(T p1, T p2);

        public static T FoldR<T>(T start, IEnumerable<T> elements, Func<T, T, T> foldHandler) {
            T akt = start;
            foreach (T element in elements) {
                akt = foldHandler(akt, element);
            }

            return akt;
        }

        //Minimumbestimmung mit Fold
        public static T Smallest<T>(T maxElement, IEnumerable<T> elements, Comparison<T> comparison) {
            return FoldR(maxElement, elements,
                delegate(T p1, T p2) { return comparison(p1, p2) <= 0 ? p1 : p2; });
        }

        //Variante mit IComparable
        public static T Smallest<T>(T maxElement, IEnumerable<T> elements) where T : IComparable<T> {
            return Smallest<T>(maxElement, elements, DefaultCompare);
        }

        public static void TestFold() {
            int[] array = new int[] {1, 23, 2, -10, 10, -1000, 23};
            Console.WriteLine(
                Smallest(
                    int.MaxValue,
                    array,
                    delegate(int v1, int v2) { return ((IComparable) v1).CompareTo(v2); }
                )
            );
            Console.WriteLine(
                Smallest(
                    int.MaxValue,
                    array
                )
            );
        }

        #endregion

        public static void TestAufgabe23456() {
            Console.WriteLine("TestForAll");
            TestForAll();

            Console.WriteLine("TestComparer");
            TestComparer();

            Console.WriteLine("TestCombineAll");
            TestCombineAll();

            Console.WriteLine("TestSort");
            TestSort();

            Console.WriteLine("TestFold");
            TestFold();
        }
    }
}