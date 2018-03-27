using StudentCreator.Models;
using Xunit;
using System;

namespace StudentCreatorXUnitTests
{


    public class StudentTest
    {
        Student alumno = new Student(Guid.NewGuid(), 1, "Carlos", "Sanchez Romero", "54545454F");

        [Fact]
        public void StudentToStringTest()
        {
            var result = alumno.ToString();
            Assert.True(result == alumno.GUID + ",1,Carlos,Sanchez Romero,54545454F");
        }
    }
}
