using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoUDPReceiver {
    class Program {
        static void Main(string[] args) {
            if (args.Length > 1)
                throw new ArgumentException("Parameter(s): [<Port>]");

            var port = (args.Length == 1) ? Int32.Parse(args[0]) : 7;

            // UDP Socket für den Empfang
            UdpClient client = new UdpClient(port);

            IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Any, port);


            var data = client.Receive(ref remoteIPEndPoint);
            

            Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));

            client.Close();

            Console.ReadKey();
        }

    }
}
