using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._3_QueryExpressions {
    static class Program {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            foreach (T item in source)
                action(item);
        }

        static void Main(string[] args) {
            var departments = new List<Department> {
                new Department {Name = "Engineering", Id = 1},
                new Department {Name = "Marketing", Id = 2}
            };

            var employees = new List<Employee> {
                new Employee {Name = "Michael", Address = "SW Liverpool Lane", State = "WA", Salary = 5675, DepId = 1},
                new Employee {Name = "Jennifer", Address = "1245 NW Baypony Dr", State = "OR", Salary = 6555, DepId = 1},
                new Employee {Name = "Sean", Address = "55217 SW Estate Dr", State = "WA", Salary = 8888, DepId = 1},
                new Employee {Name = "Peter", Address = "Ma Lane", State = "WA", Salary = 9999, DepId = 2},
                new Employee {Name = "Henry", Address = "Ma Dr", State = "OR", Salary = 3209, DepId = 2}
            };

            var projects = new List<Project> {
                new Project {Name = "Saturn", ProjectManager = employees[0]},
                new Project {Name = "Uranus", ProjectManager = employees[2]},
                new Project {Name = "Pluto"}

            };
            projects[0].AddEmployee(employees[0]);
            projects[0].AddEmployee(employees[2]);
            projects[0].AddEmployee(employees[3]);
            projects[1].AddEmployee(employees[1]);
            projects[1].AddEmployee(employees[2]);

            // ------------------------------------------------------------------------------------------- //
            // TODO: Liste der Mitarbeiter die im State WA wohnen. 

            //var queryWashington = ;


            Console.WriteLine("---------- \r\nListe der Mitarbeiter die im State WA wohnen");
            //queryWashington.ForEach(e => Console.WriteLine(e.Name));


            // ------------------------------------------------------------------------------------------- //
            // TODO: Liste der Namen und Adressen der Mitarbeiter im State WA. Sortiert nach Name absteigend. 

            //var queryWashingtonSorted = ;


            Console.WriteLine("---------- \r\nListe der Namen und Adressen der Mitarbeiter im State WA");
            //queryWashingtonSorted.ForEach(e => Console.WriteLine("Name: {0}, Phone: {1}", e.Name, e.Address));


            // ------------------------------------------------------------------------------------------- //
            // TODO: Liste der Department-Namen und der Anzahl Mitarbeiter der Departments.  

            //var queryDepartments = ;


            Console.WriteLine("---------- \r\nListe der Department-Namen und der Anzahl Mitarbeiter der Departments");
            //queryDepartments.ForEach(d => Console.WriteLine("Department: {0}, EmployeeCount: {1}", d.Department, d.EmployeeCount));


            // ------------------------------------------------------------------------------------------- //
            // TODO: Liste der Departments mit ihren Mitarbeitern. 
            // Ausgabe: Name des Departments, Name des Mitarbeiters
            // Sortiert nach Departmentname 

            //var empQuery = ;


            Console.WriteLine("---------- \r\nListe der Departments mit ihren Mitarbeitern");
            //empQuery.ForEach(c => Console.WriteLine("Name: {0}, Department: {1}", c.EmployeeName, c.DepartmentName));

            // ------------------------------------------------------------------------------------------- //
            // TODO: Liste der Departments mit dem Salär des bestverdienenden Mitarbeiters. 
            // Ausgabe: Name des Departments, höchster Salär
            // Sortiert nach höchstem Salär, absteigend 
            // Tipp: Verwenden Sie die „let“ Klausel für das Speichern von Zwischenresultaten.

            //var maxDeptSalary = ;


            Console.WriteLine("---------- \r\nListe der Departments mit dem Salär des bestverdienenden Mitarbeiters");
            //maxDeptSalary.ForEach(c => Console.WriteLine("Department: {0}, Höchster Salär: {1}", c.DepartmentName, c.MaxSalary));


            // ------------------------------------------------------------------------------------------- //
            // TODO: Liste der Projekte mir den zugeordneten Mitarbeitern  
            // Ausgabe: Name des Projektes, Name des Mitarbeiters
            // Sortiert nach Name des Projektes, Name des Mitarbeiters 

            // var projList = 


            Console.WriteLine("---------- \r\nListe der Projekte und der beteiligten Mitarbeiter");
            //projList.ForEach(p => Console.WriteLine("Projekt: {0} Mitarbeiter: {1}", p.Project, p.Employee));


            // ------------------------------------------------------------------------------------------- //
            // TODO: Projektstatistik: Liste der Projekte 
            // 
            // Ausgabe: Projektname, Name des Projektmanagers (falls nicht vorhanden "tba") , Anzahl Mitarbeiter im Projekt, 
            // Durchschnittliches Salaer der Mitarbeiter im Projekt
            // Sortiert nach Projektname, Anzahl Mitarbeiter

            //var projStatistics = 

            Console.WriteLine("---------- \r\nListe der Projekte und ihrer Statistik");
            //projStatistics.ForEach(p => Console.WriteLine("Project {0} Mgr {1} Number Employees {2} Average Salary {3}", p.Project, p.Mgr, p.EmpCount, p.AvgSalary));

            Console.ReadKey();
        }
    }
}