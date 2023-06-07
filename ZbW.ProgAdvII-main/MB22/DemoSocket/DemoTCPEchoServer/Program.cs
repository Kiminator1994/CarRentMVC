using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DemoTCPEchoServer {
    /// <summary>
    /// Ein synchroner TCP-Server, der alle empfangenen Daten
    /// wieder umgehend an den Clienten zurück sendet.
    /// </summary>
    class Program {
        private const int BUFSIZE = 32;
        private const int BACKLOG = 5;

        public static void Main(string[] args) {
            if (args.Length > 1) {
                throw new ArgumentException("Parameters: [<Port>]");
            }

            var servPort = (args.Length == 1) ? Int32.Parse(args[0]) : 7;

            Socket servSock = null;

            try {
                // Verwende explizit IPv6
                servSock = new Socket(AddressFamily.InterNetworkV6,
                    SocketType.Stream,
                    ProtocolType.Tcp);

                // Assoziiert den Socket mit einem lokalen Endpunkt
                servSock.Bind(new IPEndPoint(IPAddress.IPv6Any, servPort));

                // Versetzt den Socket in den aktiven Abhörmodus 
                servSock.Listen(BACKLOG);
            } catch (SocketException se) {
                Console.WriteLine(se.ErrorCode + ": " + se.Message);
                Environment.Exit(se.ErrorCode);
            }

            var rcvBuffer = new byte[BUFSIZE];

            // Lässt den Server in einer Endlosschleife laufen
            while(true) {
                Socket client = null;

                try {
                    // Die Methode Accept generiert einen neuen Socket indem sie synchron 
                    // die anstehenden Verbindungsanfragen aus der Warteschlange des Listening Sockets extrahiert.
                    client = servSock.Accept();

                    Console.Write("Handling client at " + client.RemoteEndPoint + " - ");

                    // Empfange bis der client die Verbindung schließt, das geschieht indem 0
                    // zurückgegeben wird
                    var totalbytesEchoed = 0;
                    int bytesRcvd;
                    while ((bytesRcvd = client.Receive(rcvBuffer, 0, rcvBuffer.Length, SocketFlags.None)) > 0) {
                        var line = Encoding.ASCII.GetString(rcvBuffer);
                        line += " from Server";
                        rcvBuffer = Encoding.ASCII.GetBytes(line);
                        client.Send(rcvBuffer, 0, rcvBuffer.Length, SocketFlags.None);
                        totalbytesEchoed += bytesRcvd;
                    }

                    Console.WriteLine("echoed {0} bytes.", totalbytesEchoed);

                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                    client?.Close();
                }
            }
        }
    }
}