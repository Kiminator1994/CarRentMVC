using CarRent.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRent.EntityModelConfiguration
{
    public class CustomerEntity
    {

        public void GetCustomerEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(cus => cus.Nr);
            modelBuilder.Entity<Customer>().Property(cus => cus.FirstName);
            modelBuilder.Entity<Customer>().Property(cus => cus.LastName);
            modelBuilder.Entity<Customer>().Property(cus => cus.Address);
            modelBuilder.Entity<Customer>().Property(cus => cus.City);
           
        }
    }
}
