using System;
using System.Reflection;

namespace ReflectionAttributes.Reflection.AssemblyDemo {
    class Examples {
        public static void TestAssembly() {
            // ggf. muss Project ReflectionTest vorgängig kompiliert werden
            Assembly a = Assembly.Load("ReflectionTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
            var o1 = a.CreateInstance("ReflectionTest.Person");


            var t = a.GetType("ReflectionTest.Person");
            var o2 = Activator.CreateInstance(t, "Thomas");
            var m2 = t.GetMethod("SayHello");
            m2.Invoke(o2, null);
        }
    }
}