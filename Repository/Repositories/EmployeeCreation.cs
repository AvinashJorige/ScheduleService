using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Utility;

namespace Repository.Repositories
{
    public class EmployeeCreation : Repository<Request>
    {
        private DbContext _context;
        public EmployeeCreation(DbContext context)
            : base(context)
        {
            _context = context;
        }

        #region Methods : DataTable 
        public DataTable UpdateCCUpd_T(string CCXML)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "exec [dbo].[USP_CCUpd_T]";
                command.Parameters.Add(new SqlParameter("@CCTable", SqlDbType.Xml));
                command.Parameters["@CCTable"] = CCXML.ToString();
                return Tools.ConvertListToDataTable(this.ToList(command).ToList());
            }
        }

        public DataTable UpdateCostCenterSchedules(string CCXML)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "exec [dbo].[Usp_UpdateCostCenters_schedules]";
                command.Parameters.Add(new SqlParameter("@XmlSchedules", SqlDbType.Xml));
                command.Parameters["@XmlSchedules"] = CCXML.ToString();
                return Tools.ConvertListToDataTable(this.ToList(command).ToList());
            }
        }

        public DataTable Indent_InsertNewItem(string strXMLVal1, string strXMLVal2)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "exec [dbo].[USP_Indent_InsertNewItem]";
                command.Parameters.Add(new SqlParameter("@XmlSchedules", SqlDbType.Xml));
                command.Parameters["@IndNewItemdetails"] = strXMLVal1.ToString();
                command.Parameters.Add(new SqlParameter("@XmlSchedules", SqlDbType.Xml));
                command.Parameters["@IndNewItemdetails1"] = strXMLVal2.ToString();
                return Tools.ConvertListToDataTable(this.ToList(command).ToList());
            }
        }

        public DataTable PlntUpd_T(string CCXML)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "exec [dbo].[USP_PlntUpd_T]";
                command.Parameters.Add(new SqlParameter("@CCTable", SqlDbType.Xml));
                command.Parameters["@CCTable"] = CCXML.ToString();
                return Tools.ConvertListToDataTable(this.ToList(command).ToList());
            }
        }

        public DataTable EmpCreation_chkEmpExists(string strEmpNo)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "exec [dbo].[USP_EmpCreation_chkEmpExists]";
                command.Parameters.Add(new SqlParameter("@EmpId", SqlDbType.VarChar));
                command.Parameters["@EmpId"] = strEmpNo.ToString();
                return Tools.ConvertListToDataTable(this.ToList(command).ToList());
            }
        }

        public DataTable GetEmpTypeBasedonDesig(string Designation)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "exec [dbo].[USP_EmpCreation_getEmpTypeBasedonDesig]";
                command.Parameters.Add(new SqlParameter("@SAPDesig", SqlDbType.VarChar));
                command.Parameters["@SAPDesig"] = Designation;
                return Tools.ConvertListToDataTable(this.ToList(command).ToList());
            }
        }

        public DataTable GetSAPPerArea(string EmpPerArea, string EmpPerSubArea)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "exec [dbo].[USP_EmpCreation_getSAPPerArea]";
                command.Parameters.Add(new SqlParameter("@SapPerArea", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@SapSubArea", SqlDbType.VarChar));
                command.Parameters["@SapPerArea"] = EmpPerArea;
                command.Parameters["@SapSubArea"] = EmpPerSubArea;
                return Tools.ConvertListToDataTable(this.ToList(command).ToList());
            }
        }

        public DataTable GetScaleCode(string GradeCode)
        {
            DataTable dtTable = new DataTable();
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "exec [dbo].[USP_EmpCreation_getScaleCode]";
                command.Parameters.Add(new SqlParameter("@GradeCode", SqlDbType.VarChar));
                command.Parameters["@GradeCode"] = GradeCode;

                dtTable = Tools.ConvertListToDataTable(this.ToList(command).ToList());
                dtTable.TableName = "getScaleCode";

                return dtTable;
            }
        }
        #endregion

        #region Methods : DataSet
        public DataSet GetOrSetChangesToDB(string SPName)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "exec [dbo].[" + SPName + "]";
                return Tools.ConvertListToDataSet(this.ToList(command).ToList());
            }
        }
        #endregion

        #region Methods : Void        
        public void EmployeeMasterTransactions(EmpMasterTrans EMTrans)
        {
            DataTable dtTable = new DataTable();
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "exec [dbo].[USP_EMPLOYEEMASTER_TRANSACTIONS]";

                #region Parameters
                command.Parameters.Add(new SqlParameter("@flag", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@EmpId", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@Title", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@FatherName", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@BirthDate", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@JoinDate", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@ConfirmedDate", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@add1", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@add2", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@add3", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@PIN", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@Married", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@Gender", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@Emptype", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@DeptId", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@DesigId", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@GradeId", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@locationcode", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@scl_code", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@status", SqlDbType.Int));
                #endregion

                #region Values
                command.Parameters["@flag"] = EMTrans.Flag;
                command.Parameters["@EmpId"] = EMTrans.EmpId;
                command.Parameters["@Title"] = EMTrans.Title;
                command.Parameters["@FirstName"] = EMTrans.FirstName;
                command.Parameters["@FatherName"] = EMTrans.FatherName;
                command.Parameters["@BirthDate"] = EMTrans.BirthDate;
                command.Parameters["@JoinDate"] = EMTrans.JoinDate;
                command.Parameters["@ConfirmedDate"] = EMTrans.ConfirmedDate;
                command.Parameters["@add1"] = EMTrans.Add1;
                command.Parameters["@add2"] = EMTrans.Add2;
                command.Parameters["@add3"] = EMTrans.Add3;
                command.Parameters["@PIN"] = EMTrans.PIN;
                command.Parameters["@Married"] = EMTrans.Married;
                command.Parameters["@Gender"] = EMTrans.Gender;
                command.Parameters["@Emptype"] = EMTrans.Emptype;
                command.Parameters["@DeptId"] = EMTrans.DeptId;
                command.Parameters["@DesigId"] = EMTrans.DesigId;
                command.Parameters["@GradeId"] = EMTrans.GradeId;
                command.Parameters["@locationcode"] = EMTrans.Locationcode;
                command.Parameters["@scl_code"] = EMTrans.Scl_code;
                command.Parameters["@status"] = EMTrans.Status; 
                #endregion

                this.ToList(command).ToList();
            }
        }
        #endregion
    }
}
