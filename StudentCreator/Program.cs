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
using log4net;
using System.Reflection;

namespace StudentCreator
{
    public class Program
    {
        public static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            
            IConfig config = new ConfigHelper();
            IConsole console = new ConsoleHelper();
            IStudentRepository studentRepo = null;
            const string environmentFileTypeKey = "EnvVarTipo";
            var opcionMenuPpal = console.Menu();
            log.Info("Elegida la opcion " + opcionMenuPpal.ToString());
            while (opcionMenuPpal != Enums.OpcionPpal.salir)
            {
                switch (opcionMenuPpal)
                {
                    case Enums.OpcionPpal.newStudent:
                        studentRepo = new StudentRepository(console, 
                            FormatFactory.CreateFormat((Enums.TipoArchivo)Enum.Parse(typeof(Enums.TipoArchivo),config.GetEnvironmentValue(config.GetConfigAppSetting(environmentFileTypeKey))),
                            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\student"));
                        studentRepo.AddFromConsole();
                        break;
                    case Enums.OpcionPpal.setFile:
                        console.Print("Escribe el tipo de serializacion");
                        config.SetEnvironmentValue(config.GetConfigAppSetting(environmentFileTypeKey), console.GetLine());
                        break;
                }
                console.ClearScreen();
                opcionMenuPpal = console.Menu();
            }
            console.Print("Adios!!!");
            console.Sleep(5000);
        }
    }
}
