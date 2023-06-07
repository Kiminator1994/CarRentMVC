using System;
using System.IO;

namespace ZBW.ProgAdvII.Serialization.BusinessLogic.Exercises._1
{
    public class Exercise1 : IExercise
    {
        public int GetNumber()
        {
            return 1;
        }

        public string GetDescription()
        {
            return "ZBW Serializer";
        }

        public ExerciseResult Execute()
        {
            var student = new Student()
            {
                FirstName = "Karl",
                LastName = "der Grosse",
                DateOfBirth = new DateTime(748, 4, 2)
            };

            var serializer = new ZbwSerializer();

            try
            {
                var inMemoryStorage = new MemoryStream();
                serializer.Serialize(student, inMemoryStorage);
                inMemoryStorage.Seek(0, SeekOrigin.Begin);
                var deserializedStudent = serializer.Deserialize(inMemoryStorage);

                if (student.Equals(deserializedStudent))
                {
                    return new ExerciseResult(true, "");
                }
                else
                {
                    return new ExerciseResult(false, "Serialisierung & Deserialisierung stimmen nicht überein");
                }
            }
            catch (Exception)
            {
                return new ExerciseResult(false, "Serialisierung nicht möglich");
            }

        }
    }
}