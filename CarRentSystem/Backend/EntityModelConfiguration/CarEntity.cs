using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.EntityModelConfiguration
{
    internal class CarEntity
    {
        public void GetCarEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().Property(car => car.Nr);
            modelBuilder.Entity<Car>().Property(car => car.Brand);
            modelBuilder.Entity<Car>().Property(car => car.Typ);
            modelBuilder.Entity<Car>().HasOne(car => car.CarClass).WithMany(carClass => carClass.Cars);
            modelBuilder.Entity<Car>().Property(car => car.IsAvailable);
        }
    }
}
