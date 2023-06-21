using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Backend.EntityModelConfiguration;
using Microsoft.IdentityModel.Protocols;

namespace Backend.NewFolder
{
    public class DataContext : DbContext
    {
        private DbSet<Customer> customers;
        private DbSet<Car> cars;
        private DbSet<CarClass> carClasses;
        private DbSet<Reservation> reservations;
        private DbSet<RentalContract> rentalContracts;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = Koneko\\KONEKO; Database = CarRentDB; Trusted_Connection = True; Encrypt = false;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CarClassEntity().GetReservationEntity(modelBuilder);
            new CarEntity().GetCarEntity(modelBuilder);
            new CustomerEntity().GetCustomerEntity(modelBuilder);
            new RentalContractEntity().GetRentalContractEntity(modelBuilder);
            new ReservationEntity().GetReservationEntity(modelBuilder);
        }

    }
}
