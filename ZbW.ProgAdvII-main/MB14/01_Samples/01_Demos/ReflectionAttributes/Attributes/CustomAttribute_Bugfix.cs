using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAttributes.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor
                        | AttributeTargets.Field | AttributeTargets.Method
                        | AttributeTargets.Property, AllowMultiple = true)]
    public class BugfixAttribute : Attribute
    {
        public BugfixAttribute(int bugId, string programmer, string date)
        {
            BugId = bugId; Date = date; Programmer = programmer;
        }

        public int BugId { get; }
        public string Date { get; }
        public string Programmer { get; }
        public string Comment { get; set; }
    }

    [Bugfix(121, "Manuel Bauer", "01/03/2015")]
    [Bugfix(107, "Manuel Bauer", "01/04/2015", Comment = "Some major changes! ;-)")]
    public class MyMath
    {
        [Bugfix(121, "Manuel Bauer", "01/05/2015")]
        public int MyInt { get; set; }

        // Compilerfehler
        //[Bugfix(148, "Manuel Bauer", "01/05/2015")]
        public event Action CalculationDone;


        /* ... */
    }


    public class CustomAttribute_Bugfix
    {
        public static void TestClassAttributes()
        {
            Type type = typeof(MyMath);

            // All Class Attributes
            object[] aiAll = type.GetCustomAttributes(true);

            // Check Definition
            bool aiDef = type.IsDefined(typeof(BugfixAttribute));

        }
        public static void TestPropertyAttributes()
        {
            Type type = typeof(MyMath);
            PropertyInfo pi = type.GetProperty("MyInt");

            // All Class Attributes
            object[] aiAll = pi.GetCustomAttributes(true);

            // Specific Class Attribute
            Attribute ai = pi.GetCustomAttribute(typeof(BugfixAttribute));

            // Check Definition
            bool aiDef = pi.IsDefined(typeof(BugfixAttribute));
        }
    }
}
