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
                    SAPConnect  = null;
                    inputCC     = null;
                    inputCC     = new List<string>();

                    // New employee detail fetched from SAP will updated into the IIL Home Database
                    if (dtService != null && dtService.Rows.Count > 0)
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
                                #region ********** Employee Sex **********
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
                                #endregion ********** Employee Sex **********

                                #region ********** Fetching employee father name **********
                                try
                                {
                                    inputCC.Add("PA0021");
                                    inputCC.Add("PERNR EQ " + dr["EmpNo"].ToString());
                                    inputCC.Add("SUBTY|FANAM");

                                    _sapservice = new Service.SAPFactory.SAPServiceManager();
                                    SAPConnect = _sapservice.GetSAPService("datatable");
                                    dtService = (DataTable)SAPConnect.ConnectSAPService(inputCC, "GetTableData");

                                    _sapservice = null;
                                    SAPConnect  = null;
                                    inputCC     = null;
                                    inputCC     = new List<string>();

                                    if (dtService != null && dtService.Rows.Count > 0)
                                    {
                                        foreach (DataRow dr1 in dtService.Rows)
                                        {
                                            if (Convert.ToInt32(dr1["SubType"].ToString()) == 11)
                                            {
                                                strFather = dr1["FatherName"].ToString();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // No Details found in SAP;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation|| Employee Father Name from another RFC(from Table) || Error : " + ex.Message, Entities.LogType.LogMode.Error);
                                }
                                #endregion  ********** Fetching employee father name **********

                                #region ********** Employee Type based on Designation **********
                                if (dr["Designation"] != null && !string.IsNullOrEmpty(dr["Designation"].ToString()) && Tools.ConvertToInt(dr["Designation"].ToString()) == 0)
                                {
                                    if (
                                        (dr["Grade"] != null && !string.IsNullOrEmpty(dr["Grade"].ToString()))
                                        &&
                                        (dr["Grade"].ToString() == "O1" || dr["Grade"].ToString() == "A1" || dr["Grade"].ToString() == "A3" || dr["Grade"].ToString() == "E2" ||
                                        dr["Grade"].ToString() == "O2" || dr["Grade"].ToString() == "A2" || dr["Grade"].ToString() == "E1" || dr["Grade"].ToString() == "E3")
                                        )
                                    {
                                        strEmpType = "FT-OFF";
                                    }
                                    else if (dr["Grade"].ToString().Substring(0, 1).ToUpper() == "T")
                                    {
                                        strEmpType = "TRAINE";
                                    }
                                    else
                                    {
                                        strEmpType = "FT-MGR";
                                    }
                                }
                                else
                                {
                                    _dsObject = null;
                                    _dsObject = new DataSet();

                                    try
                                    {
                                        string strDesgination = (dr["Designation"] != null && !string.IsNullOrEmpty(dr["Designation"].ToString())) ? dr["Designation"].ToString() : string.Empty;

                                        Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation || Checking whether Employee already exists in the legacy || Started", Entities.LogType.LogMode.Debug);
                                        _dsObject = (DataSet)_empCreation.GetEmpTypeBasedonDesig(strDesgination);
                                        _dsObject.Tables[0].TableName = "getEmpTypeBasedonDesig";
                                        Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation || Checking whether Employee already exists in the legacy || Ended : " + DateTime.Now.TimeOfDay, Entities.LogType.LogMode.Debug);
                                    }
                                    catch (Exception ex)
                                    {
                                        Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation|| Checking whether Employee already exists in the legacy || Error : " + ex.Message, Entities.LogType.LogMode.Error);
                                    }

                                    if (_dsObject.Tables["getEmpTypeBasedonDesig"] != null && _dsObject.Tables["getEmpTypeBasedonDesig"].Rows.Count > 0)
                                    {
                                        strEmpType = _dsObject.Tables["getEmpTypeBasedonDesig"].Rows[0]["sapdesc"].ToString();
                                    }
                                    else
                                    {

                                        if (
                                            (dr["Grade"] != null && !string.IsNullOrEmpty(dr["Grade"].ToString()))
                                            &&
                                            (dr["Grade"].ToString() == "O1" || dr["Grade"].ToString() == "A1" || dr["Grade"].ToString() == "A3" || dr["Grade"].ToString() == "E2" ||
                                            dr["Grade"].ToString() == "O2" || dr["Grade"].ToString() == "A2" || dr["Grade"].ToString() == "E1" || dr["Grade"].ToString() == "E3")
                                            )
                                        {
                                            strEmpType = "FT-OFF";
                                        }
                                        else if (dr["Grade"].ToString().Substring(0, 1).ToUpper() == "T")
                                        {
                                            strEmpType = "TRAINE";
                                        }
                                        else
                                        {
                                            strEmpType = "FT-MGR";
                                        }
                                    }
                                }
                                #endregion ********** Employee Type based on Designation **********

                                #region ********** Employee Marital Status **********
                                if (dr["Marstatus"] != null && dr["Marstatus"].ToString() == "1")
                                {
                                    strMaritalStatus = "M";
                                }
                                else
                                {
                                    strMaritalStatus = "N";
                                }
                                #endregion ********** Employee Marital Status **********

                                #region ********** Date of Birth **********
                                string strTempDbMon = (dr["Dateofbirth"] != null && !string.IsNullOrEmpty(dr["Dateofbirth"].ToString())) ? dr["Dateofbirth"].ToString().Substring(5, 2) : string.Empty;
                                string strTempDbDay = (dr["Dateofbirth"] != null && !string.IsNullOrEmpty(dr["Dateofbirth"].ToString())) ? dr["Dateofbirth"].ToString().Substring(8, 2) : string.Empty;

                                if (strTempDbMon.Length == 1)
                                {
                                    strTempDbMon = "0" + strTempDbMon;
                                }
                                if (strTempDbDay.Length == 1)
                                {
                                    strTempDbDay = "0" + strTempDbDay;
                                }

                                strDob = (dr["Dateofbirth"] != null && !string.IsNullOrEmpty(dr["Dateofbirth"].ToString())) ? dr["Dateofbirth"].ToString().Substring(0, 4) + "-" + strTempDbMon + "-" + strTempDbDay : string.Empty;
                                #endregion ********** Date of Birth **********
                                                                
                                #region ********** Date of Joining **********
                                string strTempDjMon = (dr["Dateofjoining"] != null && !string.IsNullOrEmpty(dr["Dateofjoining"].ToString())) ? dr["Dateofjoining"].ToString().Substring(5, 2) : string.Empty;
                                string strTempDjDay = (dr["Dateofjoining"] != null && !string.IsNullOrEmpty(dr["Dateofjoining"].ToString())) ? dr["Dateofjoining"].ToString().Substring(8, 2) : string.Empty;

                                if (strTempDjMon.Length == 1)
                                {
                                    strTempDjMon = "0" + strTempDjMon;
                                }
                                if (strTempDjDay.Length == 1)
                                {
                                    strTempDjDay = "0" + strTempDjDay;
                                }
                                strDoj = (dr["Dateofjoining"] != null && !string.IsNullOrEmpty(dr["Dateofjoining"].ToString())) ? dr["Dateofjoining"].ToString().Substring(0, 4) + "-" + strTempDjMon + "-" + strTempDjDay : string.Empty;
                                #endregion ********** Date of Joining **********

                                #region ********** Date of Confimation **********
                                if (dr["empsubgroup"] != null && !string.IsNullOrEmpty(dr["empsubgroup"].ToString()) && dr["empsubgroup"].ToString().ToUpper() == "T")
                                {
                                    strDoc = "";
                                }
                                else
                                {
                                    strDoc = strDoj;
                                }
                                #endregion ********** Date of Confimation **********

                                #region ********** Employee Quarters **********
                                if (dr["EmpQuarters"] != null && !string.IsNullOrEmpty(dr["EmpQuarters"].ToString()) && dr["EmpQuarters"].ToString().ToUpper() == "X")
                                {
                                    strQuarters = "1";
                                }
                                else
                                {
                                    strQuarters = "0";
                                }

                                try
                                {
                                    inputCC.Add("PA0021");
                                    inputCC.Add("PERNR EQ " + dr["EmpNo"].ToString());
                                    inputCC.Add("SUBTY|FANAM");

                                    _sapservice = new Service.SAPFactory.SAPServiceManager();
                                    SAPConnect = _sapservice.GetSAPService("datatable");
                                    dtService = (DataTable)SAPConnect.ConnectSAPService(inputCC, "GetTableData");

                                    _sapservice = null;
                                    SAPConnect = null;
                                    inputCC = null;
                                    inputCC = new List<string>();

                                    if (dtService != null && dtService.Rows.Count > 0)
                                    {
                                        foreach (DataRow dr2 in dtService.Rows)
                                        {
                                            if (dr2["Bankmode"] != null && !string.IsNullOrEmpty(dr2["Bankmode"].ToString()) && dr2["Bankmode"].ToString().ToUpper() == "CHEQUE")
                                            {
                                                strBankMode = "CHQ";
                                            }
                                            else if (dr2["Bankmode"] != null && !string.IsNullOrEmpty(dr2["Bankmode"].ToString()) && dr2["Bankmode"].ToString().ToUpper() == "DD")
                                            {
                                                strBankMode = "DD";
                                            }
                                            else
                                            {
                                                strBankMode = "BANK";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //no details found in sap
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation|| Employee Bank Mode from another RFC(from Table) || Error : " + ex.Message, Entities.LogType.LogMode.Error);
                                }

                                //AddressDetails
                                strEmpName  = Tools.IsNull(dr["Empname"])  ? dr["Empname"].ToString().Replace("'", "")  : string.Empty;
                                strAddress1 = Tools.IsNull(dr["Address1"]) ? dr["Address1"].ToString().Replace("'", "") : string.Empty;
                                strAddress2 = Tools.IsNull(dr["Address2"]) ? dr["Address2"].ToString().Replace("'", "") : string.Empty;
                                strAddress3 = Tools.IsNull(dr["Address3"]) ? dr["Address3"].ToString().Replace("'", "") : string.Empty;
                                strPostal   = Tools.IsNull(dr["Postal"])   ? dr["Postal"].ToString().Replace("'", "")   : string.Empty;

                                //Employee Location
                                if ((Tools.IsNull(dr["EmpPerArea"])) && ((dr["EmpPerArea"].ToString() == "3000") && (dr["EmpPayArea"].ToString() == "IG" || dr["EmpPayArea"].ToString() == "IC")))
                                {
                                    strEmpLocation = "102";
                                }
                                else if ((Tools.IsNull(dr["EmpPerArea"])) && ((dr["EmpPerArea"].ToString() == "3000") && (dr["EmpPayArea"].ToString() != "IG" || dr["EmpPayArea"].ToString() != "IC")))
                                {
                                    strEmpLocation = dr["EmpSaploc"].ToString().Replace("'", "");
                                }
                                else if ((Tools.IsNull(dr["EmpPerArea"])) && ((dr["EmpPerArea"].ToString() == "4000") && (dr["EmpPayArea"].ToString() == "IG" || dr["EmpPayArea"].ToString() == "IC")))
                                {
                                    strEmpLocation = "101";
                                }
                                else if ((Tools.IsNull(dr["EmpPerArea"])) && ((dr["EmpPerArea"].ToString() == "4000") && (dr["EmpPayArea"].ToString() != "IG" || dr["EmpPayArea"].ToString() != "IC")))
                                {
                                    strEmpLocation = dr["EmpSaploc"].ToString().Replace("'", "");
                                }
                                else if ((Tools.IsNull(dr["EmpPerArea"])) && (dr["EmpPerArea"].ToString() == "5000" && dr["EmpSaploc"].ToString() == "IGAP"))
                                {
                                    strEmpLocation = "101";
                                }
                                else if ((Tools.IsNull(dr["EmpPerArea"])) && (dr["EmpPerArea"].ToString() == "7000"))
                                {
                                    strEmpLocation = "104";
                                }
                                else if ((Tools.IsNull(dr["EmpPerArea"])) && (dr["EmpPerArea"].ToString() == "5000" && dr["EmpSaploc"].ToString() != "IGAP"))
                                {
                                    strEmpLocation = dr["EmpSaploc"].ToString();
                                }
                                else if ((Tools.IsNull(dr["EmpPerArea"])) && ((dr["EmpPerArea"].ToString() == "1100") && (dr["EmpPayArea"].ToString() == "IO")))
                                {
                                    strEmpLocation = "103";
                                }
                                else if ((Tools.IsNull(dr["EmpPerArea"])) && (dr["EmpPerArea"].ToString().Replace("'", "").Trim().ToUpper() == "1000"))
                                {
                                    //added this if from empupdation.else part(is existing) not added from empupdation
                                    if ((Tools.IsNull(dr["EmpPerArea"])) && (dr["EmpSaploc"].ToString() == "1003" && dr["EmpPayArea"].ToString() == "IL"))
                                    {
                                        strEmpLocation = dr["EmpSaploc"].ToString();
                                    }
                                    else
                                    {
                                        _dsObject = null;
                                        _dsObject = new DataSet();

                                        try
                                        {
                                            string EmpPerArea = Tools.IsNull(dr["EmpPerArea"]) ? dr["EmpPerArea"].ToString() : string.Empty;
                                            string EmpPerSubArea = Tools.IsNull(dr["EmpPerSubArea"]) ? dr["EmpPerSubArea"].ToString() : string.Empty;

                                            Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation || USP_EmpCreation_getSAPPerArea || Started", Entities.LogType.LogMode.Debug);
                                            _dsObject = (DataSet)_empCreation.GetSAPPerArea(EmpPerArea, EmpPerSubArea);
                                            _dsObject.Tables[0].TableName = "getSAPPerArea";
                                            Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation || USP_EmpCreation_getSAPPerArea || Ended : " + DateTime.Now.TimeOfDay, Entities.LogType.LogMode.Debug);
                                        }
                                        catch (Exception ex)
                                        {
                                            Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation|| USP_EmpCreation_getSAPPerArea || Error : " + ex.Message, Entities.LogType.LogMode.Error);
                                        }


                                        if (_dsObject != null && _dsObject.Tables["getSAPPerArea"].Rows.Count > 0)
                                        {
                                            strEmpLocation = _dsObject.Tables["getSAPPerArea"].Rows[0]["Loc_Code"].ToString();
                                        }
                                    }
                                }
                                else
                                {
                                    _dsObject = null;
                                    _dsObject = new DataSet();

                                    try
                                    {
                                        string EmpPerArea = Tools.IsNull(dr["EmpPerArea"]) ? dr["EmpPerArea"].ToString() : string.Empty;
                                        string EmpPerSubArea = Tools.IsNull(dr["EmpPerSubArea"]) ? dr["EmpPerSubArea"].ToString() : string.Empty;

                                        Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation || USP_EmpCreation_getSAPPerArea || Started", Entities.LogType.LogMode.Debug);
                                        _dsObject = (DataSet)_empCreation.GetSAPPerArea(EmpPerArea, EmpPerSubArea);
                                        _dsObject.Tables[0].TableName = "getSAPPerArea";
                                        Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation || USP_EmpCreation_getSAPPerArea || Ended : " + DateTime.Now.TimeOfDay, Entities.LogType.LogMode.Debug);
                                    }
                                    catch (Exception ex)
                                    {
                                        Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation|| USP_EmpCreation_getSAPPerArea || Error : " + ex.Message, Entities.LogType.LogMode.Error);
                                    }

                                    if (_dsObject != null && _dsObject.Tables["getSAPPerArea"].Rows.Count > 0)
                                    {
                                        strEmpLocation = _dsObject.Tables["getSAPPerArea"].Rows[0]["Loc_Code"].ToString();
                                    }
                                }
                                _dsObject = null;
                                _dsObject = new DataSet();

                                strDesig        = Tools.IsNull(dr["Designation"]) ? dr["Designation"].ToString().Replace("'", "") : string.Empty;
                                strDepartment   = Tools.IsNull(dr["Dept"]) ? dr["Dept"].ToString().Replace("'", "").Substring(4, 4) : string.Empty;
                                strGrade        = Tools.IsNull(dr["Grade"]) ? dr["Grade"].ToString().Replace("'", "") : string.Empty;

                                try
                                {
                                    Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation || USP_EmpCreation_getScaleCode || Started", Entities.LogType.LogMode.Debug);
                                    _dsObject = (DataSet)_empCreation.GetScaleCode(strGrade);
                                    _dsObject.Tables[0].TableName = "getSAPPerArea";
                                    Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation || USP_EmpCreation_getScaleCode || Ended : " + DateTime.Now.TimeOfDay, Entities.LogType.LogMode.Debug);
                                }
                                catch (Exception ex)
                                {
                                    Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation|| USP_EmpCreation_getScaleCode || Error : " + ex.Message, Entities.LogType.LogMode.Error);
                                }

                                if (_dsObject.Tables["getScaleCode"].Rows.Count > 0)
                                {
                                    strScale = _dsObject.Tables["getScaleCode"].Rows[0]["Scl_Code"].ToString();
                                }

                                try
                                {
                                    EmpMasterTrans EMTrans = new EmpMasterTrans();
                                    EMTrans.Flag = "I";
                                    EMTrans.EmpId = strEmpNo;
                                    EMTrans.Title = strTitle;


                                    Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation || USP_EMPLOYEEMASTER_TRANSACTIONS || Started", Entities.LogType.LogMode.Debug);
                                    _dsObject = (DataSet)_empCreation.EmployeeMasterTransactions(strGrade);
                                    _dsObject.Tables[0].TableName = "getSAPPerArea";
                                    Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation || USP_EMPLOYEEMASTER_TRANSACTIONS || Ended : " + DateTime.Now.TimeOfDay, Entities.LogType.LogMode.Debug);
                                }
                                catch (Exception ex)
                                {
                                    Log4net.LogWriter("ScheduleService", "EmpCreation", "SAPEmpCreation|| USP_EMPLOYEEMASTER_TRANSACTIONS || Error : " + ex.Message, Entities.LogType.LogMode.Error);
                                }
                                #endregion

                                #region ********** **********

                                #endregion

                                #region ********** **********

                                #endregion
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
