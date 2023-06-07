using System;
using System.Collections.Generic;

namespace Generics.TypeConstraints {
    class OrderedBuffer<TElement, TPriority>
        where TPriority : IComparable {
        TElement[] data;
        TPriority[] prio;
        int lastElem;

        public void Put(TElement x, TPriority p) {
            int i = lastElem;
            while (i >= 0 && p.CompareTo(prio[i]) > 0) {
                data[i + 1] = data[i];
                prio[i + 1] = prio[i];
                i--;
            }

            data[i + 1] = x;
            prio[i + 1] = p;
        }
    }

    class Examples {
        public void Test() {
            // Okay: int implementiert IComparable
            new OrderedBuffer<int, int>();



            // Compilerfehler
            //new OrderedBuffer<int, object>();
        }
    }

    class ExamplesStruct {
        public void Work<T>(T source)
            where T : struct {
            // Compilerfehler
            //if (source == null) { return; }

            /* ... */
        }

        public void Test() {
            // 12 wird als Kopie übergeben
            Work(12);
            //// Compilerfehler
            //Work("Hello");
            //// Compilerfehler
            //Work(new object());
            //// Compilerfehler
            //Work<object>(null);
        }
    }

    class ExamplesClass {
        public void Work<T>(T source)
            where T : class {
            if (source == null) {
                return;
            }

            /* ... */
        }

        public void Test() {
            // Compilerfehler
            //Work(12);
            // "Hello" wird als Referenz übergeben
            Work("Hello");
            Work(new object());
            // Angabe nötig da "null" kein Typ ist
            Work<object>(null);
        }
    }

    class ExamplesNew {
        public T GetInstance<T>() where T : new() {
            return new T();
        }

        public void Test() {
            var c = GetInstance<Color>();
            int i = GetInstance<int>();
            object o = GetInstance<object>();

            var p = GetInstance<Person>();
        }

        public T FindOrCreate<T>(List<T> list, Predicate<T> predicate) where T : new()  {
            foreach (var item in list) {
                if (predicate(item)) {
                    return item;
                }
            }

            return new T();
        }
    }

    public class Person {
        public Person(string name) {

        }

        public Person() {

        }
     }

    public class Color {
        private int rgb;
        public Color(int rgb) {
            this.rgb = rgb;
        }

        public Color() {

        }
    }
    class ExamplesClassName {
        public void FillList<T>(T source)
            where T : List<int> {



            source.Add(1);
            source.Add(2);
            source.Add(3);

            foreach (var i in source) {
                /* ... */
            }
        }

        public void Test() {
            List<int> list = new List<int>();


            FillList(list);

            FillList(new MyList());
        }
    }
    public class MyList : List<int> {

    }

    class ExamplesInterfaceName {
        public void FillList<T>(T source)
            where T : IList<int>, IEnumerable<int> {
            source.Add(1);
            source.Add(2);
            source.Add(3);

            foreach (var i in source) {
                /* ... */
            }
        }

        public void Test() {
            List<int> list = new List<int>();
            FillList(list);
        }
    }

    class ExamplesCombiningConstraints<T1, T2>
        where T1 : struct
        where T2 : Ueberblick.Buffer,
        IEnumerable<T1>,
        new() {
    }

    class Base {
    }

    class Sub : Base {
    }

    class Other {
    }

    class ExamplesTOther {
        public void Work<T, TBase>(T a, TBase b)
            where T : TBase {
            T t1 = a;
            //T t2 = b; // Compilerfehler

            TBase to1 = a;
            TBase to2 = b;
        }

        public void Test() {
            Base b = new Base();
            Sub s = new Sub();
            Other o = new Other();
            Work(b, b);
            //Work(b, s); // Compilerfehler
            Work(s, b);
            //Work(s, o); // Compilerfehler
        }
    }
}