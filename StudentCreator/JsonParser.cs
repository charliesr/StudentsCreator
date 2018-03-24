using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace StudentCreator
{
    public class JsonParser : BaseParser
    {
        public override void Append(string filename, Student student)
        {
            filename += ".json";
            var students = File.Exists(filename) ? JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(filename)) : new List<Student>();
            students.Add(student);
            File.WriteAllText(filename, JsonConvert.SerializeObject(students));
        }
    }
}