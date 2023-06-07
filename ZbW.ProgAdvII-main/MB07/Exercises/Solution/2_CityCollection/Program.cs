using System;
using System.Collections;
using System.Collections.Generic;

namespace _2_CityCollection {
    public class CityCollection : IEnumerable<string> {
        private string[] cities = {"Bern", "Basel", "Zürich", "Rapperswil", "Genf"};

        // TODO: Members für Test-Code in Main()-Methode erstellen

        public IEnumerator<string> GetEnumerator() {
            for (int i = 0; i < cities.Length; i++)
                yield return cities[i];

            //Alternative ohne Yield:
            //Enumerator implementieren (siehe ExamplesItratoren)

            //Alternative 2:
            //foreach (var city in m_Cities) { yield return city ;}
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public IEnumerable<string> Reverse {
            get {
                for (int i = cities.Length - 1; i >= 0; i--)
                    yield return cities[i];
            }
        }
    }

    class Program {
        static void Main(string[] args) {
            CityCollection myColl = new CityCollection();

            // Ausgabe
            foreach (string s in myColl) {
                Console.WriteLine(s);
            }

            // Ausgabe in umgekehrter Reihenfolge 
            foreach (string s in myColl.Reverse) {
                Console.WriteLine(s);
            }

            Console.ReadKey();
        }
    }
}