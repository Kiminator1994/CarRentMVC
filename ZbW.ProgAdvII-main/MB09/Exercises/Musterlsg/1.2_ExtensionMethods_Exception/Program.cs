using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace _1._2_ExtensionMethods_Exceptions {
    class Program {
        private static Exception TestException {
            get {
                return
                    new ApplicationException(
                        "Top",
                        new NotSupportedException(
                            "Middle",
                            new NotImplementedException("Bottom")
                        )
                    );
            }
        }

        static void Main(string[] args) {
            Console.WriteLine("---------- \r\nTestGetInnerstException");
            TestGetInnerstException();
            Console.WriteLine("---------- \r\nTestForEachException");
            TestForEachException();

            Console.ReadKey();
        }

        private static void TestGetInnerstException() {
            // TODO: Bringe folgenden Code zum laufen            
            Exception e = TestException.GetInnerstException();
            Console.WriteLine(e.Message);
        }

        private static void TestForEachException() {
            // TODO: Bringe folgenden Code zum laufen            
            TestException.ForEachException(e => Console.WriteLine(e.Message));
        }
    }
}