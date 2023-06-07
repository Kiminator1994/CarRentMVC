using System;

namespace _6_QueryOperators {
    class Program {
        static void Main(string[] args) {
            int[] numbers = {1, 4, 2, 9, 13, 8, 9, 0, -6, 12};
            string[] cities = {"Bern", "Basel", "Zürich", "Rapperswil", "Genf"};


            /****** ZbwMultipleOf ******/

            // Operator 'ZbwMultipleOf' / Vielfaches von 4 auf 'numbers'
            Console.WriteLine("---------- \r\nOperator 'ZbwMultipleOf' / Vielfaches von 4 auf 'numbers'");
            //IEnumerable<int> multiple4 = numbers.ZbwMultipleOf(4);
            //foreach (int i in multiple4) { Console.WriteLine(i); }

            // Operator 'ZbwMultipleOf' / Vielfaches von 2 und 3 auf 'numbers'
            Console.WriteLine("---------- \r\nOperator 'ZbwMultipleOf' / Vielfaches von 2 und 3 auf 'numbers'");
            // TODO: Implementieren


            /****** ZbwWhere ******/

            // Operator 'ZbwWhere' / Städtenamen mit 'B' auf 'cities'
            Console.WriteLine("---------- \r\nOperator 'ZbwWhere' / Städtenamen mit 'B' auf 'cities'");
            //IEnumerable<string> citiesB = cities.ZbwWhere(delegate(string s) { return s.StartsWith("B"); });
            //foreach (string s in citiesB) { Console.WriteLine(s); }

            // Operator 'ZbwWhere' / Städtenamen mit 'e' im Namen und Länge >= 5 auf 'cities'
            Console.WriteLine("---------- \r\nOperator 'ZbwWhere' / Städtenamen mit 'e' im Namen und Länge >= 5 auf 'cities'");
            // TODO: Implementieren


            /****** ZbwWhere / ZbwMultipleOf ******/

            // Operator 'ZbwWhere' & 'ZbwMultipleOf' / Grösser oder gleich 5 und Vielfaches von 2 auf 'numbers'
            Console.WriteLine("---------- \r\nOperator 'ZbwWhere' & 'ZbwMultipleOf' / Grösser oder gleich 5 und Vielfaches von 2 auf 'numbers'");
            // TODO: Implementieren

            // Operator 'ZbwWhere' / Grösser oder gleich 5 und Vielfaches von 2 auf 'numbers'
            Console.WriteLine("---------- \r\nOperator 'ZbwWhere' / Grösser oder gleich 5 und Vielfaches von 2 auf 'numbers'");
            // TODO: Implementieren


            Console.ReadKey();
        }
    }
}