using StudentCreator.Helpers;
using StudentCreator.Helpers.Text;
using StudentCreator.Models;
using StudentCreator.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Collections;
using StudentCreator;
using Newtonsoft.Json;
using System.IO;

namespace StudentCreatorXUnitTests
{
    public class TestDataGenerator : IEnumerable<object[]>
    {

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {"student", new Student {
                ID = 1,
                Nombre = "Carlos",
                Apellidos = "Sanchez Romero",
                DNI = "54545454F"
                }
            },
            new object[] {"student", new Student {
                ID = 1,
                Nombre = "Carlos2",
                Apellidos = "Sanchez2",
                DNI = "64646464G"
                }
            }
        };
        
        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class StudentCreatorIntegrationTest
    {
        IConsoleHelper console = new ConsoleHelper();
        IParserFactory factory1 = new SerializerJson();
        IParserFactory factory2 = new SerializerTxt();
        IFactoryService _creator = new FactoryService();
        StudentCreator.Helpers.Text.TextWriter ser1, ser2;
        Student alumno = new Student
        {
            ID = 1,
            Nombre = "Carlos",
            Apellidos = "Sanchez Romero",
            DNI = "54545454F"
        };
        IStudentRepository studentRepo;

        public StudentCreatorIntegrationTest()
        {
            studentRepo = new StudentRepository(console);
            ser1 = new StudentCreator.Helpers.Text.TextWriter(factory1);
            ser2 = new StudentCreator.Helpers.Text.TextWriter(factory2);
        }

        [Fact]
        public void StudentToStringTest()
        {
            var result = alumno.ToString();
            Assert.True(result == "1,Carlos,Sanchez Romero,54545454F");
        }

        [Fact]
        public void SerializerIsJson()
        {
            Assert.IsType<SerializerJson>(_creator.CreateFactorySerializer(TipoArchivo.json));
        }

        [Fact]
        public void SerializerIsTxt()
        {
            Assert.IsType<SerializerTxt>(_creator.CreateFactorySerializer(TipoArchivo.txt));
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void SerializerTestJson(string filename, Student alumno)
        {
            var textSerializer = new StudentCreator.Helpers.Text.TextWriter(new SerializerJson());
            textSerializer.Append(filename, alumno);
            filename += ".json";
            Assert.True(File.Exists(filename));
            var listOfStudents = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(filename));
            Assert.Contains(alumno, listOfStudents);
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void SerializerTestTxt(string filename, Student alumno)
        {
            var textSerializer = new StudentCreator.Helpers.Text.TextWriter(new SerializerTxt());
            textSerializer.Append(filename, alumno);
            filename += ".txt";
            Assert.True(File.Exists(filename));
            var txtString = File.ReadAllText(filename);
            Assert.Contains(alumno.ToString(), txtString);
        }

    }
}
