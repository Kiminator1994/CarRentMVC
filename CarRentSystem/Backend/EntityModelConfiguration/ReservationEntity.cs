using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.EntityModelConfiguration
{
    internal class ReservationEntity
    {
        public void GetReservationEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().Property(res => res.Nr);
            modelBuilder.Entity<Reservation>().Property(res => res.Days);
            modelBuilder.Entity<Reservation>().Property(res => res.TotalFee).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Reservation>().HasOne(res => res.Customer).WithMany(customer => customer.Reservations);

        }
    }
}
