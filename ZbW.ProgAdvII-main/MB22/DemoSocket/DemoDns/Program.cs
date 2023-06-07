using System;
using System.Net;

namespace DemoDns {
    /// <summary>
    /// Das folgende Kommandozeilenprogramm illustriert einige
    /// Methoden der .NET Framework Klassen Dns und IPAddress.
    /// </summary>
    class Program {
        public static void Main(string[] args) {
            // Gibt die localhost Daten aus
            try {
                Console.WriteLine("Local Host:\n");
                // Die Methode Dns.GetHostName() gibt den Namen der lokalen Maschine zurück 
                String localHostName = Dns.GetHostName();
                Console.WriteLine("\tHost Name: " + localHostName);
                PrintHostInfo(localHostName);
            } catch (Exception e) {
                Console.WriteLine(e.Message + "\n");
            }

            try {
                Console.WriteLine("www.symas.ch Host:\n");
                PrintHostInfo("www.symas.ch");
                PrintHostInfo("217.26.54.14"); // IP von www.symas.ch - ggf. ersetzen
            } catch (Exception e) {
                Console.WriteLine(e.Message + "\n");
            }

            // Falls Argumente übergeben wurden, gebe die Host Informationen aus
            if (args.Length > 0) {
                foreach (String arg in args) {
                    Console.WriteLine(arg + ":");
                    PrintHostInfo(arg);
                }
            }

            Console.ReadLine();
        }

        // Statische Helper-Funktion
        static void PrintHostInfo(String host) {
            try {
                // Versuche die DNS für die übergebenen Host und IP-Adressen aufzulösen
                var hostInfo = Dns.GetHostEntry(host);

                // Ausgabe des kanonischen Namens
                Console.WriteLine("\tCanonical Name (CNAME): " + hostInfo.HostName);

                // Ausgabe der IP-Adressen
                Console.Write("\tIP Addresses: ");

                foreach (IPAddress ipaddr in hostInfo.AddressList) {
                    Console.Write(ipaddr.ToString() + " ");
                }

                // Ausgabe der Alias-Namen für diesen Host
                Console.Write("\n\tAliases: ");

                foreach (String alias in hostInfo.Aliases) {
                    Console.Write(alias + " ");
                }

                Console.WriteLine("\n");
            } catch (Exception) {
                Console.WriteLine("\tUnable to resolve host: " + host + "\n");
            }
        }
    }
}
