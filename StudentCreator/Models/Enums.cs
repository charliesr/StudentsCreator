using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCreator.Models
{
    public static class Enums
    {
        public enum OpcionPpal
        {
            newStudent = 1,
            setFile = 2,
            salir = 3
        }

        public enum TipoArchivo
        {
            json = 1,
            txt = 2,
            xml = 3
        }

    }
}
