using System;

namespace Generics.Weiteres.BehindTheScenes {
    public class Buffer<T> {
    }

    public class Node {
    }

    class Examples {
        public void TestValueType() {
            Buffer<int> a = new Buffer<int>();
            Buffer<int> b = new Buffer<int>();
            Buffer<float> c = new Buffer<float>();
        }

        public void TestReferenceType() {
            Buffer<string> a = new Buffer<string>();
            Buffer<string> b = new Buffer<string>();
            Buffer<Node> c = new Buffer<Node>();
        }
    }
}