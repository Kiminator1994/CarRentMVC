using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contravariance {
    interface IContravariant<in T> {
        // Contravariance ist das Gegenteil von Convariance (kehr ebenfalls die Vererbung um - desweben Contra...)
        //T Func();
        //void Func(T t);
        //T Prop { get; set; }
        //T Prop { set; }
    }

    class Contravariant<T> : IContravariant<T> { }
}
