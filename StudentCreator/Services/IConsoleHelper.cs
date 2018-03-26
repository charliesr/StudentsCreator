using StudentCreator.Models;

namespace StudentCreator.Services
{
    public interface IConsoleHelper
    {
        void Print(string message);
        string GetLine();
        Enums.OpcionPpal Menu();
        T GetObjectFromConsole<T>() where T : class;
    }
}
