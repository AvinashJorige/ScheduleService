namespace Service.ConnectionFactory
{
    using System.Data.SqlClient;
    using Utility;

    public class ASConnection : IFactory
    {
        public SqlConnection Connection(string ConnectionType)
        {
            return new SqlConnection(Tools.ConfigSetting<string>(ConnectionType));
        }
    }
}
