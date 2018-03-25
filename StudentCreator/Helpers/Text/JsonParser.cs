using Newtonsoft.Json;
using StudentCreator.Models;
using System.Collections.Generic;
using System.IO;

namespace StudentCreator.Helpers.Text
{
    public class JsonParser : IParser
    {
        public void AddToFile(string filename, Student student)
        {
            filename += ".json";
            var students = File.Exists(filename) ? JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(filename)) : new List<Student>();
            students.Add(student);
            File.WriteAllText(filename, JsonConvert.SerializeObject(students));
        }

    }
}