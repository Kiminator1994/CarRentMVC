using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection1 {
    class Program {
        static void Main(string[] args) {
            if (args.Length < 1) {
                return;
            }

            var path = args[0];
            if (!File.Exists(path)) {
                return;
            }

            // TODO: Implementierung gemäss Aufgabenstellung
        }
    }
}
