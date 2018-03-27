using System.Configuration;

namespace StudentCreator.Services
{
    public interface IConfig
    {
        string GetConfigAppSetting(string variable);
        string GetEnvironmentValue(string variable);
        void SetEnvironmentValue(string variable, string value);
    }
}
