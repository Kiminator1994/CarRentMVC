using System;
using System.Collections.Generic;

namespace _6_QueryOperators {
    public static class Extensions {
        /****** ZbwMultipleOf ******/

        // TODO: Operator 'ZbwMultipleOf' implementieren / Gibt alle Werte zurück, bei denen "x % factor" == 0 ist
        public static IEnumerable<int> ZbwMultipleOf(this IEnumerable<int> source, int factor) {
            foreach (int item in source)
                if (item % factor == 0)
                    yield return item;
        }

        /****** ZbwWhere ******/

        // TODO: Operator 'ZbwWhere' implementieren / Gibt alle Werte zurück, bei denen ein "Predicate<T>" true liefert
        public static IEnumerable<T> ZbwWhere<T>(this IEnumerable<T> source, Predicate<T> predicate) {
            foreach (T item in source)
                if (predicate(item))
                    yield return item;
        }
    }
}