using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DemoHTTPGet {
    class Program {
        public static void Main(string[] args) {
            string host;
            const int port = 80;

            if (args.Length == 0) {
                // Falls kein Hostname als Argument übergeben wurde soll
                // der lokale Host als Standard genommen werden.
                host = Dns.GetHostName();
            } else {
                host = args[0];
            }

            var result = SocketSendReceive(host, port);
            Console.WriteLine(result);
            File.WriteAllText("DemoHTTPGet.html", result);
        }

        // Initialisiert die Socketverbindung und gibt diese zurück
        private static Socket ConnectSocket(string server, int port) {
            Socket sock = null;

            var hostEntry = Dns.GetHostEntry(server);

            // Nutze die Eigenschaft AddressFamily von IPEndPoint um Konflikte zwischen
            // IPv4 und IPv6zu vermeiden. Gehe dazu die Adressliste mit einer Schleife durch.
            foreach (var address in hostEntry.AddressList) {
                var ipo = new IPEndPoint(address, port);
                var tempSocket = new Socket(ipo.AddressFamily, SocketType.Stream,
                    ProtocolType.Tcp);

                tempSocket.Connect(ipo);

                if (tempSocket.Connected) {
                    sock = tempSocket;
                    break;
                }
            }

            return sock;
        }

        // Die Methode sendet eine HTTP GET 1.1 Anfrage an den Server und
        // empfängt die Daten
        private static string SocketSendReceive(string server, int port) {
            Socket sock = null;

            // Die zu sendenden Daten
            var request = "GET / HTTP/1.1\r\nHost: " + server + "\r\nConnection: Close\r\n\r\n";
            // Kodiere den string in Bytes
            var bytesSent = Encoding.ASCII.GetBytes(request);
            // Lege ein Byte Array an für die zu emfangenden Daten
            var bytesReceived = new byte[4096];

            // Instanziere ein gültiges Socket Objekt mit den übergebenen Argumenten
            sock = ConnectSocket(server, port);

            if (sock == null) {
                return "Connection failed!";
            }

            // Sende den HTTP-Request
            sock.Send(bytesSent, bytesSent.Length, SocketFlags.None);

            int bytes;
            var page = "Default HTML page on " + server + ":\r\n";

            // Empfange die Daten und konvertiere sie
            do {
                bytes = sock.Receive(bytesReceived, bytesReceived.Length, SocketFlags.None);
                // konvertiere die Byte Daten in einen string
                page = page + Encoding.ASCII.GetString(bytesReceived, 0, bytes);
            } while (bytes > 0);

            // Unterbinde alle weiteren Send() und Receive() Aktivitäten am Socket
            sock.Shutdown(SocketShutdown.Both);
            sock.Close();

            return page;
        }
    }
}