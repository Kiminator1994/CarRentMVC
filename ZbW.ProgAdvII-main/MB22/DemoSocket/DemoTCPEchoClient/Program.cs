using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DemoTCPEchoClient {
    class Program {
        public static void Main(string[] args) {
            if (args.Length > 2) {
                throw new ArgumentException("Parameters: [<Server>] [<Port>]");
            }

            while (true) {
                Console.WriteLine("Enter input:");
                string line = Console.ReadLine();
                if (line == "exit") {
                    break;
                }

                var byteBuffer = Encoding.ASCII.GetBytes(line);

                // Verwende den angegebenen Host, ansonsten nimm den lokalen Host
                var server = (args.Length >= 1) ? args[0] : Dns.GetHostName();
                // Verwende den angegebenen Port, ansonsten nimm den Standardwert 7
                var servPort = (args.Length >= 2) ? Int32.Parse(args[1]) : 7;

                Socket clientSock = null;

                try {
                    var serverEndPoint = new IPEndPoint(Dns.GetHostEntry(server).AddressList[0], servPort);

                    // Überprüfe, ob es sich um eine IPv6 Adresse handelt
                    if (serverEndPoint.AddressFamily != AddressFamily.InterNetworkV6) {
                        Console.WriteLine("Not a valid IPv6 address.");
                        return;
                    }

                    // Neue TCP Instanz
                    clientSock = new Socket(serverEndPoint.AddressFamily,
                        SocketType.Stream,
                        ProtocolType.Tcp);

                    clientSock.Connect(serverEndPoint);
                    Console.WriteLine("Connected to server... sending echo string");

                    // Sende den enkodierten string an den server
                    clientSock.Send(byteBuffer, 0, byteBuffer.Length, SocketFlags.None);
                    clientSock.Shutdown(SocketShutdown.Send);   // Wichtig, damit der lesende Stream des TcpListener (für 06DemoTCPEchoServerTcpListener) geschlossen wird

                    Console.WriteLine("Sent {0} bytes to server...", byteBuffer.Length);

                    var totalBytesRcvd = 0;
                    int bytesRcvd = 1;

                    // Empfange denselben string wieder vom server
                    while (bytesRcvd > 0) {
                        if ((bytesRcvd = clientSock.Receive(byteBuffer, totalBytesRcvd, byteBuffer.Length - totalBytesRcvd, SocketFlags.None)) == 0) {
                            Console.WriteLine("Connection closed preaturely.");
                            break;
                        }

                        totalBytesRcvd += bytesRcvd;
                    }

                    Console.WriteLine("Received {0} bytes from server: {1}", totalBytesRcvd,
                        Encoding.ASCII.GetString(byteBuffer, 0, totalBytesRcvd));

                    clientSock.Shutdown(SocketShutdown.Both);
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                } finally {
                    clientSock?.Close();
                }
            }
        }

    }
}
