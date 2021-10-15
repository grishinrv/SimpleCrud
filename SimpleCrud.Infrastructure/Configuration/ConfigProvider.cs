using System;
using System.Configuration;

namespace SimpleCrud.Infrastructure.Configuration
{
    public static class ConfigProvider
    {
        public static T GetSetting<T>(string key, T defaultValue)
        {
            try
            {
                string valFromFile = ConfigurationManager.AppSettings[key];
                if (string.IsNullOrWhiteSpace(valFromFile))
                {
                    return defaultValue;
                }
                
                T actualVal = (T)Convert.ChangeType(valFromFile, typeof(T));
                return actualVal;
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static string ConnectionString { get; } 
            = ConfigurationManager.ConnectionStrings?[0]?.ConnectionString ?? "Server=.\\SQLExpress;Database=EascahireDB;Trusted_Connection=True;";
    }
}
