using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;
using System.Windows;

namespace SpeedComparison {
    public partial class MainWindow : Window {
        #region Events

        private void StaticCreateButton_Click(object sender, RoutedEventArgs e) {
            int iterations = GetIterations();

            var startTime = DateTimeOffset.Now;
            for (int i = 0; i < iterations; i++) {
                var list = new List<int>();
            }

            var endTime = DateTimeOffset.Now;

            StaticCreateDuration.Text = GetDurationString(startTime, endTime);
        }

        private void ReflectionCreateButton_Click(object sender, RoutedEventArgs e) {
            int iterations = GetIterations();

            Type listType = typeof(List<int>);

            var startTime = DateTimeOffset.Now;
            for (int i = 0; i < iterations; i++) {
                var list = Activator.CreateInstance(listType);
            }

            var endTime = DateTimeOffset.Now;

            ReflectionCreateDuration.Text = GetDurationString(startTime, endTime);
        }

        private void StaticMethodButton_Click(object sender, RoutedEventArgs e) {
            int iterations = GetIterations();

            var list = new List<int>();

            var startTime = DateTimeOffset.Now;
            for (int i = 0; i < iterations; i++) {
                list.Add(i);
            }

            var endTime = DateTimeOffset.Now;

            StaticMethodDuration.Text = GetDurationString(startTime, endTime);
        }

        private void ReflectionMethodButton_Click(object sender, RoutedEventArgs e) {
            int iterations = GetIterations();

            var list = new List<int>();

            Type listType = typeof(List<int>);
            Type[] parameterTypes = {typeof(int)};
            MethodInfo mi = listType.GetMethod("Add", parameterTypes);

            var startTime = DateTimeOffset.Now;
            for (int i = 0; i < iterations; i++) {
                mi.Invoke(list, new object[] {i});
            }

            var endTime = DateTimeOffset.Now;

            ReflectionMethodDuration.Text = GetDurationString(startTime, endTime);
        }

        private void EmitMethodButton_Click(object sender, RoutedEventArgs e) {
            int iterations = GetIterations();

            var list = new List<int>();

            Type listType = typeof(List<int>);
            Type[] parameterTypes = { typeof(int) };
            MethodInfo mi = listType.GetMethod("Add", parameterTypes);

            // Create Assembly
            AssemblyName assemblyName = new AssemblyName("Zbw.EmitDemoAssembly");
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("Zbw.EmitDemoModule", "Zbw.EmitDemoAssembly.dll");

            // Define Type "public class EmitDemo"
            TypeBuilder typeBuilder = moduleBuilder.DefineType("ZbwEmitDemo", TypeAttributes.Public);
            typeBuilder.AddInterfaceImplementation(typeof(IIntAdder));

            // Define Method "public virtual SayHelloTo(string);"
            Type[] paramTypes = { typeof(List<int>),  typeof(int) };
            MethodBuilder methodBuilder = typeBuilder.DefineMethod("Add", MethodAttributes.Public | MethodAttributes.Virtual, null, paramTypes);

            // Write IL Code
            ILGenerator ilGen = methodBuilder.GetILGenerator();
            ilGen.Emit(OpCodes.Ldarg_1);
            ilGen.Emit(OpCodes.Ldarg_2);
            ilGen.Emit(OpCodes.Callvirt, mi);
            //MethodInfo mi = typeof(List<).GetMethod("Concat", new[] { typeof(string), typeof(string) });
            //ilGen.Emit(OpCodes.Call, mi);
            ilGen.Emit(OpCodes.Ret);

            // Create Type
            typeBuilder.CreateType();

            var obj = Activator.CreateInstance(typeBuilder) as IIntAdder;

            //assemblyBuilder.Save(assemblyName.Name + ".dll");

            var startTime = DateTimeOffset.Now;
            for (int i = 0; i < iterations; i++) {
                obj.Add(list, i);
            }

            var endTime = DateTimeOffset.Now;

            EmitMethodDuration.Text = GetDurationString(startTime, endTime);
        }

        #endregion

        public MainWindow() {
            InitializeComponent();
        }

        private int GetIterations() {
            return Int32.Parse(IterationTextBox.Text, NumberStyles.AllowThousands);
        }

        private string GetDurationString(DateTimeOffset startTime, DateTimeOffset endTime) {
            var duration = endTime - startTime;
            return $"{duration.TotalMilliseconds:F0} ms";
        }
    }

    public interface IIntAdder {
        void Add(List<int> list, int i);
    }
}