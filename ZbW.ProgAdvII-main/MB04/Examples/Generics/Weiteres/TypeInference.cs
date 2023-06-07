using System;

namespace Generics.Weiteres.TypeInference {
    class Examples {
        public void Test() {
            Print<int>(12);
            Print(12);

            int i1 = Get<int>();
            //int i2 = Get(); // Compilerfehler
        }

        public void Print<T>(T t) {
            /* ... */
        }

        public T Get<T>() {
            /* ... */
            return default(T);
        }
    }
}