using System.IO;
using System.Xml.Serialization;
using ZBW.ProgAdvII.Serialization.BusinessLogic.GarageDtos;

namespace ZBW.ProgAdvII.Serialization.BusinessLogic.Exercises._3
{
    public class Exercise3 : IExercise
    {
        public int GetNumber()
        {
            return 3;
        }

        public string GetDescription()
        {
            return "XML Serialisierung";
        }

        public ExerciseResult Execute()
        {
            var garage = DemoGarageCreator.CreateGarage();
            var serializer = new XmlSerializer(typeof(Garage));
            var writer = new StringWriter();
            serializer.Serialize(writer, garage);
            var serializedXml = writer.ToString();

            var expectedXml = File.ReadAllText("Exercises/3/garageXml.xml");

            serializedXml = serializedXml.Replace("\r\n", "\n");
            expectedXml = expectedXml.Replace("\r\n", "\n");

            if (expectedXml == serializedXml)
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