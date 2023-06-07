using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contravariance {
    class FruitComparer : System.Collections.Generic.IComparer<Fruit> {
        public int Compare(Fruit l, Fruit r) {
            return (int)(l.Weight - r.Weight);
        }
    }
}
