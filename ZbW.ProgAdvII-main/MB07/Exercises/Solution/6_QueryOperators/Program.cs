using System;
using System.Collections.Generic;

namespace _6_QueryOperators {
    class Program {
        static void Main(string[] args) {
            int[] numbers = {1, 4, 2, 9, 13, 8, 9, 0, -6, 12};
            string[] cities = {"Bern", "Basel", "Zürich", "Rapperswil", "Genf"};


            /****** ZbwMultipleOf ******/

            // Operator 'ZbwMultipleOf' / Vielfaches von 4 auf 'numbers'
            Console.WriteLine("---------- \r\nOperator 'ZbwMultipleOf' / Vielfaches von 4 auf 'numbers'");
            IEnumerable<int> multiple4 = numbers.ZbwMultipleOf(4);
            foreach (int i in multiple4) {
                Console.WriteLine(i);
            }

            // Operator 'ZbwMultipleOf' / Vielfaches von 2 und 3 auf 'numbers'
            Console.WriteLine("---------- \r\nOperator 'ZbwMultipleOf' / Vielfaches von 2 und 3 auf 'numbers'");
            IEnumerable<int> multiple23 = numbers.ZbwMultipleOf(2).ZbwMultipleOf(3);
            foreach (int i in multiple23) {
                Console.WriteLine(i);
            }


            /****** ZbwWhere ******/

            // Operator 'ZbwWhere' / Städtenamen mit 'B' auf 'cities'
            Console.WriteLine("---------- \r\nOperator 'ZbwWhere' / Städtenamen mit 'B' auf 'cities'");
            IEnumerable<string> citiesB = cities.ZbwWhere(delegate(string s) { return s.StartsWith("B"); });
            foreach (string s in citiesB) {
                Console.WriteLine(s);
            }

            // Operator 'ZbwWhere' / Städtenamen mit 'e' im Namen und Länge >= 5 auf 'cities'
            Console.WriteLine("---------- \r\nOperator 'ZbwWhere' / Städtenamen mit 'e' im Namen und Länge >= 5 auf 'cities'");
            IEnumerable<string> citiesELengthGeq5 = cities
                .ZbwWhere(delegate(string s) { return s.ToLower().Contains("e") && s.Length >= 5; });
            foreach (string s in citiesELengthGeq5) {
                Console.WriteLine(s);
            }


            /****** ZbwWhere / ZbwMultipleOf ******/

            // Operator 'ZbwWhere' & 'ZbwMultipleOf' / Grösser oder gleich 5 und Vielfaches von 2 auf 'numbers'
            Console.WriteLine("---------- \r\nOperator 'ZbwWhere' & 'ZbwMultipleOf' / Grösser oder gleich 5 und Vielfaches von 2 auf 'numbers'");
            IEnumerable<int> numbersGeq5MultipleOf2 = numbers
                .ZbwWhere(delegate(int i) { return i >= 5; })
                .ZbwMultipleOf(2);
            foreach (int s in numbersGeq5MultipleOf2) {
                Console.WriteLine(s);
            }


            // Operator 'ZbwWhere' / Grösser oder gleich 5 und Vielfaches von 2 auf 'numbers'
            Console.WriteLine("---------- \r\nOperator 'ZbwWhere' / Grösser oder gleich 5 und Vielfaches von 2 auf 'numbers'");
            numbersGeq5MultipleOf2 = numbers
                .ZbwWhere(delegate(int i) { return i >= 5 && i % 2 == 0; });
            foreach (int s in numbersGeq5MultipleOf2) {
                Console.WriteLine(s);
            }


            Console.ReadKey();
        }
    }
}