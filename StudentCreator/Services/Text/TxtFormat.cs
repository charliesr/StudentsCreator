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
            StringPointer = stringPointer + ".txt";
        }

        public void Add<T>(T value) where T : class
        {
            Program.log.Info("Añadimos " + typeof(T).Name + "a archivo " + StringPointer);
            var content = string.Empty;
            var assembly = Assembly.GetExecutingAssembly(); ;
            var type = assembly.GetType(typeof(T).FullName);
            var methodToString = type.GetMethod("ToString");
            object[] propValues = new object[type.GetProperties().Length];
            for (int i = 0; i < type.GetProperties().Length; i++)
            {
                propValues[i] = type.GetProperties()[i].GetValue(value);
            }
            var classInstance = Activator.CreateInstance(type,propValues);
            content = (string)methodToString.Invoke(classInstance, null);
            File.AppendAllText(StringPointer, content);
        }
    }
}