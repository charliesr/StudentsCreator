using Newtonsoft.Json;
using StudentCreator;
using StudentCreator.Models;
using StudentCreator.Services.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Xunit;

namespace StudentCreatorXUnitTests
{
    public class StudentRepositoryTests : IDisposable
    {
        private string stringPointer;

        public StudentRepositoryTests()
        {
            stringPointer = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\student";
            if (File.Exists(stringPointer + ".json")) File.Delete(stringPointer + ".json");
            if (File.Exists(stringPointer + ".xml")) File.Delete(stringPointer + ".xml");
            if (File.Exists(stringPointer + ".txt")) File.Delete(stringPointer + ".txt");
        }

        public void Dispose()
        {
            if (File.Exists(stringPointer + ".json")) File.Delete(stringPointer + ".json");
            if (File.Exists(stringPointer + ".xml")) File.Delete(stringPointer + ".xml");
            if (File.Exists(stringPointer + ".txt")) File.Delete(stringPointer + ".txt");
        }

        [Theory]
        [ClassData(typeof(StudentDataGenerator))]
        public void AddInJsonTest(Student alumno)
        {
            var jsonFormat = FormatFactory.CreateFormat(Enums.TipoArchivo.json, stringPointer);
            jsonFormat.Add(alumno);
            stringPointer += ".json";
            Assert.True(File.Exists(stringPointer));
            var alumnoInFile = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(stringPointer)).Where(a => a.GUID == alumno.GUID).First();
            Assert.Equal(alumnoInFile, alumno);
        }

        [Theory]
        [ClassData(typeof(StudentDataGenerator))]
        public void AddInTxtTest(Student alumno)
        {
            var txtFormat = FormatFactory.CreateFormat(Enums.TipoArchivo.txt, stringPointer);
            txtFormat.Add(alumno);
            stringPointer += ".txt";
            Assert.True(File.Exists(stringPointer));
            var txtString = File.ReadAllText(stringPointer);
            var alumnoSplitted = txtString.Split(',');
            var alumnoInFile = new Student(Guid.Parse(alumnoSplitted.First()), Convert.ToInt32(alumnoSplitted[1]), alumnoSplitted[2], alumnoSplitted[3], alumnoSplitted.Last());
            Assert.Equal(alumno, alumnoInFile);
        }

        [Theory]
        [ClassData(typeof(StudentDataGenerator))]
        public void AddInXmlTest(Student alumno)
        {
            var xmlFormat = FormatFactory.CreateFormat(Enums.TipoArchivo.xml, stringPointer);
            xmlFormat.Add(alumno);
            stringPointer += ".xml";
            Assert.True(File.Exists(stringPointer));
            List<Student> alumnosInFile;
            Student alumnoInFile;
            using (Stream reader = File.OpenRead(stringPointer))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<Student>));
                alumnosInFile = xmlSerializer.Deserialize(reader) as List<Student>;
                alumnoInFile = alumnosInFile.Where(a => a.GUID == alumno.GUID).First();
            }
            Assert.Equal(alumno,alumnoInFile);
        }


    }
}
