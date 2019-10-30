namespace Utility
{
    using log4net;
    using System;
    using static Entities.LogType;

    public static class Log4net
    {
        /// <summary>
        /// http://technico.qnownow.com/how-to-change-the-log-file-name-of-log4net-rolling-file-appender-dynamically/
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Logs the message either as Error/Debug/Warning into a separate folder with file name.
        /// </summary>
        /// <param name="strModule">File Name</param>
        /// <param name="strMethodName">Folder Name that created in the log folder</param>
        /// <param name="strMsg">Message to display in the log</param>
        /// <param name="type">Log type</param>
        public static void LogWriter(string strModule, string strMethodName, string strMsg, LogMode type)
        {
            try
            {
                log4net.GlobalContext.Properties["LogFileName"] = strModule;
                log4net.Config.XmlConfigurator.Configure();

                ILog log = LogManager.GetLogger(typeof(Log4net));

                if (type.ToString() == "Error")
                {
                    log.Error(strMethodName + " | Message : " + strMsg);
                }
                else if(type.ToString() == "Warn")
                {
                    log.Warn(strMethodName + " | Message : " + strMsg);
                }
                else if (type.ToString() == "Debug")
                {
                    log.Debug(strMethodName + " | Message : " + strMsg);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error in Log : " + ex.Message);
            }
        }

        private static string LogFilePath()
        {
            try
            {
                string subPath = "ImagesPath"; // your code goes here
                bool exists = System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(subPath));

                if (!exists)
                    System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(subPath));
            }
            catch (Exception ex)
            {
                log.Error("Error in LogFilePath: " + ex.Message);
            }
            return string.Empty;
        }
    }
}
