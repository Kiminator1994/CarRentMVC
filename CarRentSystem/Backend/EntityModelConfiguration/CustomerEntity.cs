using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.EntityModelConfiguration
{
    internal class CustomerEntity
    {
        public void GetCustomerEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(customer => customer.Nr);
            modelBuilder.Entity<Customer>().Property(customer => customer.Address);
            modelBuilder.Entity<Customer>().Property(customer => customer.City);
            modelBuilder.Entity<Customer>().Property(customer => customer.FirstName);
            modelBuilder.Entity<Customer>().Property(customer => customer.LastName);
        }
    }
}
