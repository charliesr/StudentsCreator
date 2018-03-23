using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentCreator.Program;

namespace StudentCreator
{

    static class TextFileFactory
    {
        static ITextFileCreator SetTypeFile(TipoArchivo tipo)
        {
            switch (tipo)
            {
                case TipoArchivo.Json:
                    return new JsonFile();
                case TipoArchivo.Txt:
                    return new TxtFile();
                default:
                    return null;
            }
        }
    }
}
