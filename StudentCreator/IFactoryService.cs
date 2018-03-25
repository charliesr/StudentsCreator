using StudentCreator.Helpers;
using StudentCreator.Helpers.Text;

namespace StudentCreator
{
    public interface IFactoryService
    {
        IParserFactory CreateFactorySerializer(TipoArchivo tipo);
    }
}