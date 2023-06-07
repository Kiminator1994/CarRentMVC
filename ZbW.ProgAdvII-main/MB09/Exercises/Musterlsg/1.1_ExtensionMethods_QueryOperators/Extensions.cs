using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._1_ExtensionMethods_QueryOperators {
    /// <summary>
    /// Dokumentation der offiziellen LINQ Extension Methods:
    /// http://msdn.microsoft.com/en-us/library/system.linq.enumerable_methods.aspx
    /// 
    /// Nutzen Sie diese Dokumentation um Ihre Extension Methods zu implementieren.
    /// Sie finden dort auch die Beschreibung, was die Methode effektiv für einen Effekt hat.
    /// </summary>
    public static class Extensions {
        // TODO: ZbwForEach
        public static void ZbwForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action) {
            foreach (TSource item in source)
                action(item);
        }

        // TODO: ZbwWhere
        public static IEnumerable<TSource> ZbwWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) {
            foreach (TSource item in source)
                if (predicate(item))
                    yield return item;
        }

        // TODO: ZbwOfType
        public static IEnumerable<TResult> ZbwOfType<TResult>(this IEnumerable source) {
            foreach (object item in source)
                if (item is TResult)
                    yield return (TResult) item;
        }

        // TODO: ZbwToList
        public static List<TSource> ZbwToList<TSource>(this IEnumerable<TSource> source) {
            return new List<TSource>(source);
        }

        // TODO: ZbwSum
        public static int ZbwSum<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector) {
            int sum = 0;
            foreach (TSource t in source)
                sum += selector(t);

            return sum;
        }
    }
}