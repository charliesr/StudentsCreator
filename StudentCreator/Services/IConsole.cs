using StudentCreator.Models;

namespace StudentCreator.Services
{
    public interface IConsole
    {
        void Print(string message);
        string GetLine();
        Enums.OpcionPpal Menu();
        T GetObjectFromConsole<T>() where T : class;
        void ClearScreen();
        void Sleep(int milisecs);
    }
}
