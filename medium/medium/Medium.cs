using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medium
{
    internal abstract class Medium
    {
        public abstract string Title { get; set; }

        public Medium(){}

        public Medium(string title)
        {
            Title = title;
        }

        public abstract string Ausgeben();

    }
}
