using System;
using StudentCreator.Helpers;
using StudentCreator.Helpers.Text;

namespace StudentCreator
{
    static class FormatFactory
    {
        public static IFormat CreateFactorySerializer(TipoArchivo tipo)
        {
            switch (tipo)
            {
                case TipoArchivo.json:
                    return new JsonFormat();
                case TipoArchivo.txt:
                    return new TxtFormat();
                case TipoArchivo.xml:
                    return new XmlFormat();
                default:
                    return null;
            }
        }
    }
}
