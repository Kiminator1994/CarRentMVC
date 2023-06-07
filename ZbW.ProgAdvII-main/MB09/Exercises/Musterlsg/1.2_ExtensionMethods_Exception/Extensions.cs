using System;

namespace _1._2_ExtensionMethods_Exceptions {
    public static class Extensions {
        // TODO: GetInnerstException
        public static Exception GetInnerstException(this Exception ex) {
            var e = ex;
            while (e.InnerException != null) {
                e = e.InnerException;
            }

            return e;
        }

        // TODO: ForEachException
        public static void ForEachException(this Exception ex, Action<Exception> action) {
            var e = ex;
            while (e != null) {
                action(e);
                e = e.InnerException;
            }
        }
    }
}