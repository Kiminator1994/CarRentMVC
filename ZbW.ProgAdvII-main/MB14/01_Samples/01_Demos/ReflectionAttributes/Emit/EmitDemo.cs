using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace ReflectionAttributes.Emit {
    public class EmitDemo {
        public static void Test() {           
            // Create Assembly
            AssemblyName assemblyName = new AssemblyName("Zbw.EmitDemoAssembly");
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("Zbw.EmitDemoModule", "Zbw.EmitDemoAssembly.dll");

            // Define Type "public class EmitDemo"
            TypeBuilder typeBuilder = moduleBuilder.DefineType("ZbwEmitDemo", TypeAttributes.Public);

            // Define Method "public virtual SayHelloTo(string);"
            Type[] paramTypes = {typeof(string)};
            Type retType = typeof(string);
            MethodBuilder methodBuilder = typeBuilder.DefineMethod("SayHelloTo", MethodAttributes.Public | MethodAttributes.Virtual, retType, paramTypes);

            // Write IL Code
            ILGenerator ilGen = methodBuilder.GetILGenerator();
            ilGen.Emit(OpCodes.Ldstr, "Hello ");
            ilGen.Emit(OpCodes.Ldarg_1);
            MethodInfo mi = typeof(string).GetMethod("Concat", new[] {typeof(string), typeof(string)});
            ilGen.Emit(OpCodes.Call, mi);
            ilGen.Emit(OpCodes.Ret);

            // Create Type
            typeBuilder.CreateType();

            // Invoke Method
            MethodInfo method = typeBuilder.GetMethod("SayHelloTo", new[] {typeof(string)});
            object obj = Activator.CreateInstance(typeBuilder);
            object ret = method.Invoke(obj, new object[] {"ZBW"});
            Console.WriteLine(ret);

            // Save the Assembly
            assemblyBuilder.Save(assemblyName.Name + ".dll");



            var assembly = Assembly.LoadFrom(assemblyName.Name + ".dll");
            var type = assembly.ExportedTypes.Single(x => x.Name == "ZbwEmitDemo");
            var method2 = type.GetMethod("SayHelloTo");
            object obj2 = Activator.CreateInstance(type);
            ret = method2.Invoke(obj2, new object[] {"ZBW"});
            Console.WriteLine(ret);

        }

        public static void TestZbwEmitDemoAssembly() {
            //var o = new ZbwEmitDemo();
            //var ret = o.SayHelloTo("Thomas");
            //Console.WriteLine(ret);
        }
    }
}
