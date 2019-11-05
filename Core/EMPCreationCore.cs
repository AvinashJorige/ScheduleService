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

        public void CCUpdate(string strXMLVal)
        {
            new EmployeeCreation(context).UpdateCCUpd_T(strXMLVal);
        }

        public void UpdateCostCenterSchedules(string strXMLVal)
        {
            new EmployeeCreation(context).UpdateCCUpd_T(strXMLVal);
        }

        public void Indent_InsertNewItem(string strXMLVal1, string strXMLVal2)
        {
            new EmployeeCreation(context).Indent_InsertNewItem(strXMLVal1, strXMLVal2);
        }
    }
}
