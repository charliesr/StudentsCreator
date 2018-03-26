using StudentCreator.Models;

namespace StudentCreator.Services.Text
{
    public class FileWriter
    {
        private IParser _parser;
        public FileWriter(IFormat factory)
        {
            _parser = factory.CreateParser();
        }

        public void Append(string filename, Student student)
        {
            _parser.AddToFile(filename, student);
        }
    }
}