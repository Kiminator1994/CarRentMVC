using System;

namespace Linq.LambdaExpressions {
    public delegate void MyDel(string sender);

    public class Examples {
        /// <summary>
        /// Shows different ways to set or execute a delegate
        /// </summary>
        public void Test() {
            MyDel x1;

            // Standard (Instanz-Methode) C# 1.0 / 2.0

            x1 = new MyDel(this.Print);
            x1 = this.Print;

            // Standard (Statische Meth.) C# 1.0 / 2.0
            x1 = new MyDel(Examples.PrintStatic);
            x1 = Examples.PrintStatic;

            // Anonymous Delegate
            x1 = delegate(string sender) { Console.WriteLine(sender); };

            // Anonymous Delegate (Kurzform)
            x1 = delegate { Console.WriteLine("Hello"); };

            // Lambda Expression (LINQ / später)
            x1 = sender => Console.WriteLine(sender);

            // Statement Lambda Expr. (LINQ / später)
            x1 = sender => { Console.WriteLine(sender); };

        }

        public void Print(string sender) {
            Console.WriteLine(sender);

        }

        public static void PrintStatic(string sender) {
            Console.WriteLine(sender);

        }
    }
}
