using System;
using System.Collections.Generic;

namespace _1._3_QueryExpressions {
    public class Employee {
        public string Name { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public int Salary { get; set; }
        public int DepId { get; set; }
    }

    public class Department {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public class Project {
        private readonly List<Employee> employees = new List<Employee>();
        public string Name { get; set; }

        public IEnumerable<Employee> Employees {
            get { return employees; }
        }

        public void AddEmployee(Employee e) {
            if (!employees.Contains(e))
                employees.Add(e);

        }

        public Employee ProjectManager { get; set; }
    }
}
