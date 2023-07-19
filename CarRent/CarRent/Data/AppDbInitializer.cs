using CarRent.Models;
namespace CarRent.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

        //        context?.Database.EnsureCreated();

        //        if (!context.Cars.Any())
        //        {
        //            context.Cars.AddRange(new List<Car>()
        //            {
        //                new Car()
        //                {
                           
        //                    Description = "Cool Car",
        //                    PictureUrl = "https://images.pexels.com/photos/3874337/pexels-photo-3874337.jpeg?auto=compress&cs=tinysrgb&w=1600",
        //                    Nr = 1000,
        //                    IsAvailable = true,
        //                    Category = CarCategory.Simple,
        //                    ModelType = "Supra",
        //                    Brand = "Toyota"
        //                },
        //                new Car()
        //                {
        //                    Description = "Nice Car",
        //                    PictureUrl = "https://images.pexels.com/photos/16475132/pexels-photo-16475132/free-photo-of-in-this-captivating-image-a-sleek-grey-honda-civic-type-r-10th-generation-stands-boldly-in-front-of-an-abandoned-warehouse-creating-a-striking-visual-contrast-the-car-s-aggressive-styli.jpeg?auto=compress&cs=tinysrgb&w=1600",
        //                    Nr = 1001,
        //                    IsAvailable = true,
        //                    Category = CarCategory.Luxury,
        //                    ModelType = "Civic",
        //                    Brand = "Honda"
        //                },
        //                new Car()
        //                {
        //                    Description = "Fancy Car",
        //                    PictureUrl = "https://images.pexels.com/photos/12736948/pexels-photo-12736948.jpeg?auto=compress&cs=tinysrgb&w=1600",
        //                    Nr = 1002,
        //                    IsAvailable = true,
        //                    Category = CarCategory.Medium,
        //                    ModelType = "Focus",
        //                    Brand = "Ford"
        //                },
        //                new Car()
        //                {
        //                    Description = "Hot Car",
        //                    PictureUrl = "https://images.pexels.com/photos/358070/pexels-photo-358070.jpeg?auto=compress&cs=tinysrgb&w=1600",
        //                    Nr = 1003,
        //                    IsAvailable = false,
        //                    Category = CarCategory.Luxury,
        //                    ModelType = "C7",
        //                    Brand = "Corvette"
        //                }
        //            });
        //            context.SaveChanges();
        //        }


        //        if (!context.Customers.Any())
        //        {
        //            context.Customers.AddRange(new List<Customer>()
        //            {
        //               new Customer()
        //               {
                           
        //                   FirstName = "Kim",
        //                   LastName = "Devaux",
        //                   Address = "Bahnhofstrasse 6",
        //                   City = "Elgg",
        //                   Nr = 1000
        //               }
        //            });
        //            context.SaveChanges();
        //        }

        //        if (!context.Reservations.Any())
        //        {
        //            context.Reservations.AddRange(new List<Reservation>()
        //            {
        //                new Reservation()
        //                {
                            
        //                    Nr = 1,
        //                    CarId = 1,
        //                    CustomerId = 1,
        //                    StartDate = DateTime.Now,
        //                    EndDate = DateTime.Now.AddDays(5),
        //                    TotalFee = (decimal)CarCategory.Simple
        //                }
        //            });
        //            context.SaveChanges();
        //        }

        //        if (!context.RentalContracts.Any())
        //        {
        //            context.RentalContracts.AddRange(new List<RentalContract>()
        //            {
        //                new RentalContract()
        //                {
        //                    Nr = 1,
        //                    ReservationId = 1,
        //                    StartDate = DateTime.Now,
        //                    EndDate = DateTime.Now.AddDays(5),
        //                    TotalFee = (decimal)CarCategory.Simple
        //                }
        //            });
        //            context.SaveChanges();
        //        }

        //    }
        }
    }
}
