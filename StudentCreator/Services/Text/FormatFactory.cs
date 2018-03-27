using System;
using StudentCreator.Services;
using StudentCreator.Services.Text;
using StudentCreator.Models;

namespace StudentCreator
{
    public static class FormatFactory
    {
        public static IFormat CreateFormat(Enums.TipoArchivo tipo, string stringPointer)
        {
            switch (tipo)
            {
                case Enums.TipoArchivo.json:
                    return new JsonFormat(stringPointer);
                case Enums.TipoArchivo.txt:
                    return new TxtFormat(stringPointer);
                case Enums.TipoArchivo.xml:
                    return new XmlFormat(stringPointer);
                default:
                    return null;
            }
        }
    }
}
