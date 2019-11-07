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
            #region ** String variable declaration **
            string strEmpNo = string.Empty;
            string strSex = string.Empty;
            string strTitle = string.Empty;
            string strFather = string.Empty;
            string strEmpType = string.Empty;
            string strMaritalStatus = string.Empty;
            string strDob = string.Empty;
            string strDoj = string.Empty;
            string strQuarters = string.Empty;
            string strBankMode = string.Empty;
            string strEmpName = string.Empty;
            string strAddress1 = string.Empty;
            string strAddress2 = string.Empty;
            string strAddress3 = string.Empty;
            string strPostal = string.Empty;
            string strEmpLocation = string.Empty;
            string strDesig = string.Empty;
            string strGrade = string.Empty;
            string strScale = string.Empty;
            string strDepartment = string.Empty;
            string strDoc = string.Empty;
            #endregion

            long TimeTookticks = DateTime.Now.Ticks;
            EMPCreationCore _empCreation = new EMPCreationCore();
            DataSet _dsObject = new DataSet();
            List<string> inputCC = new List<string>();
            DataTable dtService = new DataTable();

            try
            {
                var SqlConn = new ConcreteConnectionsFactory().GetConnection("IILHome");
                SqlConn.Connection("connection");

                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation || Started : " + Tools.TicksToTime(DateTime.Now.Ticks), Entities.LogType.LogMode.Debug);

                /* ------------ Getting maximum Employee Number from legacy ------------ */
                try
                {
                    Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation || Getting maximum Employee Number from legacy || Started", Entities.LogType.LogMode.Debug);
                    _dsObject = (DataSet)_empCreation.GetOrSetChangesToDB("getMaxEmpId");
                    _dsObject.Tables[0].TableName = "getMaxEmpId";
                    Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation || Getting maximum Employee Number from legacy || Ended : " + DateTime.Now.TimeOfDay, Entities.LogType.LogMode.Debug);
                }
                catch (Exception ex)
                {
                    Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation|| Getting maximum Employee Number from legacy || Error : " + ex.Message, Entities.LogType.LogMode.Error);
                }
                /* ------------ END : Getting maximum Employee Number from legacy ------------ */

                if (Tools.IsNullDataSet(_dsObject))
                {
                    inputCC.Add(_dsObject.Tables["getMaxEmpId"].Rows[0]["EmpCount"].ToString());

                    Service.SAPFactory.SAPServiceManager _sapservice = new Service.SAPFactory.SAPServiceManager();
                    var SAPConnect = _sapservice.GetSAPService("datatable");
                    dtService = (DataTable)SAPConnect.ConnectSAPService(inputCC, "R3EmpCreation");

                    _sapservice = null;
                    SAPConnect = null;

                    if(dtService != null && dtService.Rows.Count > 0)
                    {
                        Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation || R3EmpCreation || Rows : " + dtService.Rows.Count , Entities.LogType.LogMode.Debug);
                        foreach (DataRow dr in dtService.Rows)
                        {
                            DataTable _dtInternalServ = new DataTable();
                            try
                            {
                                strEmpNo = dr["Empno"].ToString().Substring(2, 6);

                                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation || EmpCreation_chkEmpExists: Started || strEmpNo : " + strEmpNo, Entities.LogType.LogMode.Debug);
                                _dtInternalServ = (DataTable)_empCreation.EmpCreation_chkEmpExists(strEmpNo);
                                _dtInternalServ.TableName = "chkEmpExists";
                                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation || EmpCreation_chkEmpExists: Ended || Ended : " + DateTime.Now.TimeOfDay, Entities.LogType.LogMode.Debug);
                            }
                            catch (Exception ex)
                            {
                                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation|| Checking whether Employee already exists in the legacy || Error : " + ex.Message, Entities.LogType.LogMode.Error);
                            }

                            Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation || chkEmpExists || Rows : " + _dtInternalServ.Rows.Count, Entities.LogType.LogMode.Debug);
                            if (_dtInternalServ != null && _dtInternalServ.Rows.Count <= 0)
                            {
                                //Employee Sex
                                if (Convert.ToInt32(dr["Empsex"].ToString()) == 1)
                                {
                                    strSex = "M";
                                    strTitle = "Mr.";
                                }
                                else
                                {
                                    strSex = "F";
                                    strTitle = "Miss";
                                }

                            }
                        }

                        // Making the datatable to null
                        dtService = null;
                    }
                }

                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation || Ended : " + Tools.TicksToTime(TimeTookticks), Entities.LogType.LogMode.Debug);
                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation || Ended: --------------------------------" + Environment.NewLine + "" + Environment.NewLine, Entities.LogType.LogMode.Debug);
            }
            catch (Exception ex)
            {
                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation || Error : " + ex.Message, Entities.LogType.LogMode.Error);
            }
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
                        _empCreation.UpdateToDb(CCXML, "CCUpdate");                       
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
                        _empCreation.UpdateToDb(CCXML, "UpdateCostCenterSchedules");
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
        /// SAPPlantUpdation
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

                inputCC.Add("T001W");
                inputCC.Add("");
                inputCC.Add("WERKS|NAME1|VKORG");

                Service.SAPFactory.SAPServiceManager _sapservice = new Service.SAPFactory.SAPServiceManager();
                var SAPConnect = _sapservice.GetSAPService("datatable");
                DataTable dtService = (DataTable)SAPConnect.ConnectSAPService(inputCC, "GetTableData");

                _sapservice = null;
                SAPConnect = null;

                Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPPlantUpdation || dtService count: " + dtService.Rows.Count.ToString(), Entities.LogType.LogMode.Debug);
                if (dtService != null && dtService.Rows.Count > 0)
                {
                    dtService.TableName = "Data";
                    string CCXML = Tools.ConvertDataTableToXMLString(dtService);
                    _empCreation.UpdateToDb(CCXML, "PlntUpd_T");                    
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
