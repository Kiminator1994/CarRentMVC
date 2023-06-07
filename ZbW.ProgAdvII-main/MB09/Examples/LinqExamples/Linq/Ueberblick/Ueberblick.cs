using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Ueberblick {
    class Examples {
        public void Test() {
            string[] cities = {"Bern", "Basel", "Zürich", "St. Gallen", "Genf"};

            // Query 1
            IEnumerable<string> q1 =
                from c in cities
                select c;

            IEnumerable<string> l1 = cities.Select(c => c);


            // Query 2
            IEnumerable<string> q2 = from c in cities
                where c.StartsWith("B")
                orderby c
                select c;

            IEnumerable<string> l2 = cities
                .Where(c => c.StartsWith("B"))
                .OrderBy(c => c);

            foreach(var c in q2) {
                Console.WriteLine(c);
            }
        }
    }
}