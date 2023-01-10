using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerialization
{
    public static class BinarySerializationHelper
    {
        public static void Serialize(string path, object obj)
        {
            var fs = new FileStream(path, FileMode.Create);
            var formatter = new BinaryFormatter();

            try
            {
                formatter.Serialize(fs, obj);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        public static TEntity Deserialize<TEntity>(string path)
        {
            TEntity newObject;

            var fs = new FileStream(path, FileMode.Open);

            try
            {
                var formatter = new BinaryFormatter();

                newObject = (TEntity)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            return newObject;
        }
    }
}