using StudentCreator.Models;
using System;
using System.IO;
using System.Reflection;

namespace StudentCreator.Services.Text
{
    public class TxtParser : IParser
    {
        public string FileExtension { get { return ".txt"; } }
        // Generado por vs
        //public string FileExtension => ".txt";

        public void AddToFile<T>(string filename, T value) where T : class
        {
            filename += FileExtension;
            var content = string.Empty;
            var last = typeof(T).GetProperties()[typeof(T).GetProperties().Length - 1];
            foreach (var prop in typeof(T).GetProperties())
            {
                content += prop.GetValue(value);
                if (!prop.Equals(last)) content += ",";
            }
            File.AppendAllText(filename, content);
        }
    }
}