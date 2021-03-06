﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace StudentCreator.Services.Text
{
    public class JsonFormat : IFormat
    {
        public string StringPointer { get; }
        // Generado por vs
        //public string FileExtension => ".json";
        public JsonFormat(string stringPointer)
        {
            StringPointer = stringPointer + ".json";
        }

        public void Add<T>(T value) where T : class
        {
            Program.log.Info("Añadimos " + typeof(T).Name + "a archivo " + StringPointer);
            var values = File.Exists(StringPointer) ? JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(StringPointer)) : new List<T>();
            values.Add(value);
            File.WriteAllText(StringPointer, JsonConvert.SerializeObject(values));
        }

    }
}