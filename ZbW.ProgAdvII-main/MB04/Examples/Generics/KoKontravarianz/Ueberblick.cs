using System;

namespace Generics.KoKontravarianz {
    public class Buffer<T> : IBuffer<T> {
    }

    public interface IBuffer<T> {
    }
    //public interface IBuffer<out T> { }

    public class Comparer<T> : IComparer<T> {
        public bool Compare(T x, T y) {
            return false;
        }
    }

    public interface IComparer<T> {
        bool Compare(T x, T y);
    }
    //public interface IComparer<in T> { bool Compare(T x, T y); }

    class Examples {
        public void TestKovarianz() {
            IBuffer<string> b1 = new Buffer<string>();
            // Compilerfehler
            //IBuffer<object> b2 = b1;
        }

        public void TestKontravarianz() {
            IComparer<object> c1 = new Comparer<object>();
            // Compilerfehler
            //IComparer<string> c2 = c1;
            // Führt c1.Compare(object x, object y) aus
            //c2.Compare("a", "b");
        }
    }
}