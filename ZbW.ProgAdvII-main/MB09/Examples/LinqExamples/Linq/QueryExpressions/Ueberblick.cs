using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq.LambdaExpressions.QueryExpressions {
    class Student {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }

    }

    class Marking {
        public int StudentId { get; set; }
        public string Course { get; set; }
        public int Mark { get; set; }
    }


    public class Examples {
        List<Student> Students {
            get {
                return new List<Student>() {
                    new Student {Name = "John", Id = 2009001, Subject = "Computing"},
                    new Student {Name = "Ann", Id = 2009002, Subject = "Mathematics"},
                    new Student {Name = "Sue", Id = 2009003, Subject = "Computing"},
                    new Student {Name = "Bob", Id = 2009004, Subject = "Mathematics"}
                };
            }
        }

        List<Marking> Markings {
            get {
                return new List<Marking>() {
                    new Marking {StudentId = 2009001, Course = "Programming", Mark = 3},
                    new Marking {StudentId = 2009001, Course = "Databases", Mark = 2},
                    new Marking {StudentId = 2009001, Course = "Computer Graphics", Mark = 1},
                    new Marking {StudentId = 2009002, Course = "Organic Chemistry", Mark = 1}
                };
            }
        }

        public void Test1() {
//  1. Datenquelle wählen
            int[] numbers = {0, 1, 2, 3, 4, 5, 6};

// 2. Query erstellen
            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

// 3. Query ausführen
            foreach (int num in numQuery) {
                Console.Write("{0,1} ", num);
            }
        }

        public void TestQueryTranslation() {
            var q1 = from s in Students
                where s.Subject == "Computing"
                orderby s.Name
                select new {s.Id, s.Name};

            // Compiler-Output
            var q2 = Students
                .Where(s => s.Subject == "Computing")
                .OrderBy(s => s.Name)
                .Select(s => new {s.Id, s.Name});
        }

        public void TestQuerySyntax() {
            var q1 = from s in Students
                where s.Subject == "Computing"
                orderby s.Name
                select new {s.Id, s.Name};
        }

        public void TestQuerySyntaxRange() {
            var q = from s in Students
                join m in Markings on s.Id equals m.StudentId
                group s by s.Subject
                into g
                select g;
        }

        public void TestQuerySyntaxGroup() {
            // IEnumerable<IGrouping<string, string>>
            var q = from s in Students
                group s.Name by s.Subject;

            foreach (var group in q) {
                /* ... */
                Console.WriteLine(group.Key);
                foreach (var name in group) {
                    /* ... */
                    Console.WriteLine("  " + name);
                }
            }
        }

        public void TestQuerySyntaxGroupInto() {
            var q = from s in Students
                group s.Name by s.Subject
                into g
                select new {
                    Field = g.Key,
                    N = g.Count()
                };

            foreach (var x in q) {
                Console.WriteLine(x.Field + ": " + x.N);
                Console.WriteLine(x.Field);
            }
        }

        public void TestQuerySyntaxInnerJoinExplicit() {
            var q =
                from s in Students
                join m in Markings on s.Id equals m.StudentId
                select s.Name + ", " + m.Course + ", " + m.Mark;
        }

        public void TestQuerySyntaxInnerJoinImplicit() {
            var q =
                from s in Students
                from m in Markings
                where s.Id == m.StudentId
                select s.Name + ", " + m.Course + ", " + m.Mark;

        }

        public void TestQuerySyntaxGroupJoin() {
            var q =
                from s in Students
                join m in Markings on s.Id equals m.StudentId
                    into list
                select new {
                    Name = s.Name,
                    Marks = list
                };

            foreach (var group in q) {
                Console.WriteLine(group.Name);
                foreach (var m in group.Marks) {
                    Console.WriteLine(m.Course);
                }
            }
        }

        public void TestQuerySyntaxLeftOuterJoin() {
            var q =
                from s in Students
                join m in Markings on s.Id equals m.StudentId
                    into match
                from sm in match.DefaultIfEmpty()
                select s.Name + ", " + (sm == null
                           ? "?"
                           : sm.Course + ", " + sm.Mark);

            foreach (var x in q) {
                Console.WriteLine(x);
            }
        }

        public void TestQuerySyntaxSelectMany() {
            var list = new List<List<string>> {
                new List<string> {"a", "b", "c"},
                new List<string> {"1", "2", "3"},
                new List<string> {"ö", "ä", "ü"}
            };

            Console.WriteLine(1);
            var q1 = list.SelectMany(s => s);

            Console.WriteLine(2);
            var q2 =
                from segment in list
                from token in segment
                select token;
            Console.WriteLine(3);
            foreach (var line in q2) {
                Console.Write("{0}.", line);
            }

            //a.b.c.1.2.3.ö.ä.ü.
        }

        public void TestQuerySyntaxLet() {
            var result =
                from s in Students
                let year = s.Id / 1000
                where year == 2009
                select s.Name + " " + year;

            foreach (string s in result) {
                Console.WriteLine(s);
            }

        }
    }

}