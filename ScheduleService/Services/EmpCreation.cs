using Core;
using Entities;
using Service.ConnectionFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
            long TimeTookticks           = DateTime.Now.Ticks;
            List<string> inputCC         = new List<string>();            
            EMPCreationCore _empCreation = new EMPCreationCore();            

            try
            {
                var SqlConn = new ConcreteConnectionsFactory().GetConnection("IILHome");
                SqlConn.Connection("connection");

                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPCostCenterUpdation || Started : " + Tools.TicksToTime(DateTime.Now.Ticks), Entities.LogType.LogMode.Debug);

                inputCC.Add("CSKT");
                inputCC.Add("KOKRS EQ '1000'");
                inputCC.Add("KOSTL|KTEXT|LTEXT|MCTXT");

                Service.SAPFactory.SAPServiceManager _sapservice = new Service.SAPFactory.SAPServiceManager();
                var SAPConnect = _sapservice.GetSAPService("datatable");
                DataTable dtService = (DataTable)SAPConnect.ConnectSAPService(inputCC, "GetTableData");

                _sapservice = null;
                SAPConnect = null;

                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPCostCenterUpdation || dtService count: " + dtService.Rows.Count.ToString(), Entities.LogType.LogMode.Debug);
                if (dtService != null && dtService.Rows.Count > 0)
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
                        string CCXML = Tools.ConvertDataTableToXMLString(dtfinal);
                        _empCreation.CCUpdate(CCXML);                       
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
                _empCreation = null;
            }

        }

        /// <summary>
        /// SAPCostCenterUpdationEmployeeWise 
        /// </summary>
        private void SAPCostCenterUpdationEmployeeWise()
        {
            long TimeTookticks = DateTime.Now.Ticks;
            List<string> inputCC = new List<string>();
            EMPCreationCore _empCreation = new EMPCreationCore();

            try
            {
                var SqlConn = new ConcreteConnectionsFactory().GetConnection("IILHome");
                SqlConn.Connection("connection");

                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPCostCenterUpdationEmployeeWise || Started : " + Tools.TicksToTime(DateTime.Now.Ticks), Entities.LogType.LogMode.Debug);

                inputCC.Add("COAS");
                inputCC.Add("AUART EQ '2000'");
                inputCC.Add("AUFNR|KOSTV");

                Service.SAPFactory.SAPServiceManager _sapservice = new Service.SAPFactory.SAPServiceManager();                
                var SAPConnect = _sapservice.GetSAPService("datatable");
                DataTable dtService = (DataTable)SAPConnect.ConnectSAPService(inputCC, "GetTableData");

                _sapservice = null;
                SAPConnect = null;

                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPCostCenterUpdationEmployeeWise || dtService count: " + dtService.Rows.Count.ToString(), Entities.LogType.LogMode.Debug);
                if (dtService != null && dtService.Rows.Count > 0)
                {
                    DataTable dtfinal = new DataTable("CostCenterUpdationEmployee");
                    DataRow drfinal = dtfinal.NewRow();
                    dtfinal.Columns.Add("Empid");
                    dtfinal.Columns.Add("CostCenter");

                    foreach (DataRow dr in dtService.Rows)
                    {
                        drfinal = dtfinal.NewRow();
                        if (dr["IntOrdNo"].ToString() != "NOT TO USE" || dr["IntOrdName"].ToString() != "NOT TO USE")
                        {
                            string EmpidS           = dr[0].ToString().Trim();
                            string TempCostCenter   = dr[1].ToString().Trim();
                            drfinal["Empid"]        = EmpidS.Substring(((EmpidS.Length) - 6), 6);

                            if (TempCostCenter != string.Empty)
                            {
                                drfinal["CostCenter"] = TempCostCenter.Substring(((TempCostCenter.Length) - 8), 8);
                            }
                            dtfinal.Rows.Add(drfinal);
                        }
                    }

                    if (dtfinal != null && dtfinal.Rows.Count > 0)
                    {
                        string CCXML = Tools.ConvertDataTableToXMLString(dtfinal);
                        _empCreation.UpdateCostCenterSchedules(CCXML);
                    }
                }

                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPCostCenterUpdationEmployeeWise || Ended : " + Tools.TicksToTime(TimeTookticks), Entities.LogType.LogMode.Debug);
                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPCostCenterUpdationEmployeeWise || Ended: --------------------------------" + Environment.NewLine + "" + Environment.NewLine, Entities.LogType.LogMode.Debug);

            }
            catch (Exception ex)
            {
                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPCostCenterUpdationEmployeeWise || Error : " + ex.Message, Entities.LogType.LogMode.Error);
            }
            finally
            {
                inputCC = null;
                _empCreation = null;
            }

        }

        /// <summary>
        /// FillItemMaster
        /// </summary>
        private void FillItemMaster()
        {
            long TimeTookticks = DateTime.Now.Ticks;
            List<string> input = new List<string>();
            EMPCreationCore _empCreation = new EMPCreationCore();

            try
            {
                var SqlConn = new ConcreteConnectionsFactory().GetConnection("IILHome");
                SqlConn.Connection("connection");

                Log4net.LogWriter("ScheduleService", "EmpCreation", "FillItemMaster || Started : " + Tools.TicksToTime(DateTime.Now.Ticks), Entities.LogType.LogMode.Debug);

                input.Add("");
                input.Add("");
                input.Add("");
                input.Add("");

                Service.SAPFactory.SAPServiceManager _sapservice = new Service.SAPFactory.SAPServiceManager();
                var SAPConnect = _sapservice.GetSAPService("dataset");
                DataSet dtService = (DataSet)SAPConnect.ConnectSAPService(input, "Readmaterial");

                _sapservice = null;
                SAPConnect = null;

                if (Tools.IsNullDataSet(dtService))
                {
                    Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPCostCenterUpdationEmployeeWise || dtService inside : true", Entities.LogType.LogMode.Debug);
                    DataTable dtitemmaster1= dtService.Tables[0].DefaultView.ToTable(true);
                    DataTable dtitemmaster2 = dtService.Tables[1].DefaultView.ToTable(true);

                    foreach (DataRow dr1 in dtitemmaster1.Rows)
                    {
                        string e = dr1["Matdesc"].ToString();
                        e.Trim('\'');
                        dr1["MatDesc"] = e;
                        dtitemmaster1.AcceptChanges();
                    }
                    string IndentXML1 = Tools.ConvertDataTableToXMLString(dtitemmaster1);
                    string IndentXML2 = Tools.ConvertDataTableToXMLString(dtitemmaster2);

                    _empCreation.Indent_InsertNewItem(IndentXML1, IndentXML2);
                }
                Log4net.LogWriter("ScheduleService", "EmpCreation", "FillItemMaster || Ended : " + Tools.TicksToTime(TimeTookticks), Entities.LogType.LogMode.Debug);
                Log4net.LogWriter("ScheduleService", "EmpCreation", "FillItemMaster || Ended: --------------------------------" + Environment.NewLine + "" + Environment.NewLine, Entities.LogType.LogMode.Debug);
            }
            catch (Exception ex)
            {
                Log4net.LogWriter("ScheduleService", "EmpCreation", "FillItemMaster || Error : " + ex.Message, Entities.LogType.LogMode.Error);
            }
            finally
            {
                input = null;
                _empCreation = null;
            }
        }


        /// <summary>
        /// SAP Cost Center Updation
        /// </summary>
        private void SAPPlantUpdation()
        {
            long TimeTookticks = DateTime.Now.Ticks;
            List<string> inputCC = new List<string>();
            EMPCreationCore _empCreation = new EMPCreationCore();

            try
            {
                var SqlConn = new ConcreteConnectionsFactory().GetConnection("IILHome");
                SqlConn.Connection("connection");

                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPPlantUpdation || Started : " + Tools.TicksToTime(DateTime.Now.Ticks), Entities.LogType.LogMode.Debug);

                inputCC.Add("CSKT");
                inputCC.Add("KOKRS EQ '1000'");
                inputCC.Add("KOSTL|KTEXT|LTEXT|MCTXT");

                Service.SAPFactory.SAPServiceManager _sapservice = new Service.SAPFactory.SAPServiceManager();
                var SAPConnect = _sapservice.GetSAPService("datatable");
                DataTable dtService = (DataTable)SAPConnect.ConnectSAPService(inputCC, "GetTableData");

                _sapservice = null;
                SAPConnect = null;

                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPPlantUpdation || dtService count: " + dtService.Rows.Count.ToString(), Entities.LogType.LogMode.Debug);
                if (dtService != null && dtService.Rows.Count > 0)
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
                        string CCXML = Tools.ConvertDataTableToXMLString(dtfinal);
                        _empCreation.CCUpdate(CCXML);
                    }
                }

                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPPlantUpdation || Ended : " + Tools.TicksToTime(TimeTookticks), Entities.LogType.LogMode.Debug);
                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPPlantUpdation || Ended: --------------------------------" + Environment.NewLine + "" + Environment.NewLine, Entities.LogType.LogMode.Debug);

            }
            catch (Exception ex)
            {
                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPCostCenterUpdation || Error : " + ex.Message, Entities.LogType.LogMode.Error);
            }
            finally
            {
                inputCC = null;
                _empCreation = null;
            }

        }
        #endregion
    }
}
