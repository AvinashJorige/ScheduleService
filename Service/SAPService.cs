using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Service
{
    public class SAPService
    {
        public object ConnectSAPService()
        {
            long TimeTookticks = DateTime.Now.Ticks;
            try
            {
                Log4net.LogWriter("SAPService", "Service", "ConnectSAPService || Started : " + Tools.TicksToTime(DateTime.Now.Ticks), Entities.LogType.LogMode.Debug);

                SAPService Con = new SAPService(ConfigurationSettings.AppSettings["SAPWebServiceURL"]);

                Log4net.LogWriter("SAPService", "Service", "ConnectSAPService || Ended : " + Tools.TicksToTime(TimeTookticks), Entities.LogType.LogMode.Debug);
            }
            catch (Exception ex)
            {
                Log4net.LogWriter("SAPService", "Service", "ConnectSAPService || Error : " + ex.Message, Entities.LogType.LogMode.Error);
            }
        }
    }
}
