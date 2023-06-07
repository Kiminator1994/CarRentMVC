using System;
using System.Collections.Generic;

namespace Generics.Delegates.Generic {
    //public delegate void Action<T>(T i);

    public class MyClass {
        public static void PrintValues<T>(T i) {
            var s = $"Die Variable {"v"} hat den Wert {i}";
            Console.WriteLine($"Value {i}");

            var l = new List<int> {5, 7, 10, 13, 2, 3};
            var evenList = l.FindAll(delegate(int i1) { return i1 % 2 == 0; });

            l.ForEach(delegate(int i1) {
                Console.WriteLine(i1);
            });
        }
    }

    public class FunctionParameterTest {
        private static void ForAll<T>(T[] array, Action<T> action) {
            Console.WriteLine("ForAll called...");
            if (action == null) {
                return;
            }

            foreach (T t in array) {
                action(t);
            }
        }

        public static void TestPrintValues() {
            MyClass c = new MyClass();
            int[] array = {1, 5, 8, 14, 22};

            ForAll<int>(array, MyClass.PrintValues);

            string[] array2 = { "a", "x", "z" };
            ForAll(array2, MyClass.PrintValues);

        }
    }
}