using System;

namespace Generics {
    public class Program {
        public static void Main(string[] args) {
            //var ex = new Generics.TypeConstraints.ExamplesNew();
            //ex.Test();

            var ex = new Generics.Weiteres.BehindTheScenes.Examples();
            ex.TestValueType();
            ex.TestReferenceType();
        }
    }
}