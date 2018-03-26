using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCreator.Helpers
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

    public class ConsoleHelper : IConsoleHelper
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        public string GetLine() {
            return Console.ReadLine();
        }

        public OpcionPpal Menu()
        {
            Print("Elige una opcion");
            Print("1. Crear Alumno");
            Print("2. Escoger tipo de archivo");
            Print("3. Salir");
            return (OpcionPpal)Convert.ToInt32(GetLine());
        }
    }
}
