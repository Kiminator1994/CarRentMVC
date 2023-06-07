using System.Collections.Generic;
using System.Linq;

namespace Linq.Initializers {
    public class Examples {
        public void TestObjectInitializers() {
            Student s1 = new Student("John") {Id = 2009001, Subject = "Computing"};
            Student s2 = new Student {Name = "Ann", Id = 2009002, Subject = "Mathematics"};

            // Compiler-Output
            //Student s11 = new Student("John");
            //s11.Id = 2009001;
            //s11.Subject = "Computing";

            //Student s22 = new Student();
            //s22.Name = "Ann";
            //s22.Id = 2009002;
            //s22.Subject = "Mathematics";

            int[] ids = {2009001, 2009002, 2009003, 2009004};
            IEnumerable<Student> students = ids.Select(n => new Student {Id = n});
            var l = students.ToList();
        }

        public void TestCollectionInitializers() {
            List<int> l1 = new List<int>
                {1, 2, 3, 4};

            Dictionary<int, string> d1 = new Dictionary<int, string> {
                {1, "a"},
                {2, "b"},
                {3, "c"}
            };

            d1 = new Dictionary<int, string> {
                [1] = "a",
                [2] = "b",
                [3] = "c"
            };

            // Compiler-Output
            List<int> l11 = new List<int>();
            l11.Add(1);
            l11.Add(2);
            l11.Add(3);
            l11.Add(4);

            Dictionary<int, string> d11 = new Dictionary<int, string>();
            d11.Add(1, "a");
            d11.Add(2, "b");
            d11.Add(3, "c");

            d11 = new Dictionary<int, string>();
            d11[1] = "a";
            d11[2] = "b";
            d11[3] = "c";

        }

        public void TestCombination() {
            object s = new Dictionary<int, Student> {
                {2009001, new Student("John") {Id = 2009001, Subject = "Computing"}},
                {2009002, new Student {Name = "Ann", Id = 2009002, Subject = "Mathematics"}}
            };
        }
    }

    class Student {
        public string Name;
        public int Id;
        public string Subject { get; set; }

        public Student() {
        }

        public Student(string name) {
            Name = name;
        }
    }

}