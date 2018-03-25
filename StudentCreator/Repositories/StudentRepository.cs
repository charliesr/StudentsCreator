using StudentCreator.Helpers;
using StudentCreator.Helpers.Text;
using StudentCreator.Models;
using System;

namespace StudentCreator.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private IConsoleHelper _console;
        private IFactoryService _creator;
        public StudentRepository(IConsoleHelper console)
        {
            _console = console;
            _creator = new FactoryService();
        }   

        public void NewFromConsoleToText(TipoArchivo tipo)
        {
            IParserFactory serializerFactory = _creator.CreateFactorySerializer(tipo);
            var alumno = new Student();
            _console.Print("Introduzca el ID");
            alumno.ID = Convert.ToInt32(_console.GetLine());
            _console.Print("Nombre:");
            alumno.Nombre = _console.GetLine();
            _console.Print("Apellidos");
            alumno.Apellidos = _console.GetLine();
            _console.Print("DNI");
            alumno.DNI = _console.GetLine();
            var textSerializer = new TextWriter(serializerFactory);
            textSerializer.Append("students", alumno);
        }
    }
}
