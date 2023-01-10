using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CustomBinarySerialization
{
    public static class CustomBinarySerializationHelper
    {
        private static IFormatter formatter;

        static CustomBinarySerializationHelper()
        {
            formatter = new BinaryFormatter();
        }

        public static void Serialize(string fileName, object obj)
        {
            var s = new FileStream(fileName, FileMode.Create);
            formatter.Serialize(s, obj);
            s.Close();
        }

        public static TEntity Deserialize<TEntity>(string fileName)
        {
            var s = new FileStream(fileName, FileMode.Open);
            var result = (TEntity)formatter.Deserialize(s);

            return result;
        }
    }
}