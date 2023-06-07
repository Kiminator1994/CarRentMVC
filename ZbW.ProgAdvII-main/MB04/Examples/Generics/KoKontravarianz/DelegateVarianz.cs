using System;

namespace Generics.KoKontravarianz.Delegate {
    public delegate TResult Func<out TResult>();

    public delegate void Action<in T>(T obj);

    class Examples {
        static string GetString() {
            return "";
        }

        static void SetObject(object obj) {
        }

        public void TestKovarianz() {
            Func<string> fstr = GetString;
            // Funktioniert
            Func<object> fobj = fstr;

            object o = fobj();
        }

        public void TestKontravarianz() {
            Action<object> aobj = SetObject;
            // Funktioniert
            Action<string> astr = aobj;

            astr("Test");
        }
    }
}