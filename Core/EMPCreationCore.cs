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
    }
}
