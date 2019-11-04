using Entities;
using Service.ConnectionFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using Utility;


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
            XmlNode xmlExceptionLocStat = null;
            List<string> inputCC = new List<string>();
            var SqlConn = new ConcreteConnectionsFactory().GetConnection("IILHome");
            SqlConn.Connection("connection");
            


            try
            {
                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPCostCenterUpdation || Started : " + Tools.TicksToTime(DateTime.Now.Ticks), Entities.LogType.LogMode.Debug);

                inputCC.Add("CSKT");
                inputCC.Add("KOKRS EQ '1000'");
                inputCC.Add("KOSTL|KTEXT|LTEXT|MCTXT");

                Service.SAPFactory.SAPServiceManager _sapservice = new Service.SAPFactory.SAPServiceManager();
                DataTable dtService = (DataTable)_sapservice.GetSAPService("datatable");

                if(dtService != null && dtService.Rows.Count > 0)
                {
                    DataTable dtfinal = new DataTable("CostCenterUpdation");
                    DataRow drfinal = dtfinal.NewRow();
                    dtfinal.Columns.Add("CostCenterId");
                    dtfinal.Columns.Add("CostCenterDesc");

                    foreach (DataRow dr in dtService.Rows)
                    {
                        drfinal = dtfinal.NewRow();
                        if (dr["Text1"].ToString() != "NOT TO USE" || dr["Text2"].ToString() != "NOT TO USE")
                        {
                            drfinal["CostCenterId"] = dr["CostCenterCode"].ToString().Trim();
                            drfinal["CostCenterDesc"] = dr["CostCenterName"].ToString().Trim();
                            dtfinal.Rows.Add(drfinal);
                        }
                    }

                    if (dtfinal != null && dtfinal.Rows.Count > 0)
                    {
                        StringWriter SWFinal = new StringWriter();
                        dtfinal.WriteXml(SWFinal);
                        string CCXML = SWFinal.ToString();
                        mycommand = new SqlCommand("USP_CCUpd_T", mycon);
                        mycommand.CommandType = CommandType.StoredProcedure;
                        mycommand.Parameters.Add(new SqlParameter("@CCTable", SqlDbType.Xml));
                        mycommand.Parameters["@CCTable"].Value = CCXML.ToString();
                        mycommand.Connection.Open();
                        mycommand.ExecuteNonQuery();
                        mycommand.Connection.Close();
                    }

                }

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
                xmlExceptionLocStat = null;
            }

        }

        #endregion
    }
}
