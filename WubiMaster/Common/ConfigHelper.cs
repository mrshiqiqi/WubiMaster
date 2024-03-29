using System;

namespace WubiMaster.Common
{
    public class ConfigHelper
    {
        public static bool ReadConfigByBool(string key, bool defaultValue = false)
        {
            string value = JsonConfigHelper.ReadConfig(key);
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            return bool.Parse(value);
        }

        public static int ReadConfigByInt(string key, int defaultValue = -1)
        {
            string value = JsonConfigHelper.ReadConfig(key);
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            return Convert.ToInt32(value);
        }

        public static string ReadConfigByString(string key, string defaultValue = "")
        {
            string value = JsonConfigHelper.ReadConfig(key);
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            return value;
        }

        public static void WriteConfigByBool(string key, bool value)
        {
            JsonConfigHelper.WriteConfig(key, value.ToString());
        }

        public static void WriteConfigByInt(string key, int value)
        {
            JsonConfigHelper.WriteConfig(key, value.ToString());
        }
        public static void WriteConfigByString(string key, string value)
        {
            try
            {
                JsonConfigHelper.WriteConfig(key, value);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
                if (ex is UnauthorizedAccessException)
                    App.Current.MainWindow.ShowMessage("当前用户没有权限读取配置文件");
            }
            
        }
    }
}