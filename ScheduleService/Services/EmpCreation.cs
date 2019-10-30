using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using log4net;
using Entities;

namespace ScheduleService.Services
{
    public class EmpCreation
    {
        public void EmployeeCreation()
        {
            try
            {
                Log4net.LogWriter("EmployeeCreation", "EmpCreation", "SAPEmpCreation Started." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"), LogType.LogMode.Debug);
                SAPEmpCreation();
                Log4net.LogWriter("EmployeeCreation", "EmpCreation", "SAPEmpCreation Ended." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"), LogType.LogMode.Debug);
            }
            catch (Exception ex)
            {
                Log4net.LogWriter("EmployeeCreation", "EmpCreation", ex.Message, LogType.LogMode.Error);
            }
        }

        private void SAPEmpCreation()
        {

        }
    }
}
