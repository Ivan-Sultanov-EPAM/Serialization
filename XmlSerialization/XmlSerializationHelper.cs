using System;
using System.IO;
using System.Xml.Serialization;

namespace XmlSerialization
{
    public static class XmlSerializationHelper
    {
        public static void Serialize(string path, object obj)
        {
            var writer = new XmlSerializer(typeof(Department));

            var file = File.Create(path);

            writer.Serialize(file, obj);
            file.Close();
        }

        public static TEntity Deserialize<TEntity>(string path)
        {
            var reader = new XmlSerializer(typeof(TEntity));
            var file = new StreamReader(Environment.CurrentDirectory + "//DepartmentXml.xml");

            var result = (TEntity)reader.Deserialize(file);

            file.Close();

            return result;
        }
    }
}