using StudentCreator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace StudentCreator.Helpers.Text
{
    public class XmlParser : IParser
    {
        public string FileExtension { get { return ".xml"; } }
        // Generado por vs
        //public string FileExtension => ".xml";

        public void AddToFile(string filename, Student student)
        {
            filename += FileExtension;
            var xmlSerializer = new XmlSerializer(typeof(List<Student>));
            List<Student> students = new List<Student>();
            if (File.Exists(filename))
            {
                using (Stream reader = File.OpenRead(filename))
                {
                    students = xmlSerializer.Deserialize(reader) as List<Student>;
                }
            }
            students.Add(student);
            using (Stream writer = File.Open(filename, FileMode.OpenOrCreate, FileAccess.Write))
            {
                xmlSerializer.Serialize(writer, students);
            }
        }
    }
}