using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveList
{
    internal class RecursiveList<T> : List<T>
    {
        public IEnumerable<T> Traverse()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this[i];
            }
        }

        public IEnumerable<T> Inverse()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this[i];
            }
        }

        //public IEnumerable<T> Inverse()
        //{
        //    int count = this.Count -1;
        //    if (count < 0) yield break;
        //    InverseInternal(count);
        //}

        //public IEnumerable<T> InverseInternal(int index)
        //{
        //    int count = index;
        //    if (count < 0) yield break;
        //    yield return this[count--];
        //    InverseInternal(count);
        //}
    }
}
