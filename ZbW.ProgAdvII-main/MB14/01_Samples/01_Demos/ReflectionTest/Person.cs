using System;

namespace ReflectionTest {
    public class Person {
        private string name;

        public Person() {
            this.name = "No name";
        }

        public Person(string name) {
            this.name = name;
        }

        public void SayHello() {
            Console.WriteLine($"Hello, I'm {this.name}");
        }
    }
}
