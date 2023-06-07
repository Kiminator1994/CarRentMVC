using System;

namespace Generics.NullableTypes.Ueberblick {
    public class Buffer<T> {
    }

    //public struct Nullable<T>
    //    where T : struct
    //{
    //    public Nullable(T value);

    //    public bool HasValue { get; }
    //    public T Value { get; }
    //}

    class Examples {
        public void NullExamples<T>() {
            // Nullwerte zuweisen
            //T x = null;     // Compilerfehler
            //T y = 0;	      // Compilerfehler
            //T z = default(T); // OK0, '\0', false, null

            // Nullwerte prüfen
            //if (x == null)
            //{
            //    /* ... */
            //}
        }

        public void Nullable1() {
            Nullable<int> i = null;
            int x = i.Value; // System.InvalidOperationException
        }


        public void Nullable2() {
            int? x = 123;
            double? y = 1.0;
        }

        public void Nullable3() {
            // Compiler-Output
            Nullable<int> x = 123;
            Nullable<double> y = 1.0;
        }

        public void Nullable4() {
            int? x = null;
            double? y = null;

            int x1 = x.HasValue ? x.Value : default(int);
        }

        public void Nullable5() {
            int? x = GetNullableInt();
            double? y = GetNullableDouble();
        }

        public void Nullable6() {
            int i = 123;
            int? x = i;
            int j = (int) x;
        }

        public void Nullable6_CompilerOutput() {
            // Compiler-Output
            int i = 123;
            int? x = i;
            int j = x.Value;
        }

        public void Nullable7() {
            int i = GetNullableInt() ?? -1;
        }

        public void Nullable7_CompilerOutput() {
            // Compiler-Output
            // Name von iTemp in IL Code: CS$0$0000
            int? iTemp = GetNullableInt();
            int i;
            if (!iTemp.HasValue) {
                i = -1;
            } else {
                i = iTemp.Value;
            }
        }

        public void Nullable8() {
            string s = GetNullableInt()?.ToString();
            int? i = GetNullableIntArray()?[0];

            Action a = Console.WriteLine;
            a?.Invoke();
        }

        public void Nullable8_CompilerOutput() {
            // Compiler-Output
            int? iTemp = GetNullableInt();
            string s = iTemp.HasValue ? iTemp.GetValueOrDefault().ToString() : null;

            // Compiler-Output
            int[] arr = GetNullableIntArray();
            int? i = arr == null ? default(int?) : arr[0];

            // Compiler-Output
            Action action = Console.WriteLine;
            if (action != null) action();
        }

        private int? GetNullableInt() {
            return null;
        }

        private double? GetNullableDouble() {
            return null;
        }

        private int[] GetNullableIntArray() {
            return null;
        }
    }
}