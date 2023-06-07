using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using ZBW.ProgAdvII.Serialization.BusinessLogic.GarageDtos;

namespace ZBW.ProgAdvII.Serialization.BusinessLogic.Exercises._2
{
    public class Exercise2 : IExercise
    {
        public int GetNumber()
        {
            return 2;
        }

        public string GetDescription()
        {
            return "JSON Serialisierung";
        }

        public ExerciseResult Execute()
        {
            var garage = DemoGarageCreator.CreateGarage();

            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                Converters = { new CarConverter()}

            };
            
            var serializedJson = JsonSerializer.Serialize(garage, options);
            var expectedJson = File.ReadAllText("Exercises/2/garageJson.json");

            serializedJson = serializedJson.Replace("\r\n", "\n");
            expectedJson = expectedJson.Replace("\r\n", "\n");

            if (expectedJson == serializedJson)
            {
                return new ExerciseResult(true, "");
            }
            else
            {
                return new ExerciseResult(false, "Serialisierung entspricht nicht der Erwartung");
            }
        }
        
    }
}