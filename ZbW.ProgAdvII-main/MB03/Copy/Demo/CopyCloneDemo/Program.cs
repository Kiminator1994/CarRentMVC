using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyCloneDemo {
    class Program {
        static void Main(string[] args) {
            var p1 = new Person("Thomas Kehl", 39, 9442, "Berneck");
            var p2 = p1;
            //var p2 = (Person) p1.ShallowCopy();
            //var p2 = p1.DeepCopy();

            p1.Age = 40;
            Console.WriteLine(p1.Age);
            Console.WriteLine(p2.Age);

            p1.Name = "Franz Meier";
            Console.WriteLine(p1.Name);
            Console.WriteLine(p2.Name);

            p1.Address.PostalCode = 9000;
            Console.WriteLine(p1.Address.PostalCode);
            Console.WriteLine(p2.Address.PostalCode);

            p1.Address.City = "St. Gallen";
            Console.WriteLine(p1.Address.City);
            Console.WriteLine(p2.Address.City);
        }
    }

    public class Person : ICloneable {
        public string Name;
        public int Age;
        public Address Address;

        public Person(string name, int age, int postalCode, string city) {
            this.Name = name;
            this.Age = age;
            this.Address = new Address(postalCode, city);
        }

        public object ShallowCopy() {
            // flache Kopie
            return this.MemberwiseClone();
        }

        public Person DeepCopy() {
            // tiefe Kopie
            var deepCopyPerson = new Person(this.Name, this.Age, this.Address.PostalCode, this.Address.City);
            return deepCopyPerson;
        }

        public object Clone() {
            return this.ShallowCopy();
            //return this.DeepCopy();
        }
    }

    public class Address {
        public int PostalCode;
        public string City;

        public Address(int postalCode, string city) {
            this.PostalCode = postalCode;
            this.City = city;
        }
    }
}