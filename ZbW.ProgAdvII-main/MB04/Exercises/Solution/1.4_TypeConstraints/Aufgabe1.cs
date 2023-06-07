using System;

namespace _1._4_TypeConstraints {
    // TODO: Korrigieren Sie die Definition der folgenden generische Klasse, ohne an der Methode foo etwas zu verändern
    class Test<T> where T : new() {
        public T GetNewInstance() {
            return new T();
        }
    }
}