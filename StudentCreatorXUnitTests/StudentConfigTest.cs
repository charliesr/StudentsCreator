using StudentCreator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StudentCreatorXUnitTests
{
    public class StudentConfigTest : IDisposable
    {
        IConfig config = new ConfigHelper();

        public void Dispose()
        {
            Environment.SetEnvironmentVariable("StudentFileType", "txt", EnvironmentVariableTarget.User);
        }

        [Fact]
        public void EnvironmentVariableExists()
        {
            Assert.True(config.GetEnvironmentValue("StudentFileType") != "");
        }

        [Theory]
        [InlineData("Hola")]
        [InlineData("Adios")]
        public void EnvironmentVariableSaveTest(string value)
        {
            config.SetEnvironmentValue("StudentFileType", value);
            Assert.Equal(config.GetEnvironmentValue("StudentFileType"), value);
        }
    }
}
