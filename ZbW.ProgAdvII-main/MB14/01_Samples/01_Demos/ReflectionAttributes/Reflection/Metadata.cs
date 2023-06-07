using System;
using System.Reflection;

namespace ReflectionAttributes.Reflection.Metadata {
    class Examples {
        public static void TestAssemblyMembers() {
            Assembly a01 = Assembly.Load("mscorlib, PublicKeyToken=b77a5c561934e089, Culture=neutral, Version=4.0.0.0");
            Type[] t01 = a01.GetTypes();
            foreach (Type type in t01) {
                Console.WriteLine(type);
                string x = type.ToString();

                MemberInfo[] mInfos = type.GetMembers();
                foreach (MemberInfo mi in mInfos) {
                    Console.WriteLine("\t{0}\t{1}", mi.MemberType, mi);
                }
            }
        }

        public static void TestTypeMembersAll() {
            Type type = typeof(Counter);

            MemberInfo[] miAll = type.GetMembers();
            foreach (MemberInfo mi in miAll) {
                Console.WriteLine("{0} is a {1}", mi, mi.MemberType);
            }

            Console.WriteLine("----------");

            PropertyInfo[] piAll = type.GetProperties();
            foreach (PropertyInfo pi in piAll) {
                Console.WriteLine("{0} is a {1}", pi, pi.PropertyType);
            }
        }

        public static void TestTypeMembersDynamicSearch() {
            Type type = typeof(Assembly);

            BindingFlags bf =
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.DeclaredOnly;

            MemberInfo[] miFound =
                type.FindMembers(
                    MemberTypes.Method,
                    bf,
                    Type.FilterName,
                    "Get*"
                );

            foreach (MemberInfo mi in miFound) {
                Console.WriteLine("{0} is a {1}", mi, mi.MemberType);
            }
        }

        public static void TestFieldInfo() {
            Type type = typeof(Counter);
            Counter c = new Counter(1);

            // All Fields
            FieldInfo[] fiAll = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            // Specific Field
            FieldInfo fi = type.GetField("countValue", BindingFlags.Instance | BindingFlags.NonPublic);

            int val01 = (int) fi.GetValue(c);
            c.Increment();
            int val02 = (int) fi.GetValue(c);

            fi.SetValue(c, -999);
        }

        public static void TestPropertyInfo() {
            Type type = typeof(Counter);
            Counter c = new Counter(1);

            // All Properties
            PropertyInfo[] piAll = type.GetProperties();

            // Specific Property
            PropertyInfo pi = type.GetProperty("CountValue");

            int val01 = (int) pi.GetValue(c);
            c.Increment();
            int val02 = (int) pi.GetValue(c);

            if (pi.CanWrite) {
                pi.SetValue(c, -999);
            }
        }

        public static void TestMethodInfo() {
            Type type = typeof(Counter);
            Counter c = new Counter(1);

            // All Methods
            MethodInfo[] miAll = type.GetMethods();

            // Specific Method
            MethodInfo mi = type.GetMethod("Increment");

            mi.Invoke(c, null);
        }

        public static void TestMethodInfoAdvanced() {
            Type theMathType = typeof(System.Math);
            // Since System.Math has no public constructor, this
            // would throw an exception.
            //Object theObj = Activator.CreateInstance(theMathType);

            Type[] paramTypes = {typeof(double)}; // array with one member

            // Get method info for Cos(  )
            MethodInfo cosInfo = theMathType.GetMethod("Cos", paramTypes);

            // Fill an array with the actual parameters
            object[] parameters = {
                45 * (Math.PI / 180) // 45 degrees in radians
            };

            object returnVal = cosInfo.Invoke(theMathType, parameters);

            Console.WriteLine("The Cos() of a 45 degree angle {0}", returnVal);
        }

        public static void TestConstructorInfo() {
            Type type = typeof(Counter);
            Counter c = new Counter(1);

            // All Constructors
            ConstructorInfo[] ciAll = type.GetConstructors();

            // Specific Constructor Overload 01
            ConstructorInfo ci01 = type.GetConstructor(
                new[] {typeof(int)});

            Counter c01 = (Counter) ci01.Invoke(new object[] {12});

            // Specific Constructor Overload 02
            ConstructorInfo ci02 = type.GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null, new Type[0], null);

            Counter c02 = (Counter) ci02.Invoke(null);

            // Alternative when Public Default Constructor exists
            //Counter c03 = Activator.CreateInstance<Counter>();
        }
    }
}