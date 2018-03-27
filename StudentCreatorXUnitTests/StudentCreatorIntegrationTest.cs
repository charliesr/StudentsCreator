using StudentCreator.Models;
using StudentCreator.Repositories;
using System.Collections.Generic;
using Xunit;
using System.Collections;
using Newtonsoft.Json;
using System.IO;
using StudentCreator.Services;
using StudentCreator.Services.Text;
using System;

namespace StudentCreatorXUnitTests
{


    public class StudentCreatorIntegrationTest
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
