using PluginInterface;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;

namespace Reflection2 {
    class Program {
        static void Main(string[] args) {
            var files = Directory.GetFiles(@".\plugins\", "*.dll");

            foreach (var file in files.Select(Path.GetFullPath)) {
                try {
                    // TODO:
                    // 1) Assembly laden (siehe Klasse Assembly)
                    // 2) prüfen, ob es einen Typ gibt, der das Interface IPlugin implementiert (siehe Methode Type.IsAssignableFrom())
                    // 3) sofern ein Typ gefunden, soll dieser instanziiert werden (siehe Activator.CreateInstance())
                    // 4) Methode Execute() ausführen

                    // Ignore assemblies we can't load. They could be native, etc...
                    var assembly = Assembly.LoadFile(file);

                } catch (Win32Exception) {
                } catch (ArgumentException) {
                } catch (FileNotFoundException) {
                } catch (PathTooLongException) {
                } catch (BadImageFormatException) {
                } catch (SecurityException) {
                }
            }
        }
    }
}
