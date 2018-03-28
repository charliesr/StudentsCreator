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
                    Program.log.Info("Creando formato Json");
                    return new JsonFormat(stringPointer);
                case Enums.TipoArchivo.txt:
                    Program.log.Info("Creando formato Txt");
                    return new TxtFormat(stringPointer);
                case Enums.TipoArchivo.xml:
                    Program.log.Info("Creando formato Xml");
                    return new XmlFormat(stringPointer);
                default:
                    return null;
            }
        }
    }
}
