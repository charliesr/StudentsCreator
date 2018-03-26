using StudentCreator.Services;
using StudentCreator.Services.Text;
using StudentCreator.Models;

namespace StudentCreator.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private IConsoleHelper _console;
        public StudentRepository(IConsoleHelper console)
        {
            _console = console;
        }   

        public void NewFromConsoleToText(Enums.TipoArchivo tipo)
        {
            IFormat formato =  FormatFactory.CreateFormat(tipo);
            var alumno = _console.GetObjectFromConsole<Student>();
            var textSerializer = new FileWriter(formato);
            textSerializer.Append("students", alumno);
        }
    }
}
