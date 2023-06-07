using System;
using System.Collections.Generic;

namespace ZBW.ProgAdvII.Serialization.BusinessLogic.GarageDtos
{
    public class DemoGarageCreator
    {
        public static Garage CreateGarage()
        {
            var garage = new Garage
            {
                Address = new Address
                {
                    City = "St. Gallen",
                    PostalCode = 9000,
                    Street = "Gaiserwaldstrasse",
                    HouseNumber = 13
                },
                GarageNumber = 88796,
                Cars = new List<Car>
                {
                    new Car
                    {
                        Manufacturer = Manufacturer.Ford,
                        ManufacturerDate = new DateTime(1967, 2, 22),
                        MaximumSpeed = 322
                    },
                    new Car
                    {
                        Manufacturer = Manufacturer.Toyota,
                        ManufacturerDate = new DateTime(2012, 2, 20),
                        MaximumSpeed = 120
                    },
                    new Truck
                    {
                        Manufacturer = Manufacturer.Landrover,
                        ManufacturerDate = new DateTime(2020, 12, 12),
                        MaximumSpeed = 200,
                        LoadCapacityInKg = 570.5
                    }
                }
            };
            return garage;
        }
    }
}