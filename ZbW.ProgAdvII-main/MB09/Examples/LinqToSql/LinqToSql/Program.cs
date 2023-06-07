using System;
using System.Data.Linq;  // Reference System.Data.Linq
using System.Linq;
using System.Data.Linq.Mapping;
using System.Data.Linq.SqlClient;

namespace LinqToSql{
    class Program{
        static void Main(string[] args) {
            // https://docs.microsoft.com/en-us/sql/samples/adventureworks-install-configure?view=sql-server-2017
            using (var ctx = new DataContext(@"Data Source=.;Initial Catalog=AdventureWorks2016;Trusted_Connection=True;")) {
                ctx.Log = Console.Out;





                var persons = ctx.GetTable<Person>();
                var emails = ctx.GetTable<Email>();

                var g = from p in persons
                    group p.Firstname by p.Lastname;
                // N+1 Select Problem
                foreach (var p in g) {
                    Console.WriteLine(p.Key);
                    foreach (var item in p) {
                        Console.WriteLine(item);
                    }
                }




                foreach (var p in g) {
                    Console.WriteLine(p.Key);
                    foreach (var item in p) {
                        Console.WriteLine(item);
                    }
                }

                var g1 = from p in persons
                    group p.Firstname by p.Lastname into gr
                        select new {
                            Key = gr.Key,
                            N = gr.Count()
                        };
                foreach (var p in g1) {
                    Console.WriteLine(p.Key + ": " + p.N);

                }

                // **** Queries with Extensionmethods ****
                IQueryable<Person> persQuery = persons.Where(p => p.Firstname == "Rob");
                var sql = persQuery.ToString();
                var ex = persQuery.Expression;
                foreach (var p in persQuery) {
                    Console.WriteLine($"ID={p.ID}, FirstName={p.Firstname}, LastName={p.Lastname}");
                }





                persQuery = persons.Where(p => p.Lastname.Contains("row"));
                sql = persQuery.ToString();
                ex = persQuery.Expression;
                foreach (var p in persQuery) {
                    Console.WriteLine($"ID={p.ID}, FirstName={p.Firstname}, LastName={p.Lastname}");
                }

                //var query = persons.Join(emails, p => p.ID, e => e.PersonID, (p, e) => new {Person = p, Email = e}).Where(pe => pe.Person.Lastname.Contains("row")).Select(pe => pe.Email);
                var query = persons.Join(emails, p => p.ID, e => e.PersonID, (p, e) => new {Person = p, Email = e}).Where(pe => pe.Person.Lastname.StartsWith("Walt")).Select(pe => pe.Email);
                sql = query.ToString();
                ex = query.Expression;
                int personId = 0;
                foreach (var e in query) {
                    Console.WriteLine($"ID={e.ID}, PersonID={e.PersonID}, Address={e.Address}");
                    personId = e.PersonID;
                }


                // **** Insert / Update ****
                var mail = new Email() {PersonID = personId, Address = "t.kehl@symas-design.ch"};
                emails.InsertOnSubmit(mail);
                ctx.SubmitChanges();
                Console.WriteLine($"ID: {mail.ID}");
                mail.Address += "x";
                ctx.SubmitChanges();














                // **** Queries with Query Expressions ****
                persQuery = from p in persons where p.Firstname == "Rob" select p;
                sql = persQuery.ToString();

                foreach (var p in persQuery) {
                    Console.WriteLine($"ID={p.ID}, FirstName={p.Firstname}, LastName={p.Lastname}");
                }

                persQuery = from p in persons where SqlMethods.Like(p.Lastname, "Walt%") select p;
                foreach (var p in persQuery) {
                    Console.WriteLine($"ID={p.ID}, FirstName={p.Firstname}, LastName={p.Lastname}");
                }

                Console.ReadLine();
            }
        }
    }


    [Table(Name = "Person.Person")] // needs: using System.Data.Linq.Mapping;
    public class Person{
        [Column(IsPrimaryKey = true, Name = "BusinessEntityID")]
        public int ID { get; set; }

        [Column(Name = "FirstName")]
        public string Firstname { get; set; }

        [Column(Name = "LastName")]
        public string Lastname { get; set; }
    }


    [Table(Name = "Person.EmailAddress")] // needs: using System.Data.Linq.Mapping;
    public class Email {
        [Column(IsPrimaryKey = true, Name = "BusinessEntityID")]
        public int PersonID { get; set; }
      
        [Column(IsPrimaryKey = true, Name = "EmailAddressID", IsDbGenerated = true)]
        public int ID { get; set; }

        [Column(Name = "EmailAddress")]
        public string Address { get; set; }

        [Column(Name = "RowGuid", IsDbGenerated = true)]
        public Guid RowGuid { get; set; }

        [Column(Name = "ModifiedDate", IsDbGenerated = true)]
        public DateTime ModifiedAt { get; set; }
    }
}




