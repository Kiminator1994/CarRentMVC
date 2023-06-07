using System;

namespace Linq.ExtensionMethods {
    public static class ExtensionMethods {

        public static string ToStringSafe(this object obj) {
            return obj == null ? string.Empty : obj.ToString();
        }

        public static void Test() {
            int myInt = 0;
            object myObj = new object();

            // Objects not null
            myInt.ToString();
            myInt.ToStringSafe();
            myObj.ToString();
            myObj.ToStringSafe();

            // Object is null
            myObj = null;
            myObj.ToString(); // Error
            myObj.ToStringSafe(); // Works
        }

        public static void CompareInIntermediateLanguage() {
            1.ToStringSafe();
            // Compiler-Output
            ExtensionMethods.ToStringSafe(1);
        }
    }
}