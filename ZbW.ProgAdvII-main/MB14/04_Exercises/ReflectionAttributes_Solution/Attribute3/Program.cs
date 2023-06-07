#define tracing

using System;
using System.Diagnostics;

namespace Attribute3 {
    class Trace {

        [Conditional("tracing")]
        public static void WriteLine(string s) {
            Console.WriteLine(s);
        }

        [Conditional("tracing")]
        public static void WriteLine() {
            Console.WriteLine();
        }

        [Conditional("tracing")]
        public static void Write(string s) {
            Console.Write(s);
        }

    }

    class Stack {
        int[] data = new int[16];
        int top = 0;

        void Dump() {
            for (int i = 0; i < top; i++)
                Trace.Write(data[i] + " ");
            Trace.WriteLine();
        }

        public void Push(int x) {
            Trace.Write("Push(" + x + "): ");
            if (top < 16) {
                data[top] = x; top++;
            } else throw new OverflowException();
            Dump();
        }

        public int Pop() {
            Trace.Write("Pop(): ");
            if (top == 0) throw new UnderflowException();
            top--;
            Dump();
            return data[top];
        }

        public int Size {
            get { return top; }
        }
    }

    class OverflowException : ApplicationException { }
    class UnderflowException : ApplicationException { }

    public class Test {

        public static void Main() {
            Stack stack = new Stack();
            for (int i = 0; i < 5; i++)
                stack.Push(i);
            while (stack.Size > 1) {
                stack.Push(stack.Pop() + stack.Pop());
            }
            Trace.WriteLine("result = " + stack.Pop());
        }
    }
}
