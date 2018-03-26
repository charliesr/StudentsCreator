using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace StudentCreator.Services.Text
{
    public class JsonParser : IParser
    {
        public string FileExtension { get { return ".json"; } }
        // Generado por vs
        //public string FileExtension => ".json";

        public void AddToFile<T>(string filename, T value) where T : class
        {
            filename += FileExtension;
            var values = File.Exists(filename) ? JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(filename)) : new List<T>();
            values.Add(value);
            File.WriteAllText(filename, JsonConvert.SerializeObject(values));
        }

    }
}