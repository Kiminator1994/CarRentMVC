using System;

namespace Generics.Vererbung.Ueberschreiben {
    class Buffer<T> {
        public virtual void Put(T x) {
        }
    }

    class MyIntBuffer : Buffer<int> {
        public override void Put(int x) {
        }
    }

    class MyBuffer<T> : Buffer<T> {
        public override void Put(T x) {
        }
    }
}