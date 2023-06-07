using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace ZBW.ProgAdvII.Serialization.BusinessLogic.GarageDtos
{
    public class Garage
    {
        public int GarageNumber { get; set; }
        public Address Address { get; set; }
        public List<Car> Cars { get; set; }
    }
}