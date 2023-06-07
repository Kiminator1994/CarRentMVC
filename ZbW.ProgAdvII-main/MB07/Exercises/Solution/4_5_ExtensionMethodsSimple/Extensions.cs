using System;
using System.Text;

namespace _4_5_ExtensionMethodsSimple {
    public static class Extensions {
        // TODO: CamelCase hier als Extension-Method implementieren (Funktionalität für das Casing ist in "ToCamelCaseInternal" enthalten).
        public static string CamelCase(this string s) {
            return ToCamelCaseInternal(s);
        }

        // TODO: ToStringSafe hier als Extension-Method implementieren
        public static string ToStringSafe<T>(this T o) where T : class {
            return o == null ? "null" : o.ToString();
        }

        private static string ToCamelCaseInternal(string s) {
            StringBuilder newString = new StringBuilder();
            bool sawUnderscore = false;

            foreach (char c in s) {
                if ((newString.Length == 0) && char.IsLetter(c)) {
                    newString.Append(char.ToUpper(c));
                } else if (c == '_') {
                    sawUnderscore = true;
                } else if (sawUnderscore) {
                    newString.Append(char.ToUpper(c));
                    sawUnderscore = false;
                } else {
                    newString.Append(char.ToLower(c));
                }
            }

            return newString.ToString();
        }
    }
}