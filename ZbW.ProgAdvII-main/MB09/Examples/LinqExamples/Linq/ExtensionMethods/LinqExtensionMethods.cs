using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.ExtensionMethods {
    public static class LinqExtensionMethods {
        // Aus Musterlösung der Übung "Iteratoren / Query Operators"
        //public static IEnumerable<T> ZbWWhere<T>(
        //    IEnumerable<T> source,
        //    Predicate<T> predicate)
        //{
        //    foreach (T item in source)
        //    {
        //        if (predicate(item))
        //            yield return item;
        //    }
        //}
        public static IEnumerable<T> ZbWWhere<T>(
            this IEnumerable<T> source,
            Predicate<T> predicate) {
            foreach (T item in source) {
                if (predicate(item))
                    yield return item;
            }
        }

        public static void Test() {
            int[] numbers = {1, 4, 2, 9, 13, 8, 9, 0, -6, 12};
            IEnumerable<int> gt5 = ZbWWhere(numbers, delegate(int i) { return i >= 5; });
            IEnumerable<int> gt5_multiple2 = ZbWWhere(gt5, delegate(int i) { return i % 2 == 0; });

            IEnumerable<int> gt5_multiple2a = numbers
                .ZbWWhere(i => i >= 5)
                .ZbWWhere(i => i % 2 == 0);

            IEnumerable<int> gt5_multiple2b = numbers
                .Where(i => i >= 5)
                .Where(i => i % 2 == 0);
        }

    }
}