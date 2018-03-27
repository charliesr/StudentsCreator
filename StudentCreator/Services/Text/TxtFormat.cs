using StudentCreator.Models;
using System;
using System.IO;
using System.Reflection;

namespace StudentCreator.Services.Text
{
    public class TxtFormat : IFormat
    {
        public string StringPointer { get; }


        public TxtFormat(string stringPointer)
        {
            StringPointer = stringPointer;
        }

        public void Add<T>(T value) where T : class
        {
            var content = string.Empty;
            var last = typeof(T).GetProperties()[typeof(T).GetProperties().Length - 1];
            foreach (var prop in typeof(T).GetProperties())
            {
                content += prop.GetValue(value);
                if (!prop.Equals(last)) content += ",";
            }
            File.AppendAllText(StringPointer, content);
        }
    }
}