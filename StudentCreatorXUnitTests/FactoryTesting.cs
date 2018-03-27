using StudentCreator;
using StudentCreator.Services.Text;
using StudentCreator.Models;
using Xunit;

namespace StudentCreatorXUnitTests
{
    public class FactoryTesting
    {
        [Fact]
        public void FactoryReturnsJson()
        {
            Assert.IsType<JsonFormat>(FormatFactory.CreateFormat(Enums.TipoArchivo.json, "prueba"));
        }

        [Fact]
        public void FactoryReturnsTxt()
        {
            Assert.IsType<TxtFormat>(FormatFactory.CreateFormat(Enums.TipoArchivo.txt, "prueba"));
        }

        [Fact]
        public void FactoryReturnsXml()
        {
            Assert.IsType<XmlFormat>(FormatFactory.CreateFormat(Enums.TipoArchivo.xml, "prueba"));
        }
    }
}
