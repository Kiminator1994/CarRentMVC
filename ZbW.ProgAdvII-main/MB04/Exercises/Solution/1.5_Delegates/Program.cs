using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _1._5_Delegates {
    // TODO: Ersetzen Sie das Delegate durch ein generisches Delegate
    delegate int Comparer<T>(T x, T y);

    /// <summary>
    /// Einfacher Referenztyp für das Rechnen mit Bruechen 
    /// </summary>
    class Fraction {
        public int a, b;

        public Fraction(int a, int b) {
            this.a = a;
            this.b = b;
        }

        // Überladene Methode System.Object.ToString
        public override string ToString() {
            return a + " / " + b;
        }
    }

    class Program {
        // TODO: Konkretisieren
        // Statische Methode zum Vergleichen zweier Brueche x und y
        // Resultat 0: x = y; Resultat -1: x < y; Resultat +1: x > y
        // Signatur muss mit Delegate Comparer übereinstimmen
        static int CompareFraction(Fraction x, Fraction y) {
            float fract1 = (float) x.a / x.b;
            float fract2 = (float) y.a / y.b;
            if (fract1 < fract2) return -1;
            else if (fract1 > fract2) return 1;
            else return 0;
        }

        // TODO: Konkretisieren
        // Statische Methode zum Vergleichen zweier strings x und y
        // Resultat 0: x = y; Resultat -1: x < y; Resultat +1: x > y
        // Signatur muss mit Delegate Comparer übereinstimmen
        static int CompareString(string x, string y) {
            return x.CompareTo(y);
        }

        // TODO: Generisch implementieren
        // Generische Sort-Methode zum Sortieren von beliebigen Arrays a
        // compare ist eine Delegate-Instanz und enthaelt die Referenz (=Funktionszeiger)
        // auf eine Compare-Funktion fuer den aktuellen Elementtyp des Arrays
        static void Sort<T>(T[] a, Comparer<T> compare) {
            // compare muss genau eine Methode referenzieren (kein Multicast)
            // Sie koennen dazu die Methode Debug.Assert verwenden (siehe Help)
            Debug.Assert(compare != null && compare.GetInvocationList().Length == 1, "Genau eine Vergleichsfunktion");

            // Selection sort
            for (int i = 0; i < a.Length - 1; i++) {
                int min = i;
                for (int j = i + 1; j < a.Length; j++) {
                    if (compare(a[j], a[min]) < 0) min = j;
                }

                if (min != i) {
                    T x = a[i];
                    a[i] = a[min];
                    a[min] = x;
                }
            }
        }

        public static void Main() {
            // TODO: List<T> anstelle von Arrays verwenden
            List<Fraction> a = new List<Fraction> {new Fraction(1, 2), new Fraction(3, 4), new Fraction(4, 8), new Fraction(8, 3)};
            List<string> b = new List<string> {"pears", "apples", "oranges", "bananas", "plums"};

            // TODO: List<T>.Sort mit "CompareFraction" verwenden
            a.Sort(CompareFraction);

            // Ausgabe des sortierten Arrays a
            // TODO: Ausgabe mit List<T>.ForEach und einer anonymen Methode realisieren
            a.ForEach(delegate(Fraction f) { Console.Write(f + " "); });
            Console.WriteLine();

            // TODO: List<T>.Sort mit "CompareString" verwenden
            b.Sort(CompareString);

            // Ausgabe des sortierten Arrays b
            // TODO: Ausgabe mit List<T>.ForEach und einer anonymen Methode realisieren
            b.ForEach(delegate(string s) { Console.Write(s + " "); });
            Console.WriteLine();

            // TODO: Konvertieren der "List<Fraction> a" in eine "List<string>"
            //       mit List<T>.ConvertAll und einer anonymen Methode
            List<string> strings = a.ConvertAll(delegate(Fraction f) { return f.ToString(); });

            Console.ReadKey();
        }
    }
}