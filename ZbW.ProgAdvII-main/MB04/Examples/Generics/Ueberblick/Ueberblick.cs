using System;
using System.Collections;
using System.Data;

namespace Generics.Ueberblick {
    public class Buffer {
        object[] items;

        public void Push(object item) {
            /* ... */
        }

        public object Pop() {
            /* ... */
            return null;
        }
    }

    public class Buffer<T> /*where T: struct*/ {
        T[] items;

        public void Push(T item) {
            /* ... */
        }

        public T Pop() {
            /* ... */
            return default(T);
        }
    }

    public class Buffer<TElement, TPriority> {
        TElement[] items;
        TPriority[] priorities;

        public void Push(TElement item, TPriority prio) {
            /* ... */
        }
    }

    public class DataObject {
        private Hashtable data;
        public T GetValue<T>(string name) {
            return (T) this.data[name];
        }

        public void SetValue<T>(string name, T value) {
            data.Add(name, value);
        }
     }


    class Examples {
        public void Test() {
            int i = 4;
            // TODO: testen

            if (i == null) {

            }

            Buffer buffer = new Buffer();
            buffer.Push(1); // Boxing: Performance-Verlust
            buffer.Push(2);
            //int i = (int) buffer.Pop(); // Casting: Performance-Verlust

            buffer.Push(3);
            buffer.Push("Hello");
        }

        public void TestGeneric() {
            Buffer<float> buffer = new Buffer<float>();
            buffer.Push(1); // Kein Boxing
            buffer.Push(2);
            float i = buffer.Pop(); // Kein Casting

            buffer.Push(3);
            //Buffer.Push("Hello"); // Compilerfehler
        }

        public void TestGenericMultiple() {
            Buffer<int, int> b1 = new Buffer<int, int>();
            b1.Push(1, 3);
            b1.Push(2, 1);

            Buffer<string, float> b2 = new Buffer<string, float>();
            b2.Push("Hello", 0.3f);
            b2.Push("World", 0.2f);
        }

        public void TestGenericMethod() {
            var dataObject = new DataObject();
            var s = dataObject.GetValue<string>("Artikel");

            var dt = new DataTable();
            var row = dt.Rows[0];
            //var artikel = row["Artikel"];
            //var artikel = row.GetValue<string>("Artikel");

            var artikel1 = DataRowExtensions.GetValue<string>(row, "Artikel");

        }
    }

    public static class DataRowExtensions {
        public static T GetValue<T>(this DataRow row, string name) {
            return (T) row[name];
        }
    }


}