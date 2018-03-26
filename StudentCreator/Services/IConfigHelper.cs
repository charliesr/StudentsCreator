using System.Configuration;

namespace StudentCreator.Services
{
    public interface IConfigHelper
    {
        string GetConfigAppSetting(string variable);
        void SetConfigAppSetting(string variable, string value);
        void SetConfigAppSettingsOnFile(string variable, string value);
    }
}
