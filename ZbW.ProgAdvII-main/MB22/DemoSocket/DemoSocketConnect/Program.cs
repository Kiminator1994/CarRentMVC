using System;
using System.Net;
using System.Net.Sockets;

namespace DemoSocketConnect {
    class Program {
        static void Main(string[] args) {
            try {
                Socket sock = null;
                string host = "zbw.ch";  // Uri
                int port = 80;

                IPHostEntry hostEntry = Dns.GetHostEntry(host);
                IPAddress[] ipAddresses = hostEntry.AddressList;

                Console.WriteLine(host + " is mapped to the IP-Address(es): ");

                // Ausgabe der zugeordneten IP-Adressen
                foreach (IPAddress ipAddress in ipAddresses) {
                    Console.Write(ipAddress.ToString());
                }

                // Instanziere einen Endpunkt mit der ersten IP-Adresse
                IPEndPoint ipEo = new IPEndPoint(ipAddresses[0], port);

                // IPv4 oder IPv6, Stream Socket, TCP
                sock = new Socket(ipEo.AddressFamily,
                    SocketType.Stream,
                    ProtocolType.Tcp);

                // Öffne eine Socket Verbindung
                sock.Connect(ipEo);

                // Prüfe ob eine Verbindung besteht?
                if (sock.Connected) {
                    Console.WriteLine(" - Connection established!\n");
                    // Socket schließen und Ressourcen freigeben
                    sock.Close();
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
