using System;
using System.Collections;
using System.Collections.Generic;

namespace _2_CityCollection {
    public class CityCollection {
        private string[] cities = {"Bern", "Basel", "Zürich", "Rapperswil", "Genf"};

        // TODO: Members für Test-Code in Main()-Methode erstellen
    }

    class Program {
        static void Main(string[] args) {
            CityCollection myColl = new CityCollection();

            // Ausgabe
            //foreach (string s in myColl)
            //{
            //	Console.WriteLine(s);
            //}

            // Ausgabe in umgekehrter Reihenfolge 
            //foreach (string s in myColl.Reverse)
            //{
            //	Console.WriteLine(s);
            //}

            Console.ReadKey();
        }
    }
}