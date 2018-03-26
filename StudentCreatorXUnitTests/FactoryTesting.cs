using StudentCreator.Services.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StudentCreatorXUnitTests
{
    public class FactoryTesting
    {
        IFormat factory1 = new JsonFormat();
        IFormat factory2 = new TxtFormat();
        IFormat factory3 = new XmlFormat();

        [Fact]
        public void ParserIsJsonTest()
        {
            Assert.IsType<JsonParser>(factory1.CreateParser());

        }

        [Fact]
        public void FormatIsJsonTest()
        {
            var jsonFormat = factory1.CreateParser();
            Assert.True(jsonFormat.FileExtension == ".json");
        }

        [Fact]
        public void ParserIsTxtTest()
        {
            Assert.IsType<TxtParser>(factory2.CreateParser());
        }

        [Fact]
        public void FormatIsTxtTest()
        {
            var txtFormat = factory2.CreateParser();
            Assert.True(txtFormat.FileExtension == ".txt");
        }

        [Fact]
        public void ParserIsXmlTest()
        {
            Assert.IsType<XmlParser>(factory3.CreateParser());
        }

        [Fact]
        public void FormatIsXtmTest()
        {
            var xmlFormat = factory3.CreateParser();
            Assert.True(xmlFormat.FileExtension == ".xml");
        }
    }
}
