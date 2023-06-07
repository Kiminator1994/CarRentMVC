using System;
using System.Collections.Generic;

namespace _1._1_ExtensionMethods_QueryOperators {
    class Program {
        private static string[] Cities {
            get { return new[] {"Bern", "Basel", "Zürich", "St. Gallen", "Genf"}; }
        }

        static void Main(string[] args) {
            Console.WriteLine("---------- \r\nZbwForEach");
            TestForEach();
            Console.WriteLine("---------- \r\nZbwWhere");
            TestWhere();
            Console.WriteLine("---------- \r\nZbwOfType");
            TestOfType();
            Console.WriteLine("---------- \r\nZbwToList");
            TestToList();
            Console.WriteLine("---------- \r\nZbwSum");
            TestSum();

            Console.ReadKey();
        }

        public static void TestForEach() {
            // TODO: Bringe folgenden Code zum laufen            
            Console.WriteLine("ZbwForEach / Cities");
            Cities.ZbwForEach(s => Console.WriteLine(s));
            Console.WriteLine("ZbwForEach / Cities (Upper-Case)");
            Cities.ZbwForEach(s => Console.WriteLine(s.ToUpper()));
        }

        public static void TestWhere() {
            // TODO: Bringe folgenden Code zum laufen
            IEnumerable<string> q1 = Extensions.ZbwWhere(Cities, s => s.Length < 5);
            IEnumerable<string> q2 = Cities.ZbwWhere(s => s.Length < 5);

            q2.ZbwForEach(s => Console.WriteLine(s));

            Cities.ZbwWhere(s => s.Length < 5)
                .ZbwForEach(s => Console.WriteLine(s));
        }

        public static void TestOfType() {
            object[] objs = {1, "St. Gallen", true, "Zürich", 7.9, "Bern"};

            // TODO: Bringe folgenden Code zum laufen
            IEnumerable<string> q1 = objs.ZbwOfType<string>();
            q1.ZbwForEach(s => Console.WriteLine(s));
        }

        public static void TestToList() {
            // TODO: Bringe folgenden Code zum laufen
            List<string> res = Cities.ZbwToList();
        }

        public static void TestSum() {
            // TODO: Bringe folgenden Code zum laufen
            int totalLength = Cities.ZbwSum(c => c.Length);
        }
    }
}