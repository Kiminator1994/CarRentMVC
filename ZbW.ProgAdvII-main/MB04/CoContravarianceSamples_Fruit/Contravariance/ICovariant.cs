using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contravariance {
    interface ICovariant<out T> {
        //T Func();
        //void Func(T t);
        //T Prop { get; set; }
        //T Prop { get; }
    }

    class Covariant<T> : ICovariant<T> { }
}
