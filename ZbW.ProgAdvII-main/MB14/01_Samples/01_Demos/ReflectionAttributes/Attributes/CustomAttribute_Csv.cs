using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ReflectionAttributes.Attributes {

    namespace ReflectionDemos {
        public class CustomAttribute_Csv {
            public static void Test() {
                List<Address> addresses = new List<Address> {
                    new Address("Thomas", "Obereggerstrasse 17", "9442", "Berneck"),
                    new Address("Beat", "Hauptstrasse 2", "9000", "St. Gallen"),
                    new Address("Sepp", "Arosastrasse 12", "7000", "Chur")
                };
                Writer.SaveToCsv(addresses, @"C:\Temp\addresses.csv");

                var articles = new List<Artikel> {
                    new Artikel {ArtNr = "aaa", Bez = "Bezeichnung", Preis = 2},
                    new Artikel {ArtNr = "bbb", Bez = "bez2", Preis = 4},
                };
                Writer.SaveToCsv(articles, @"C:\Temp\articles.csv");
            }
        }

        public class Address {
            [CsvName("Name"), Uppercase]
            public string Name { get; set; }

            [CsvName("StrasseUndHausnummer"), Lowercase]
            public string Street { get; set; }

            [CsvName("Plz"), Uppercase]
            public string Postcode { get; set; }

            //[CsvName("Ort")]
            public string City { get; set; }

            public Address(string name, string street, string postcode, string city) {
                Name = name;
                Street = street;
                Postcode = postcode;
                City = city;
            }
        }

        public class Artikel {
            [CsvName("No")]
            public string ArtNr { get; set; }
            [CsvName("Description"), Lowercase]
            public string Bez { get; set; }
            [CsvName("Price")]
            public int Preis { get; set; }
        }

        #region Attributes

        public interface IStringFilter {
            string Filter(string arg);
        }

        public class UppercaseAttribute : Attribute, IStringFilter {
            public string Filter(string arg) {
                return arg.ToUpper();
            }
        }

        public class LowercaseAttribute : Attribute, IStringFilter {
            public string Filter(string arg) {
                return arg.ToLower();
            }
        }

        public class CsvNameAttribute : Attribute {
            public string Name { get; set; }

            public CsvNameAttribute(string name) {
                Name = name;
            }
        }

        #endregion

        public static class Writer {
            internal static void SaveToCsv<T>(IEnumerable<T> source, string fileName) {
                #region My Secret Logic

                if (File.Exists(fileName)) {
                    File.Delete(fileName);
                }

                Type containedType = typeof(T);
                PropertyInfo[] properties = containedType.GetProperties();

                using (StreamWriter writer = new StreamWriter(fileName, false)) {
                    // Header
                    foreach (PropertyInfo pi in properties) {
                        string writeThis;

                        if (pi.IsDefined(typeof(CsvNameAttribute), true)) {
                            CsvNameAttribute csvName = (CsvNameAttribute) pi.GetCustomAttributes(typeof(CsvNameAttribute), true)[0];
                            writeThis = csvName.Name + ";";
                        } else {
                            // Default: Ueberschrift = Feldname
                            writeThis = pi.Name + ";";
                        }

                        writer.Write(writeThis);
                        Console.Write(writeThis);
                    }

                    writer.WriteLine();
                    Console.WriteLine();

                    // Content
                    foreach (T elem in source) {
                        foreach (PropertyInfo pi in properties) {
                            string writeThis;

                            if (pi.IsDefined(typeof(IStringFilter), true)) {
                                IStringFilter flt = (IStringFilter) pi.GetCustomAttributes(typeof(IStringFilter), true)[0];
                                writeThis = flt.Filter(pi.GetValue(elem).ToString()) + ";";
                            } else {
                                writeThis = pi.GetValue(elem) + ";";
                            }

                            writer.Write(writeThis);
                            Console.Write(writeThis);
                        }

                        writer.WriteLine();
                        Console.WriteLine();
                    }

                    writer.Flush();
                    writer.Close();
                }

                #endregion
            }
        }
    }
}