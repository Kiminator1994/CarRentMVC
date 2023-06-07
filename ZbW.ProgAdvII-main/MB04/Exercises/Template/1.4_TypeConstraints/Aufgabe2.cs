using System;

namespace _1._4_TypeConstraints {
    // TODO: Versuchen Sie die folgende ausserhalb von MyClass<T> zu instanziieren
    //       Die Aufgabe macht von der Logik her keinen Sinn, es geht rein um das Verständnis von Generics und Type Constraints.
    //       Tipp: Sie müssen dazu zuerst einen neuen Typen(Klasse) definieren.
    class MyClass<T> where T : MyClass<T> {
    }

    // TODO: Neue Klasse erzeugen:
    // class ...
}