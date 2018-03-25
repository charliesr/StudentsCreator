using StudentCreator.Helpers;

namespace StudentCreator.Repositories
{
    public interface IStudentRepository
    {
        void NewFromConsoleToText(TipoArchivo tipo);
    }
}
