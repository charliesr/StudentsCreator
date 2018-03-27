using Newtonsoft.Json;
using StudentCreator.Models;
using StudentCreator.Services.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Xunit;

namespace StudentCreatorXUnitTests
{
    public class StudentRepositoryTests : IDisposable
    {
        public StudentRepositoryTests()
        {
            if (File.Exists("student.json")) File.Delete("student.json");
            if (File.Exists("student.xml")) File.Delete("student.xml");
            if (File.Exists("student.txt")) File.Delete("student.txt");
        }

        public void Dispose()
        {
            if (File.Exists("student.json")) File.Delete("student.json");
            if (File.Exists("student.xml")) File.Delete("student.xml");
            if (File.Exists("student.txt")) File.Delete("student.txt");
        }

        [Theory]
        [ClassData(typeof(StudentDataGenerator))]
        public void SerializerJsonTest(string filename, Student alumno)
        {
            var textSerializer = new FileWriter(new JsonFormat());
            textSerializer.Append(filename, alumno);
            filename += ".json";
            Assert.True(File.Exists(filename));
            var alumnoInFile = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(filename)).Where(a => a.GUID == alumno.GUID).First();
            Assert.Equal(alumnoInFile, alumno);
        }

        [Theory]
        [ClassData(typeof(StudentDataGenerator))]
        public void SerializerTxtTest(string filename, Student alumno)
        {
            var textSerializer = new FileWriter(new TxtFormat());
            textSerializer.Append(filename, alumno);
            filename += ".txt";
            Assert.True(File.Exists(filename));
            var txtString = File.ReadAllText(filename);
            var alumnoSplitted = txtString.Split(',');
            var alumnoInFile = new Student(Guid.Parse(alumnoSplitted.First()), Convert.ToInt32(alumnoSplitted[1]), alumnoSplitted[2], alumnoSplitted[3], alumnoSplitted.Last());
            Assert.Equal(alumno, alumnoInFile);
        }

        [Theory]
        [ClassData(typeof(StudentDataGenerator))]
        public void SerializerXmlTest(string filename, Student alumno)
        {
            var textSerializer = new FileWriter(new XmlFormat());
            textSerializer.Append(filename, alumno);
            filename += ".xml";
            Assert.True(File.Exists(filename));
            List<Student> alumnosInFile;
            Student alumnoInFile;
            using (Stream reader = File.OpenRead(filename))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<Student>));
                alumnosInFile = xmlSerializer.Deserialize(reader) as List<Student>;
                alumnoInFile = alumnosInFile.Where(a => a.GUID == alumno.GUID).First();
                reader.Close();
            }
            Assert.Equal(alumno,alumnoInFile);
        }


    }
}
