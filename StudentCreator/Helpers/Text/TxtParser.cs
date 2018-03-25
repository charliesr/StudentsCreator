using StudentCreator.Models;
using System.IO;

namespace StudentCreator.Helpers.Text
{
    public class TxtParser : IParser
    {
        public  void AddToFile(string filename, Student student)
        {
            filename += ".txt";
            var content = student.ToString() + "\n\r";
            File.AppendAllText(filename, content);
        }
    }
}