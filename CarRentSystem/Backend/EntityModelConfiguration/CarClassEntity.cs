using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.EntityModelConfiguration
{
    internal class CarClassEntity
    {
        public void GetReservationEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarClass>().Property(carClass => carClass.DailyFee).HasColumnType("decimal(18,2)");
        }
    }
}
