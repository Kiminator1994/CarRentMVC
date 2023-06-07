using System;

namespace _1._3_Nullable {
    class Program {
        static void Main(string[] args) {
            int a = 0;
            bool b = false;
            int? c = 10;
            bool? d = null;
            int? e = null;

            int? x01 = c + a; // 10
            int? x02 = a + null; // null
            bool x03 = a < c; // true 
            bool x04 = a + null < c; // false
            bool x05 = a > null; // false
            int? x06 = (a + c - e) * 9898 + 1000; // null
            bool? x07 = d; // null
            bool x08 = d == d; // true
            int x09 = c ?? 1000; // 10
            int x10 = e ?? 1000; // 1000

            Console.ReadKey();
        }
    }
}