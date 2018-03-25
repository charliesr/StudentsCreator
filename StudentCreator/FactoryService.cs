using System;
using StudentCreator.Helpers;
using StudentCreator.Helpers.Text;

namespace StudentCreator
{
    public class FactoryService : IFactoryService
    {
        public IParserFactory CreateFactorySerializer(TipoArchivo tipo)
        {
            switch (tipo)
            {
                case TipoArchivo.json:
                    return new SerializerJson();
                case TipoArchivo.txt:
                    return new SerializerTxt();
                default:
                    return null;
            }
        }
    }
}
