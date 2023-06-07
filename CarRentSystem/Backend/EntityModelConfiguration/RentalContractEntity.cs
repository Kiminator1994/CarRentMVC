using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.EntityModelConfiguration
{
    internal class RentalContractEntity
    {
        public void GetRentalContractEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentalContract>().Property(ren => ren.Nr);
            modelBuilder.Entity<RentalContract>().Property(ren => ren.Days);
            modelBuilder.Entity<RentalContract>().Property(ren => ren.TotalFee).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<RentalContract>().HasOne(ren => ren.Reservation).WithOne(res => res.RentalContract).HasForeignKey<RentalContract>(ren => ren.ReservationId);
        }
    }
}
