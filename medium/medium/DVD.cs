using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medium
{
    internal class DVD : Medium
    {
        public override string Title { get; set; }
        public override string Ausgeben()
        {
            return "bullshit";
        }

        public DVD(){}

        public DVD(string title)
        {
            Title = title;
        }
    }
}
