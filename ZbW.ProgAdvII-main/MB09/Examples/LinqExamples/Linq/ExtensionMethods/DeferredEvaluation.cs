using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Linq.ExtensionMethods {
    class Examples {
        public void TestDeferredEvaluation() {
            string[] cities = {"Bern", "Basel", "Zürich", "St. Gallen", "Genf"};

            // citiesB ist nun ein System.Linq.Enumerable.WhereArrayIterator<string>
            // -> Enumerator - in MoveNext wird jeweils das Predicate geprüft.
            //                 MoveNext wiederum wird erst ausgeführt, wenn z.B. mit foreach iteriert wird (siehe Thema Iteratoren)
            IEnumerable<string> citiesB =
                cities.Where(c => c.StartsWith("B"));

            
            // Ausführung: 2 Städte (Bern, Basel)
            foreach (string c in citiesB) {
                /* ... */
            }

            cities[0] = "Luzern";

            // Ausführung: 1 Stadt (Basel)
            foreach (string c in citiesB) {
                /* ... */
            }

            // Ausführung
            List<string> citiesB2 = cities
                .Where(c => c.StartsWith("B"))
                .ToList();


            // citiesB ist keine ICollection<string> sowie keine ICollection
            // Somit wird in System.LINQ.Enumerable.Count() iteriert und gezählt

            // Ausführung
            int citiesEndL = cities
                .Where(c => c.EndsWith("l"))
                .Count();
        }
    }
}