using StudentCreator.Services;
using StudentCreator.Services.Text;
using StudentCreator.Models;

namespace StudentCreator.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IConsoleHelper _console;
        private readonly IFormat _format;
        public StudentRepository(IConsoleHelper console, Enums.TipoArchivo tipo, string stringPointer)
        {
            _console = console;
            _format = FormatFactory.CreateFormat(tipo, stringPointer);
        }   

        public void NewFromConsoleToText()
        {
            var alumno = _console.GetObjectFromConsole<Student>();
            _format.Add(alumno);
            /* var textSerializer = new FileWriter(formato);
            textSerializer.Append(alumno); */
        }
    }
}
