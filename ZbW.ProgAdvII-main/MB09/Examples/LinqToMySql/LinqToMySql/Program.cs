using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Mapping;

namespace LinqToMySql {
    class Program {
        static void Main(string[] args) {
            // LINQtoDB: https://linq2db.github.io/

            //LinqToDB.Data.DataConnection.TurnTraceSwitchOn();
            //LinqToDB.Data.DataConnection.WriteTraceLine = (message, displayName) => { Console.WriteLine($"{message} {displayName}"); };

            using (var ctx = new LinqToDB.DataContext("SqlTeacherDb")) {

                var articles = ctx.GetTable<Article>();
                IQueryable<Article> articleQuery = articles.Where(p => p.Description.StartsWith("Millenium"));
                var sql = articleQuery.ToString();
                var ex = articleQuery.Expression;
                foreach (var a in articleQuery) {
                    Console.WriteLine($"Id={a.Id}, Description={a.Description}, NetPrice={a.NetPrice:N2}");
                }

                var articleExpr = from a in articles
                    where a.Description.StartsWith("Millenium")
                    select a;
                foreach (var a in articleExpr)
                {
                    Console.WriteLine($"Id={a.Id}, Description={a.Description}, NetPrice={a.NetPrice:N2}");
                }

                var manufacturers = ctx.GetTable<Manufacturer>();

                var query = articles.Join(manufacturers, a => a.ManufacturerId, m => m.Id, (a, m) => new {Article = a, Manufacturer = m}).Where(am => am.Article.Description.StartsWith("Millenium")).Select(am => am.Manufacturer);
                sql = query.ToString();
                ex = query.Expression;
                int manufacturerId = 0;
                foreach (var m in query) {
                    Console.WriteLine($"ManufacturerId={m.Id}, Name={m.Name}");
                    manufacturerId = m.Id;
                }


                var queryExpr =
                    from a in articles
                    join m in manufacturers on a.ManufacturerId equals m.Id
                    where a.Description.StartsWith("Millenium")
                    select new {Article = a, Manufacturer = m};

                foreach (var item in queryExpr) {
                    Console.WriteLine($"ArticleId={item.Article.Id}, ManufacturerId={item.Manufacturer.Id}, ManufacturerName={item.Manufacturer.Name}");
                }


                var article = new Article() {Id = 280, Description = "Testartikel", ManufacturerId = manufacturerId};
                ctx.Insert(article);

                article.Description = "Neue Bezeichnung";
                ctx.Update(article);
            }
        }
    }

    [Table("artikel")]
    public partial class Article {
        [Column("ARTIKELNR"), PrimaryKey, NotNull]
        public int Id { get; set; }

        [Column("BEZEICHNUNG")]
        public string Description { get; set; }

        [Column("NETTOPREIS")]
        public decimal NetPrice { get; set; }

        [Column("HERSTELLER")]
        public int ManufacturerId { get; set; }
    }

    [Table("hersteller")]
    public partial class Manufacturer {
        [Column("HERSTELLERNR"), PrimaryKey, NotNull]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }
    }
}