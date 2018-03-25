using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCreator.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public string GetConfigAppSetting(string variable)
        {
            return ConfigurationManager.AppSettings[variable];
        }

        public void SetConfigAppSetting(string variable, string value)
        {
            ConfigurationManager.AppSettings[variable] = value;
        }

        public void SetConfigAppSettingsOnFile(string variable, string value)
        {
            var appconfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            appconfig.AppSettings.Settings[variable].Value = value;
            Save(appconfig);
        }

        private void Save(Configuration config)
        {
            config.Save();
        }
    }
}
