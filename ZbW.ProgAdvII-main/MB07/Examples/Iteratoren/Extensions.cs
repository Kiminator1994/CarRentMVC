using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteratoren.Test {
    public static class Extensions {
        public static string DoMagicCalculation(this int a, string prefix) {
            return $"{prefix}{a}";
        }

        public static IEnumerable<T> Range<T>(this List<T> list, int from, int to) {
            for (var i = from; i <= to; i++) {
                yield return list[i];
            }
        }

        public static string ToStringSafe(this object o) {
            if (o == null) {
                return "";
            }

            return o.ToString();
        }
    }
}
