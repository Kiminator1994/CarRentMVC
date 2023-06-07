using System;
using System.Collections.Generic;

namespace _1_Fibonacci {
    public class Math {
        // TODO: Implementiere Methode Fibonacci
        public static IEnumerable<int> Fibonacci(int n) {
            int prev = -1;
            int next = 1;
            for (int i = 0; i < n; i++) {
                int sum = prev + next;
                prev = next;
                next = sum;
                yield return sum;
            }
        }
    }

    class Program {
        static void Main(string[] args) {
            foreach (int i in Math.Fibonacci(8)) {
                Console.WriteLine("{0} ", i);
            }

            Console.ReadKey();
        }
    }
}