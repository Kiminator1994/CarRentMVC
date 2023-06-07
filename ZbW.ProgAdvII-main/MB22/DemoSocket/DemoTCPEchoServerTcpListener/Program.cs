using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DemoTCPEchoServerTcpListener {
    class Program {
        private const int BUFSIZE = 32; // Grösse des Empfänger Buffers

        static void Main(string[] args) {
            if (args.Length > 1) {
                throw new ArgumentException("Parameters: [<Port>]");
            }

            var servPort = (args.Length == 1) ? Int32.Parse(args[0]) : 7;

            TcpListener listener = null;

            try {
                // Erzeuge eine TcpListener Instanz um eigehende
                // Verbindungen anzunehmen
                listener = new TcpListener(IPAddress.IPv6Any, servPort);
                listener.Start();
            } catch (SocketException se) {
                Console.WriteLine(se.ErrorCode + ": " + se.Message);
                Environment.Exit(se.ErrorCode);
            }

            var rcvBuffer = new byte[BUFSIZE];

            // Lässt den Server in einer Endlosschleife laufen
            while(true) {
                NetworkStream netStream = null;

                try {
                    // Generiere eine Client Verbindung
                    var client = listener.AcceptTcpClient();
                    netStream = client.GetStream();
                    Console.Write("Handling client - ");

                    var totalBytesEchoed = 0;

                    int bytesRcvd;
                    while ((bytesRcvd = netStream.Read(rcvBuffer, 0, rcvBuffer.Length)) > 0) {
                        netStream.Write(rcvBuffer, 0, bytesRcvd);
                        totalBytesEchoed += bytesRcvd;
                    }

                    Console.WriteLine("echoed {0} bytes.", totalBytesEchoed);

                    // Schließe den Socket. Wir haben den Clienten erfolgreich abgewickelt
                    netStream.Close();
                    client.Close();

                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                    netStream?.Close();
                }
            }
        }
    }
}
