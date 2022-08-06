using System;

namespace Project_Brookes.appManager
{
    public class ConfigHelper
    {
        public static T GetValue<T>(string name)
        {
            var value = System.Configuration.ConfigurationSettings.AppSettings[name];
            return (T) Convert.ChangeType(value, typeof(T));
        }

        public static T Get<T>(string key, T defaultValue) where T : struct
        {
            var value = System.Configuration.ConfigurationSettings.AppSettings[key];
            if (value == null)
            {
                return defaultValue;
            }
            return (T) Convert.ChangeType(value, typeof(T));
        }
    }
}