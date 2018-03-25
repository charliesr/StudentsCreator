namespace StudentCreator.Helpers
{
    public interface IConsoleHelper
    {
        void Print(string message);
        string GetLine();
        OpcionPpal Menu();
    }
}
