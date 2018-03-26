using StudentCreator.Helpers;
using StudentCreator.Helpers.Text;
using StudentCreator.Models;
using System;

namespace StudentCreator.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private IConsoleHelper _console;
        public StudentRepository(IConsoleHelper console)
        {
            _console = console;
        }   

        public void NewFromConsoleToText(TipoArchivo tipo)
        {
            IFormat formato =  FormatFactory.CreateFactorySerializer(tipo);
            var alumno = new Student();
            _console.Print("Introduzca el ID");
            alumno.ID = Convert.ToInt32(_console.GetLine());
            _console.Print("Nombre:");
            alumno.Nombre = _console.GetLine();
            _console.Print("Apellidos");
            alumno.Apellidos = _console.GetLine();
            _console.Print("DNI");
            alumno.DNI = _console.GetLine();
            var textSerializer = new FileWriter(formato);
            textSerializer.Append("students", alumno);
        }
    }
}
