using StudentCreator.Models;

namespace StudentCreator.Services.Text
{
    public interface IParser
    {
        void AddToFile<T>(string filename, T value) where T : class;
        string FileExtension { get;}
    }
}
