using System;
using System.Configuration;

namespace StudentCreator.Services
{
    public class ConfigHelper : IConfig
    {
        public string GetConfigAppSetting(string variable)
        {
            return ConfigurationManager.AppSettings[variable];
        }

        public string GetEnvironmentValue(string variable)
        {
            return Environment.GetEnvironmentVariable(variable,EnvironmentVariableTarget.User);
        }

        public void SetEnvironmentValue(string variable, string value)
        {
            Environment.SetEnvironmentVariable(variable, value, EnvironmentVariableTarget.User);
        }
    }
}
