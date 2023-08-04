using CarRent.EntityModelConfiguration;
using CarRent.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Car>? Cars { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<RentalContract>? RentalContracts { get; set; }
        public DbSet<Reservation>? Reservations { get; set; }

        public IConfiguration? Configuration { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)        
        {
            Configuration = new ConfigurationManager();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-1470VE0\\ZBW; Initial Catalog = CarRentDb; Trusted_Connection = True; Encrypt = false; Integrated Security = True; Pooling = False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CarEntity().GetCarEntity(modelBuilder);
            new CustomerEntity().GetCustomerEntity(modelBuilder);
            new RentalContractEntity().GetRentalContractEntity(modelBuilder);
            new ReservationEntity().GetReservationEntity(modelBuilder);
        }
    }
}
