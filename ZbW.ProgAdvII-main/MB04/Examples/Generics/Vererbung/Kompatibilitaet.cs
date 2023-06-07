using System;

namespace Generics.Vererbung.Kompatiblitaet.Normal {
    class MyList {
        /* ... */
    }

    class MyList<T> : MyList {
        /* ... */
    }

    class MyDict<TKey, TValue> : MyList {
        /* ... */
    }

    class Examples {
        public void Test() {
            MyList l1 = new MyList<int>();
            MyList l2 = new MyDict<int, float>();

            object o1 = new MyList<int>();
            object o2 = new MyDict<int, float>();
        }
    }
}

namespace Generics.Vererbung.Kompatiblitaet.Generic {
    class MyList<T> {
        /* ... */
    }

    class MyList2<T> : MyList<T> {
        /* ... */
    }

    class MyDict<TKey, TValue> : MyList<TKey> {
        /* ... */
    }

    class Examples {
        public void Test() {
            MyList<int> l1 = new MyList2<int>();
            MyList<int> l2 = new MyDict<int, float>();

            var l11 = new MyList<int>();
            var l22 = new MyList<byte>();

            if (l11.GetType() == l22.GetType()) {

            }
            // Compilerfehler
            //MyList<int> l3 = new MyList<float>();
        }
    }
}