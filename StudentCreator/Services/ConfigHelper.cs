using System;
using System.Configuration;

namespace StudentCreator.Services
{
    public class ConfigHelper : IConfig
    {
        public ConfigHelper()
        {
            Program.log.Debug("Creada instancia de ConfigClass");
        }
        public string GetConfigAppSetting(string variable)
        {
            Program.log.Info("Se pide el contenido de " + variable + " en archivo de config");
            return ConfigurationManager.AppSettings[variable];
        }

        public string GetEnvironmentValue(string variable)
        {
            Program.log.Info("Se pide el valor de la variable de entorno " + variable);
            return Environment.GetEnvironmentVariable(variable,EnvironmentVariableTarget.User);
        }

        public void SetEnvironmentValue(string variable, string value)
        {
            Program.log.Info("Se guarda " + value + " en la variable de entorno " + variable);
            Environment.SetEnvironmentVariable(variable, value, EnvironmentVariableTarget.User);
        }
    }
}
