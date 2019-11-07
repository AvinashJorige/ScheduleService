using Repository;
using Repository.Repositories;

namespace Core
{
    public class EMPCreationCore
    {
        private IConnectionFactory _iconn = null;
        private DbContext context = null;

        public EMPCreationCore()
        {
            _iconn = ConnectionHelper.GetConnection();
            context = new DbContext(_iconn);
        }

        public void UpdateToDb(string strXmlValue, string methodName)
        {
            switch (methodName)
            {
                case "CCUpdate":
                    new EmployeeCreation(context).UpdateCCUpd_T(strXmlValue);
                    break;
                case "UpdateCostCenterSchedules":
                    new EmployeeCreation(context).UpdateCostCenterSchedules(strXmlValue);
                    break;
                case "PlntUpd_T":
                    new EmployeeCreation(context).PlntUpd_T(strXmlValue);
                    break;
            }
        }
        
        public void Indent_InsertNewItem(string strXMLVal1, string strXMLVal2)
        {
            new EmployeeCreation(context).Indent_InsertNewItem(strXMLVal1, strXMLVal2);
        }

        /// <summary>
        /// Select, Update, insert queries with SP no parameters
        /// </summary>
        /// <param name="SPName">Store Procedure Name</param>
        /// <returns>Object either Datatable or DataSet.</returns>
        public object GetOrSetChangesToDB(string SPMethod)
        { 
            string strName = string.Empty;
            if (!string.IsNullOrEmpty(SPMethod))
            {
                switch (SPMethod)
                {
                    case "getMaxEmpId" :
                        strName = "USP_EmpCreation_getMaxEmpId";
                        break;
                }
            }

            return new EmployeeCreation(context).GetOrSetChangesToDB(strName);
        }

        public object EmpCreation_chkEmpExists(string strEmpId)
        {
            return new EmployeeCreation(context).EmpCreation_chkEmpExists(strEmpId);
        }
    }
}
