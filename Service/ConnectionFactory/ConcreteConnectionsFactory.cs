using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ConnectionFactory
{
    public class ConcreteConnectionsFactory : ConnectionsFactory
    {
        public override IFactory GetConnection(string ConnectionType)
        {
            switch (ConnectionType)
            {
                case "IILHome":
                    return  new HomeConnection();
                case "EComm":
                    return new ECommConnection();
                case "AS":
                    return new ASConnection();
                case "AC":
                    return new ACConnection();
                default:
                    throw new ApplicationException(string.Format("SQL Connection '{0}' cannot be created", ConnectionType));
            }
        }
    }
}
