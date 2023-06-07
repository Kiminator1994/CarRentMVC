using System;
using System.Collections.Generic;

namespace _1._4_TypeConstraints {
    // TODO: Versuchen Sie, folgende Methode nur mit Type Constraints kompilierfähig zu machen.
    //       Die Methode soll sämtliche Elemente von "source" in eine neue Liste abfüllen.
    static class MyHelpers {
        static TDest CopyTo<TSource, TDest, TElement>(TSource source)
            where TSource : IEnumerable<TElement>
            where TDest : IList<TElement>, new() {
            TDest dest = new TDest();
            foreach (TElement element in source) {
                dest.Add(element);
            }

            return dest;
        }
    }
}