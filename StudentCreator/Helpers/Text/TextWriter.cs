using StudentCreator.Models;

namespace StudentCreator.Helpers.Text
{
    public class TextWriter
    {
        private IParser _parser;
        public TextWriter(IParserFactory factory)
        {
            _parser = factory.CreateParser();
        }

        public void Append(string filename, Student student)
        {
            _parser.AddToFile(filename, student);
        }
    }
}