using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covariance {
    public interface IBag<out T> {
        T Get(int idx);
    }

    public class Bag<T> : IBag<T> {
        private List<T> _items = new List<T>();

        public T Get(int idx) => _items[idx];
        public void Add(T f) => _items.Add(f);
    }
}
