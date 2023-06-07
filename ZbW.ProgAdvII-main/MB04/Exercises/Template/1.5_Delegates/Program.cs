using System;
using System.Diagnostics;

namespace _1._5_Delegates {
    // TODO: Ersetzen Sie das Delegate durch ein generisches Delegate
    delegate int Comparer(object x, object y);

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
        static int CompareFraction(object x, object y) {
            Fraction f1 = (Fraction) x;
            Fraction f2 = (Fraction) y;
            float fract1 = (float) f1.a / f1.b;
            float fract2 = (float) f2.a / f2.b;
            if (fract1 < fract2) return -1;
            else if (fract1 > fract2) return 1;
            else return 0;
        }

        // TODO: Konkretisieren
        // Statische Methode zum Vergleichen zweier strings x und y
        // Resultat 0: x = y; Resultat -1: x < y; Resultat +1: x > y
        // Signatur muss mit Delegate Comparer übereinstimmen
        static int CompareString(object x, object y) {
            return ((string) x).CompareTo(y);
        }

        // TODO: Generisch implementieren
        // Generische Sort-Methode zum Sortieren von beliebigen Arrays a
        // compare ist eine Delegate-Instanz und enthaelt die Referenz (=Funktionszeiger)
        // auf eine Compare-Funktion fuer den aktuellen Elementtyp des Arrays
        static void Sort(object[] a, Comparer compare) {
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
                    object x = a[i];
                    a[i] = a[min];
                    a[min] = x;
                }
            }
        }

        public static void Main() {
            // TODO: List<T> anstelle von Arrays verwenden
            Fraction[] a = {new Fraction(1, 2), new Fraction(3, 4), new Fraction(4, 8), new Fraction(8, 3)};
            string[] b = {"pears", "apples", "oranges", "bananas", "plums"};

            // TODO: List<T>.Sort mit "CompareFraction" verwenden
            Sort(a, CompareFraction);

            // Ausgabe des sortierten Arrays a
            // TODO: Ausgabe mit List<T>.ForEach und einer anonymen Methode realisieren
            foreach (Fraction f in a) Console.Write(f + " ");
            Console.WriteLine();

            // TODO: List<T>.Sort mit "CompareString" verwenden
            Sort(b, CompareString);

            // Ausgabe des sortierten Arrays b
            // TODO: Ausgabe mit List<T>.ForEach und einer anonymen Methode realisieren
            foreach (string s in b) Console.Write(s + " ");
            Console.WriteLine();

            // TODO: Konvertieren der "List<Fraction> a" in eine "List<string>"
            //       mit List<T>.ConvertAll und einer anonymen Methode

            Console.ReadKey();
        }
    }
}