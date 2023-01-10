using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DeepClone
{
    public static class CloneHelper
    {
        public static T DeepClone<T>(T obj)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);

            stream.Position = 0;

            var clonedObject = (T)formatter.Deserialize(stream);

            return clonedObject;
        }
    }
}