using StudentCreator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace StudentCreator.Services.Text
{
    public class XmlFormat : IFormat
    {
        public string StringPointer { get; }

        public XmlFormat(string stringPointer)
        {
            StringPointer = stringPointer;
        }
        public void Add<T>(T value) where T : class
        {
            var xmlSerializer = new XmlSerializer(typeof(List<T>));
            List<T> values = new List<T>();
            if (File.Exists(StringPointer))
            {
                using (Stream reader = File.OpenRead(StringPointer))
                {
                    values = xmlSerializer.Deserialize(reader) as List<T>;
                    reader.Close();
                }
            }
            values.Add(value);
            using (Stream writer = File.Open(StringPointer, FileMode.OpenOrCreate, FileAccess.Write))
            {
                xmlSerializer.Serialize(writer, values);
                writer.Close();
            }
        }
    }
}