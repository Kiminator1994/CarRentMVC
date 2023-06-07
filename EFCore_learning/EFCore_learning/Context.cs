using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCore_learning
{
    public class Context : DbContext
    {
        private DbSet<Customer> customers;
        private DbSet<Order> orders;
        private string connString = "Server=Koneko\\KONEKO;Database=EFTest;Trusted_Connection=True; Encrypt=false;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(c => c.Name);
            modelBuilder.Entity<Customer>().Property(c => c.Address);
            modelBuilder.Entity<Customer>().Property(c => c.City);
            modelBuilder.Entity<Customer>().Property(c => c.Country);
            modelBuilder.Entity<Customer>().Property(c => c.Fax);
            modelBuilder.Entity<Customer>().Property(c => c.Phone);
            modelBuilder.Entity<Customer>().Property(c => c.PostalCode);
            modelBuilder.Entity<Customer>().Property(c => c.Region);
            modelBuilder.Entity<Customer>().HasMany(c => c.Orders).WithOne(o => o.Customer).HasForeignKey(o => o.CustomerId);
            modelBuilder.Entity<Order>().Property(o => o.Name);
            modelBuilder.Entity<Order>().Property(o => o.Description);
            modelBuilder.Entity<Order>().Property(o => o.CustomerId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
