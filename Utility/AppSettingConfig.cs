using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class AppSettingConfig
    {
        public static string GetConfigAppSetting(object key)
        {
            string strResult = string.Empty;
            try
            {
                if(key != null && !string.IsNullOrEmpty(key.ToString()))
                {
                    strResult = Tools.ConfigSetting<string>(key.ToString()); // ConfigurationSettings.AppSettings[key.ToString()];
                    return Tools.ConvertObjectToString(strResult);
                }
            }
            catch (Exception ex)
            {
                Log4net.LogWriter("Utility", "AppSettingConfig", "AppSettingConfig || Error : " + ex.Message, Entities.LogType.LogMode.Error);
            }
            return strResult;
        }
    }
}