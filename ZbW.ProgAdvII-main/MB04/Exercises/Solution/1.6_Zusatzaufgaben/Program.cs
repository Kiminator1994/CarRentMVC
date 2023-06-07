using System;

namespace _1._6_Zusatzaufgaben {
    class Program {
        static void Main(string[] args) {
            TestAufgabe1();
            TestAufgabe2();
            TestAufgabe3();
            TestAufgabe4();
            TestAufgabe5();
            TestAufgabe6();

            Console.ReadKey();
        }

        private static void TestAufgabe1() {
            Console.WriteLine("TestBinaryTree");
            BinaryTree<int> mTree = new BinaryTree<int>();
            mTree.Add(4, 6, 2, 7, 5, 3, 1);

            Console.WriteLine("Trace");
            mTree.TraceTree();
        }

        private static void TestAufgabe2() {
            Console.WriteLine("TestForAll");
            Operators.TestForAll();
        }

        private static void TestAufgabe3() {
            Console.WriteLine("TestComparer");
            Operators.TestComparer();
        }

        private static void TestAufgabe4() {
            Console.WriteLine("TestCombineAll");
            Operators.TestCombineAll();
        }

        private static void TestAufgabe5() {
            Console.WriteLine("TestSort");
            Operators.TestSort();
        }

        private static void TestAufgabe6() {
            Console.WriteLine("TestFold");
            Operators.TestFold();
        }
    }
}