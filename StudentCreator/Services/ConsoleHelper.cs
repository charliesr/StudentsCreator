using System;
using StudentCreator.Models;
using System.Reflection;

namespace StudentCreator.Services
{


    public class ConsoleHelper : IConsoleHelper
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        public string GetLine() {
            return Console.ReadLine();
        }

        public Enums.OpcionPpal Menu()
        {
            Print("Elige una opcion");
            Print("1. Crear Alumno");
            Print("2. Escoger tipo de archivo");
            Print("3. Salir");
            return (Enums.OpcionPpal)Convert.ToInt32(GetLine());
        }

        public T GetObjectFromConsole<T>() where T : class
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType(typeof(T).Name);
            var instance = Activator.CreateInstance(type) as T;

            foreach (var prop in type.GetProperties())
            {
                Print(prop.Name);
                prop.SetValue(instance, GetLine());
            }

            return instance;

        }
    }
}
