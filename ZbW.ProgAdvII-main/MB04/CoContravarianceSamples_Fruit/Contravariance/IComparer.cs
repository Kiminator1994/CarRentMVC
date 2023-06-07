using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contravariance {
    // Nur Illustration. Effektiv wird System.Collections.Generic.IComparer verwendet
    interface IComparer<in T> {
        int Compare(T l, T r);
    }
}
