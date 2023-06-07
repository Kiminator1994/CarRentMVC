using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medium
{
    public class Person : IComparable<Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int Age { get; set; }

        public Person(int age)
        {
            Age = age;
        }

        public int CompareTo(Person? other)
        {
            if (this.Age == other.Age) return 0;
            if (this.Age > other.Age) return 1;
            if (this.Age < other.Age) return -1;
            return 0;
        }
    }
}
