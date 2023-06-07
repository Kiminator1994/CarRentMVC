using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medium
{
    public class PersonComparer : IComparer<Person>
    {


        public int Compare(Person? x, Person? y)
        {
            Person p = x as Person;
            Person p2 = y as Person;
            if (p.Age == p2.Age) return 0;
            if (p.Age > p2.Age) return 1;
            if (p.Age < p2.Age) return -1;
            return 0;
        }
    }
}
