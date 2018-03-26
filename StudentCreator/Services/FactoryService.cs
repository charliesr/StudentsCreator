using System;
using StudentCreator.Services;
using StudentCreator.Services.Text;
using StudentCreator.Models;

namespace StudentCreator
{
    static class FormatFactory
    {
        public static IFormat CreateFormat(Enums.TipoArchivo tipo)
        {
            switch (tipo)
            {
                case Enums.TipoArchivo.json:
                    return new JsonFormat();
                case Enums.TipoArchivo.txt:
                    return new TxtFormat();
                case Enums.TipoArchivo.xml:
                    return new XmlFormat();
                default:
                    return null;
            }
        }
    }
}
