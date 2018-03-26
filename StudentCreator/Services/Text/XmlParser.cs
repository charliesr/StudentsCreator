using StudentCreator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace StudentCreator.Services.Text
{
    public class XmlParser : IParser
    {
        public string FileExtension { get { return ".xml"; } }
        // Generado por vs
        //public string FileExtension => ".xml";

        public void AddToFile<T>(string filename, T value) where T : class
        {
            filename += FileExtension;
            var xmlSerializer = new XmlSerializer(typeof(List<T>));
            List<T> values = new List<T>();
            if (File.Exists(filename))
            {
                using (Stream reader = File.OpenRead(filename))
                {
                    values = xmlSerializer.Deserialize(reader) as List<T>;
                    reader.Close();
                }
            }
            values.Add(value);
            using (Stream writer = File.Open(filename, FileMode.OpenOrCreate, FileAccess.Write))
            {
                xmlSerializer.Serialize(writer, values);
                writer.Close();
            }
        }
    }
}