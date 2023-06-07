using System;

namespace Generics.KoKontravarianz.Delegate.InOut {
    interface IVariant<out TOut, in TIn> {
        // Okay
        TOut GetR();

        // Okay
        void SetA(TIn sampleArg);

        // Okay
        TOut GetRSetA(TIn sampleArg);

        // Compilerfehler
        //TOut GetA();
        // Compilerfehler
        //void SetR(TIn sampleArg);
        // Compilerfehler
        //TOut GetASetR(TIn sampleArg);
    }

    // Compilerfehler
    //class Variant<out T> { }
}