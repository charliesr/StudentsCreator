using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCreator.Services;
using StudentCreator.Repositories;
using StudentCreator.Models;

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
            while (opcionMenuPpal != Enums.OpcionPpal.salir)
            {
                switch (opcionMenuPpal)
                {
                    case Enums.OpcionPpal.newStudent:
                        studentRepo.NewFromConsoleToText((Enums.TipoArchivo)Enum.Parse(typeof(Enums.TipoArchivo), config.GetConfigAppSetting("tipo")));
                        break;

                    case Enums.OpcionPpal.setFile:
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
