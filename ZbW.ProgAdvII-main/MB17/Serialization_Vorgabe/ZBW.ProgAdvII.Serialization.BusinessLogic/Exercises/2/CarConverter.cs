using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using ZBW.ProgAdvII.Serialization.BusinessLogic.Exercises._1;
using ZBW.ProgAdvII.Serialization.BusinessLogic.GarageDtos;

namespace ZBW.ProgAdvII.Serialization.BusinessLogic.Exercises._2
{
    public class CarConverter : JsonConverter<Truck>
    {
        public override Truck? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Truck truck, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            JsonSerializer.Serialize(writer, (Car)truck, options);
            
            writer.WritePropertyName("truck");
            writer.WriteStartObject();
            writer.WriteNumber("loadCapacity", truck.LoadCapacityInKg);
            writer.WriteEndObject();

            writer.WriteEndObject();

        }
    }
    
    
}