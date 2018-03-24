using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCreator
{
    public class StudentRepository
    {
        private ConsoleHelper _console;
        public StudentRepository(ConsoleHelper console)
        {
            _console = console;
        }   

        public void NewFromConsoleToText(TipoArchivo tipo)
        {
            BaseSerializerFactory factory = null;
            switch (tipo)
            {
                case TipoArchivo.json:
                    factory = new SerializerJson();
                    break;
                case TipoArchivo.txt:
                    factory = new SerializerTxt();
                    break;
                default:
                    break;
            }
            var alumno = new Student();
            _console.Print("Introduzca el ID");
            alumno.ID = Convert.ToInt32(_console.GetLine());
            _console.Print("Nombre:");
            alumno.Nombre = _console.GetLine();
            _console.Print("Apellidos");
            alumno.Apellidos = _console.GetLine();
            _console.Print("DNI");
            alumno.DNI = _console.GetLine();
            var textParser = new Serializer(factory);
            textParser.ExecuteAppend("students", alumno);
        }
    }
}
