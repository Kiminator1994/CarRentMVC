using System;
using System.Collections;
using System.Collections.Generic;

namespace Iteratoren.DeferredEvaluationLinq {
    static class Extensions {
        public static IEnumerable<T> ZbwWhere<T>(this IEnumerable<T> source, Predicate<T> predicate) {
            foreach (T item in source) {
                if (predicate(item))
                    yield return item;
            }
        }

        public static IEnumerable<T> ZbwOfType<T>(this IEnumerable source) {
            foreach (object item in source) {
                if (item is T)
                    yield return (T) item;
            }
        }

        public static void Test() {
            int[] list1 = {4, 7, 10, 8, 11,2};

            var r = list1.ZbwWhere(delegate(int k) {
                return k % 2 == 0;
            });

            foreach (var i in r) {
                Console.WriteLine(i);
            }






            object[] list = { 4, 3.5, "abc", 3, 4.5, 6 };

            IEnumerable<int> res = list
                .ZbwOfType<int>()
                .ZbwWhere(delegate(int k) { return k % 2 == 0; });

            foreach (int i in res) {
                Console.WriteLine(i);
            }

            res = ZbwWhere(
                ZbwOfType<int>(list),
                delegate(int k) { return k >= 8; });

            foreach (int i in res) {
                Console.WriteLine(i);
            }
        }
    }
}