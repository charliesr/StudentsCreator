using StudentCreator.Services;
using StudentCreator.Services.Text;
using StudentCreator.Models;

namespace StudentCreator.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IConsole _console;
        private readonly IFormat _format;
        public StudentRepository(IConsole console, IFormat format)
        {
            _console = console;
            _format = format;
            Program.log.Debug("Creada instancia de StudentRepository");
        }   

        public void AddFromConsole()
        {
            var alumno = _console.GetObjectFromConsole<Student>();
            _format.Add(alumno);
            Program.log.Info("Añadido Student a archivo " + _format.StringPointer);
        }
    }
}
