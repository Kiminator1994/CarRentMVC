using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medium
{
    internal class DB : Interface1
    {
        public Person[] persons;
        public int Counter { get; set; }
        public Medium[]? Medias { get; set; }

        public DB(int size)
        {
            Medias = new Medium[size];
            persons = new Person[size];
        }

        public void Add(Medium m)
        {
            Medias[Counter] = m;
            Counter++;
        }

        public string Name { get; }

    }
}
