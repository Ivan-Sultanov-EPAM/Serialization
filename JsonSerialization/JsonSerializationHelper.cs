using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace JsonSerialization
{
    public static class JsonSerializationHelper
    {
        public static void Serialize(string path, object obj)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };

            var departmentJson = JsonSerializer.Serialize(obj, options);

            File.WriteAllText(path, departmentJson);
        }

        public static TEntity Deserialize<TEntity>(string path)
        {
            var file = File.ReadAllBytes(path);
            return JsonSerializer.Deserialize<TEntity>(file);
        }
    }
}