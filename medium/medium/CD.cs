using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medium
{
    internal class CD : DVD
    {
        public new string Title { get; set; }
        public override string Ausgeben()
        {
            throw new NotImplementedException();
        }

        public CD(string title)
        {
            Title = title;
        }
    }
}
