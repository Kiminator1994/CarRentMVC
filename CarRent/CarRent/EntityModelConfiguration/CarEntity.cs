using CarRent.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRent.EntityModelConfiguration
{
    public class CarEntity
    {
        public void GetCarEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().Property(car => car.Nr);
            modelBuilder.Entity<Car>().Property(car => car.ModelType);
            modelBuilder.Entity<Car>().Property(car => car.IsAvailable);
            modelBuilder.Entity<Car>().Property(car => car.Category);
            modelBuilder.Entity<Car>().Property(car => car.PictureUrl);
        }
    }
}
