using System;

namespace Linq.LambdaExpressions.TypeInference.cs {
    public class Examples {
        public void TestParameters() {
            Func<bool> p01;
            Func<int, bool> p02;
            Func<int, int, bool> p03;
            Func<int, int, int, bool> p04;

            p01 = () => true; // 0 Parameters
            p02 = a => true; // 1 Parameter
            p02 = (a) => true; // 1 Parameter
            p03 = (a, b) => true; // 2 Parameters
            p04 = (a, b, c) => true; // 3 Parameters
            // ...

            p01 = () => true; // 0 Parameters
            //p02 = int a => true;                 // Compilerfehler
            p02 = (int a) => true; // 1 Parameter
            p03 = (int a, int b) => true; // 2 Parameters
            p04 = (int a, int b, int c) => true; // 3 Parameters
            // ...
        }

        public void TestExpressionLambda() {
            Func<int, int> e1;
            e1 = a => a * a;
            e1 = a => Square(a);

            Func<int, int, int> e2;
            e2 = (a, b) => a * b;
            e2 = (a, b) => Multiply(a, b);

            Action<int> e3;
            e3 = a => Console.WriteLine(a);
            e3 = a => a++;
        }

        public void TestStatementLambda() {
            Func<int, int> e1;
            e1 = a => { return a * a; };
            e1 = a => { return Square(a); };
            e1 = a => {
                int sum = 0;
                for (int i = 1; i <= a; i++)
                    sum += i;
                return sum;
            };
        }

        public void TestOuterVariables() {
            int x = 0;
            Action a = () => x = 1;

            Console.WriteLine(x); // Output: 0

            a();

            Console.WriteLine(x); // Output: 1
        }


        private int Square(int a) {
            return a * a;
        }

        private int Multiply(int a, int b) {
            return a * b;
        }


        public void TestRefOut() {
            int val = 0;

            Example1(val);
            Console.WriteLine(val); // Still 0.

            Example2(ref val);
            Console.WriteLine(val); // Now 2.

            Example3(out val);
            Console.WriteLine(val); // Now 3.

            //int val2;
            //Example2(ref val2);   // Kompilerfehler

            //int val3;
            //Example3(out val3);
        }

        static void Example1(int value) {
            value = 1;
        }

        static void Example2(ref int value) {
            value = 2; // ist nicht zwingend
        }

        static void Example3(out int value) {
            value = 3; // muss zwingend zugewiesen werden
        }
    }
}