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

            Assembly a = Assembly.LoadFile(path);
            Console.WriteLine($"Assembly: {a.FullName}");
            foreach (var m in a.Modules) {
                Console.WriteLine($"   Module: {m.Name}");
                foreach (var t in m.GetTypes()) {
                    Console.WriteLine($"      Class: {t.Name}");
                    foreach (var member in t.GetMembers()) {
                        var mb = member as MethodBase;
                        var para = "";
                        if (mb != null) {
                            para += "(";
                            foreach (var p in mb.GetParameters()) {
                                para += $"{p.ParameterType.Name} {p.Name}";
                            }

                            para += ")";
                        }
                        Console.WriteLine($"         {member.MemberType}: {member.Name}{para}");
                        
                    }
                }
            }
        }
    }
}
