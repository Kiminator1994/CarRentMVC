using System.Xml.Serialization;

namespace ZBW.ProgAdvII.Serialization.BusinessLogic.GarageDtos
{
    public class Address
    {
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
    }
}