using CarRent.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRent.EntityModelConfiguration
{
    public class ReservationEntity
    {
        public void GetReservationEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().Property(res => res.Nr);
            modelBuilder.Entity<Reservation>().Property(res => res.StartDate);
            modelBuilder.Entity<Reservation>().Property(res => res.EndDate);
            modelBuilder.Entity<Reservation>().Property(res => res.TotalFee).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Reservation>().HasOne(res => res.Customer).WithMany(cus => cus.Reservations);
            modelBuilder.Entity<Reservation>().HasOne(res => res.Car).WithMany(car => car.Reservations);
        }
    }
}
