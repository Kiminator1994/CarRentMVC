using System;

namespace _4_5_ExtensionMethodsSimple {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("---------- \r\nCamelCase");
            TestCamelCase();
            Console.WriteLine("---------- \r\nToStringSafe");
            TestToStringSafe();

            Console.ReadKey();
        }

        private static void TestCamelCase() {
            string[] identifiers = new string[] {
                "do_something",
                "find_all_objects",
                "get_last_dict_entry"
            };

            // TODO: Bringe folgenden Code zum laufen
            foreach (string s in identifiers)
                Console.WriteLine("{0} becomes: {1}", s, Extensions.CamelCase(s));
            foreach (string s in identifiers)
                Console.WriteLine("{0} becomes: {1}", s, s.CamelCase());
        }

        private static void TestToStringSafe() {
            // TODO: Bringe folgenden Code zum laufen
            var a = "string abc";
            Console.WriteLine(a.ToStringSafe()); // Resultat a.ToString()
            a = null;
            Console.WriteLine(a.ToStringSafe()); // Resultat "null"
        }
    }
}