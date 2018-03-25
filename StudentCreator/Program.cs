using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCreator.Helpers;
using StudentCreator.Repositories;

namespace StudentCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigHelper config = new ConfigHelper();
            IConsoleHelper console = new ConsoleHelper();
            IStudentRepository studentRepo = new StudentRepository(console);
            var opcionMenuPpal = console.Menu();
            while (opcionMenuPpal != OpcionPpal.salir)
            {
                switch (opcionMenuPpal)
                {
                    case OpcionPpal.newStudent:
                        studentRepo.NewFromConsoleToText((TipoArchivo)Enum.Parse(typeof(TipoArchivo), config.GetConfigAppSetting("tipo")));
                        break;

                    case OpcionPpal.setFile:
                        console.Print("Escribe el tipo de serializacion");
                        config.SetConfigAppSetting("tipo", console.GetLine());
                        var appconfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config.SetConfigAppSettingsOnFile("tipo", config.GetConfigAppSetting("tipo"));
                        break;
                }
                opcionMenuPpal = console.Menu();
            }   
        }
    }
}
