using StudentCreator.Models;
using System.IO;

namespace StudentCreator.Helpers.Text
{
    public class TxtParser : IParser
    {
        public string FileExtension { get { return ".txt"; } }
        // Generado por vs
        //public string FileExtension => ".txt";

        public void AddToFile(string filename, Student student)
        {
            filename += FileExtension;
            var content = student.ToString() + "\n\r";
            File.AppendAllText(filename, content);
        }
    }
}