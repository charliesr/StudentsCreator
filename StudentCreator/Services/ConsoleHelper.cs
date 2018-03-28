using System;
using StudentCreator.Models;
using System.Reflection;
using System.Threading;

namespace StudentCreator.Services
{


    public class ConsoleHelper : IConsole
    {
        public ConsoleHelper()
        {
            Program.log.Debug("Creada instancia de ConsoleClass");
        }
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
            var type = assembly.GetType(typeof(T).FullName);
            var instance = Activator.CreateInstance(type) as T;

            foreach (var prop in type.GetProperties())
            {
                if (prop.PropertyType == typeof(Guid))
                {
                    prop.SetValue(instance, Guid.NewGuid());
                    continue;
                }
                Print(prop.Name);
                instance.SetPropertyValue(prop.Name, GetLine());
            }

            return instance;

        }

        public void ClearScreen()
        {
            Console.Clear();
        }

        public void Sleep(int milisecs)
        {
            Thread.Sleep(milisecs);
        }
    }
}
