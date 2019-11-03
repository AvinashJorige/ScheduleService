﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using log4net;
using Entities;
using System.Data.SqlClient;
using Service.ConnectionFactory;

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


        #region =================== PRIVATE METHODS ===================
        private void SAPEmpCreation()
        {

        }

        /// <summary>
        /// SAP Cost Center Updation
        /// </summary>
        private void SAPCostCenterUpdation()
        {
            long TimeTookticks = DateTime.Now.Ticks;
            List<string> inputCC = new List<string>();
            var SqlConn = new ConcreteConnectionsFactory().GetConnection("IILHome");
            SqlConn.Connection("connection");

            try
            {
                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPCostCenterUpdation || Started : " + Tools.TicksToTime(DateTime.Now.Ticks), Entities.LogType.LogMode.Debug);

                inputCC.Add("CSKT");
                inputCC.Add("KOKRS EQ '1000'");
                inputCC.Add("KOSTL|KTEXT|LTEXT|MCTXT");

                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPCostCenterUpdation || Ended : " + Tools.TicksToTime(TimeTookticks), Entities.LogType.LogMode.Debug);
                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPCostCenterUpdation || Ended: --------------------------------" + Environment.NewLine + "" + Environment.NewLine, Entities.LogType.LogMode.Debug);

            }
            catch (Exception ex)
            {
                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPCostCenterUpdation || Error : " + ex.Message, Entities.LogType.LogMode.Error);
            }
            finally
            {
                inputCC = null;
            }

        }

        #endregion
    }
}
