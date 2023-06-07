using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAttributes.Attributes {
    public class AttributeObsolete {
        // Mark OldProperty As Obsolete.
        [Obsolete("This property is obsolete. Use NewProperty instead.", false)]
        public static string OldProperty { get { return "The old property value."; } }

        public static string NewProperty { get { return "The new property value."; } }

        // Mark CallOldMethod As Obsolete.
        [Obsolete("This method is obsolete. Call CallNewMethod instead.", true)]
        public static string CallOldMethod() {
            return "You have called CallOldMethod.";
        }

        public static string CallNewMethod() {
            return "You have called CallNewMethod.";
        }

        public static void Test() {
            Console.WriteLine(OldProperty);
            Console.WriteLine();

            // Compilerfehler
            //Console.WriteLine(CallOldMethod());
        }
    }
    // The attempt to compile this example produces output like the following output:
    //    Example.cs(31,25): error CS0619: 'Example.CallOldMethod()' is obsolete: 
    //            'This method is obsolete. Call CallNewMethod instead.'
    //    Example.cs(29,25): warning CS0618: 'Example.OldProperty' is obsolete: 
    //            'This property is obsolete. Use NewProperty instead.'
}
