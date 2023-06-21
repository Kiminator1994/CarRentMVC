using CarRent.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRent.EntityModelConfiguration
{
    public class RentalContractEntity
    {
        public void GetRentalContractEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentalContract>().Property(ren => ren.Nr);
            modelBuilder.Entity<RentalContract>().Property(ren => ren.StartDate);
            modelBuilder.Entity<RentalContract>().Property(ren => ren.EndDate);
            modelBuilder.Entity<RentalContract>().Property(ren => ren.TotalFee).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<RentalContract>().Property(ren => ren.ReservationId);
            modelBuilder.Entity<RentalContract>().HasOne(ren => ren.Reservation).WithOne(res => res.RentalContract);
        }
    }
}
