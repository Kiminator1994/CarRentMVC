using System;

namespace Generics.KoKontravarianz.Delegate.Vererbung {
    interface IBase<in TIn, out TOut> {
    }

    // Invariant
    interface IInvariant<T1, T2> : IBase<T1, T2> {
    }

    // Covariant
    interface ICovariant<in TIn, T> : IBase<TIn, T> {
    }

    // Contravariant
    interface IContravariant<T, out TOut> : IBase<T, TOut> {
    }

    // Variant
    interface IVariant<in TIn, out TOut> : IBase<TIn, TOut> {
    }
}