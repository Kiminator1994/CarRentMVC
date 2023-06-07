using System.IO;
using ZBW.ProgAdvII.Serialization.BusinessLogic.Exercises._1;

namespace ZBW.ProgAdvII.Serialization.BusinessLogic
{
    public interface ISerializer
    {
        void Serialize(Student student, Stream stream);

        Student Deserialize(Stream stream);
    }
}