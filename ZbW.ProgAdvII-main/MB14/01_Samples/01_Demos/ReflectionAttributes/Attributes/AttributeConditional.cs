#define DoAsserts

using System;
using System.Diagnostics;


namespace ReflectionAttributes.Attributes {
    public class AttributeConditional {
        [Conditional("DoAsserts")]
        public static void Assert(bool ok, string errorMsg) {
            if (!ok) {
                Console.WriteLine(errorMsg);
                System.Environment.Exit(0);
            }
        }

        public static void Test(string[] args) {
            Assert(args.Length > 0, "no arguments specified");
            Assert(args[0] == "dir", "invalid argument");

            Console.WriteLine("running ...");
        }
    }
}
