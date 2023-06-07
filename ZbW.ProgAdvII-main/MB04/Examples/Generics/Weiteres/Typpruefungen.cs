using System;

namespace Generics.Typpruefungen {
    public class Buffer<T> {
    }

    class Examples {
        public void Test() {
            Buffer<int> buf = new Buffer<int>();
            object obj = buf;

            if (obj is Buffer<int>) {
                buf = (Buffer<int>) obj;
            }

            Type t = typeof(Buffer<int>);
            Console.WriteLine(t.Name); // => Buffer[System.Int32]
        }
    }
}