using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iteratoren.Test;

namespace Iteratoren.Extensions {

    public interface ITest {

    }


    public static class ExtensionMethods {
        public static string ToStringSafe(this object o)
        {
            return o == null ? string.Empty : o.ToString();
        }

        public static string ToString(this object o) {
            return "aaa";
        }

        public static string ToText(this ExtensionTest.VehicleType type) {
            return string.Format("{0}:{1}", (int) type, type);
        }

        public static T? OrNull<T>(this ExtensionTest.TryParseMethod<T> tryParser, string s) where T : struct {
            // should return null, if parsing is not working ...
            return tryParser(s, out var result) ? (T?) result : null;
        }

        public static T[] CopyAddElements<T>(this T[] array, params T[] add) {
            for (int i = 0; i < add.Length; i++) {
                Array.Resize(ref array, array.Length + 1);
                array[array.Length - 1] = add[i];
            }

            return array;
        }

        public static void DoIrgendwas(this ITest t, int o) {

        }
    }


    public class ExtensionTest {
        public enum VehicleType {
            Bicycle,
            Car,
            Bus,
            Train,
            Aeroplane
        }

        public delegate bool TryParseMethod<T>(string s, out T maybeValue);

        public void Test() {
            object o = null;
            var s = o?.ToStringSafe();


            int a = 4;
            var b = a.DoMagicCalculation("xx");
            var b2 = Iteratoren.Test.Extensions.DoMagicCalculation(a, "xx");

            var l = new List<int>() {4, 7, 1, 4, 7, 8};
            foreach (int item in l.Range(1, 3)) {

            }














            //ITest t = null;
            //t.DoIrgendwas(6);

            //object o = null;
            //var s1 = o.ToString();

            //object o2 = null;
            //var s2 = o2.ToStringSafe();
            ////var s2 = ExtensionMethods.ToStringSafe(o2);

            //var v = VehicleType.Bicycle;
            //var s3 = v.ToText();

            //TryParseMethod<int> parser = int.TryParse;
            //var x = parser.OrNull("a");

            //string[] array = new string[] {"Foo", "Bar"};
            //array = array.CopyAddElements("Baz", "Foobar");
        }
    }
}