using StudentCreator.Models;

namespace StudentCreator.Helpers.Text
{
    public interface IParser
    {
        void AddToFile(string filename, Student student);
        string FileExtension { get;}
    }
}
