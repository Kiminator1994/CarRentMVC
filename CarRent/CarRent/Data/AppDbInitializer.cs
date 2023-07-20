using CarRent.Models;
namespace CarRent.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context?.Database.EnsureCreated();

                if (!context.Cars.Any())
                {
                    context.Cars.AddRange(new List<Car>()
                    {
                        new Car()
                        {

                            Description = "The Toyota Supra: A legendary sports car celebrated for its thrilling driving experience and iconic status. Powered by a turbocharged inline-six engine, it boasts impressive power and agility. Its aerodynamic design exudes confidence and style, making a bold statement on the road. With a heritage of performance and innovation, the Toyota Supra has earned its place as a symbol of automotive enthusiasts' passion and excitement.",
                            PictureUrl = "https://images.pexels.com/photos/3874337/pexels-photo-3874337.jpeg?auto=compress&cs=tinysrgb&w=1600",
                            Nr = 1,
                            IsAvailable = true,
                            Category = CarCategory.Medium,
                            ModelType = "Supra",
                            Brand = "Toyota"
                        },
                        new Car()
                        {
                            Description = "The Honda Civic: An enduring symbol of reliability and practicality. Renowned for its fuel efficiency and comfortable ride, the Honda Civic has been a favorite among drivers worldwide. With a spacious interior and modern features, it offers a delightful driving experience for daily commuting and long journeys alike. Its strong safety record and affordable maintenance make it a popular choice for families and individuals seeking a dependable and economical vehicle. The Honda Civic continues to be a timeless and trusted companion on the roads.",
                            PictureUrl = "https://images.pexels.com/photos/16475132/pexels-photo-16475132/free-photo-of-in-this-captivating-image-a-sleek-grey-honda-civic-type-r-10th-generation-stands-boldly-in-front-of-an-abandoned-warehouse-creating-a-striking-visual-contrast-the-car-s-aggressive-styli.jpeg?auto=compress&cs=tinysrgb&w=1600",
                            Nr = 2,
                            IsAvailable = true,
                            Category = CarCategory.Simple,
                            ModelType = "Civic",
                            Brand = "Honda"
                        },
                        new Car()
                        {
                            Description = "The Ford Focus: A versatile and agile compact car that strikes a perfect balance between performance and practicality. With its sleek design and dynamic handling, the Ford Focus delivers an engaging driving experience. Whether you're navigating city streets or embarking on a road trip, the Focus offers a comfortable and smooth ride for both drivers and passengers. Equipped with advanced technology and safety features, it ensures a modern driving experience with peace of mind. As a popular choice among car enthusiasts, the Ford Focus remains a reliable and stylish option in the competitive compact car segment.",
                            PictureUrl = "https://images.pexels.com/photos/12736948/pexels-photo-12736948.jpeg?auto=compress&cs=tinysrgb&w=1600",
                            Nr = 3,
                            IsAvailable = true,
                            Category = CarCategory.Simple,
                            ModelType = "Focus",
                            Brand = "Ford"
                        },
                        new Car()
                        {
                            Description = "The C7 Corvette: An iconic American sports car that embodies power and precision. With its striking and aerodynamic design, the C7 Corvette commands attention on the road. Beneath the hood, a potent V8 engine roars to life, unleashing exhilarating performance and impressive acceleration. The C7 Corvette's agile handling and responsive steering make every twist and turn on the road a thrilling experience. Inside, the driver-focused cockpit offers comfort and convenience, blending technology and luxury seamlessly. As a symbol of American automotive excellence, the C7 Corvette continues to captivate enthusiasts and drivers alike with its timeless charm and legendary performance.",
                            PictureUrl = "https://images.pexels.com/photos/358070/pexels-photo-358070.jpeg?auto=compress&cs=tinysrgb&w=1600",
                            Nr = 4,
                            IsAvailable = false,
                            Category = CarCategory.Luxury,
                            ModelType = "C7",
                            Brand = "Corvette"
                        },
                        new Car()
                        {
                            Description = "The Ferrari 458: An exquisite Italian sports car renowned for its dynamic performance and timeless beauty. Equipped with a V8 engine, it delivers a harmonious blend of speed and precision. Its sleek, sculpted body showcases Ferrari's iconic design language, capturing the essence of luxury and speed. The Ferrari 458 stands as a symbol of automotive excellence, captivating hearts with its captivating presence.",
                            PictureUrl = "https://images.pexels.com/photos/15085608/pexels-photo-15085608/free-photo-of-ferrari-458-gt3.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            Nr = 5,
                            IsAvailable = false,
                            Category = CarCategory.Luxury,
                            ModelType = "458",
                            Brand = "Ferrari"
                        },
                        new Car()
                        {
                            Description = "The Lamborghini Aventador is an exquisite Italian supercar renowned for its breathtaking performance and striking design. With its powerful V12 engine, jaw-dropping acceleration, and cutting-edge technology, the Aventador represents the pinnacle of automotive engineering. Its aggressive and aerodynamic styling captivates enthusiasts worldwide, making it an icon in the realm of high-performance automobiles. Unleashing the Aventador on the open road is an exhilarating experience that embodies the spirit of automotive passion and excellence.",
                            PictureUrl = "https://images.pexels.com/photos/14785978/pexels-photo-14785978.jpeg?auto=compress&cs=tinysrgb&w=1600",
                            Nr = 6,
                            IsAvailable = false,
                            Category = CarCategory.Luxury,
                            ModelType = "Aventador",
                            Brand = "Lamborghini"
                        }
                    });
                    context.SaveChanges();
                }


                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(new List<Customer>()
                    {
                       new Customer()
                       {

                           FirstName = "Kim",
                           LastName = "Devaux",
                           Address = "Bahnhofstrasse 6",
                           City = "Elgg",
                           Nr = 1
                       }
                    });
                    context.SaveChanges();
                }

                if (!context.Reservations.Any())
                {
                    context.Reservations.AddRange(new List<Reservation>()
                    {
                        new Reservation()
                        {

                            Nr = 1,
                            CarId = 1,
                            CustomerId = 1,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(5),
                            TotalFee = (decimal)CarCategory.Simple
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.RentalContracts.Any())
                {
                    context.RentalContracts.AddRange(new List<RentalContract>()
                    {
                        new RentalContract()
                        {
                            Nr = 1,
                            ReservationId = 1,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(5),
                            TotalFee = (decimal)CarCategory.Simple
                        }
                    });
                    context.SaveChanges();
                }

            }
        }
    }
}
