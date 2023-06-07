using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace ZBW.ProgAdvII.Serialization.BusinessLogic.GarageDtos
{
    public class Car
    {
        public Manufacturer Manufacturer { get; set; }

        public DateTime ManufacturerDate { get; set; }

        public int MaximumSpeed { get; set; }
    }
}