using System;

namespace Generics.KoKontravarianz.Array {
    class Examples {
        public void TestKovarianzArray() {
            object[] obj = new string[10];
            // Laufzeitfehler
            obj[0] = 5;
        }
    }
}