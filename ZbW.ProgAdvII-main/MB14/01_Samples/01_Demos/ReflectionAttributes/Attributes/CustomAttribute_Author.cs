using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAttributes.Attributes {
    [System.AttributeUsage(System.AttributeTargets.Class |
                           System.AttributeTargets.Struct |
                           System.AttributeTargets.Method |
                           System.AttributeTargets.Property,
        AllowMultiple = true)]
    public class AuthorAttribute : System.Attribute {
        private string name;
        public double Version { get; set; }

        public AuthorAttribute(string name) {
            this.name = name;
            Version = 1.0;
        }
    }

    [Author("Max Meier", Version = 1.2)]
    [Author("Thomas Kehl")]
    [Serializable]
    public class MyMath {
        [Author("Thomas Kehl", Version = 1.1)]
        public int MyInt { get; set; }

        // Compilerfehler
        // [Author("Thomas Kehl", Version = 1.1)]
        public event Action CalculationDone;



        /* ... */
    }


    public class CustomAttribute_Author {
        public static void TestClassAttributes() {
            Type type = typeof(MyMath);

            // All Class Attributes
            object[] aiAll = type.GetCustomAttributes(true);

            var a = (AuthorAttribute)aiAll[0];
            Console.WriteLine(a.Version);

            // Check Definition
            bool aiDef = type.IsDefined(typeof(SerializableAttribute));

        }

        public static void TestPropertyAttributes() {
            Type type = typeof(MyMath);
            PropertyInfo pi = type.GetProperty("MyInt");

            // All Property Attributes
            object[] aiAll = pi.GetCustomAttributes(true);

            // Specific Property Attribute
            Attribute ai = pi.GetCustomAttribute(typeof(AuthorAttribute));

            // Check Definition
            bool aiDef = pi.IsDefined(typeof(AuthorAttribute));
        }
    }
}