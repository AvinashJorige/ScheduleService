namespace Service.ConnectionFactory
{
    using System.Data.SqlClient;
    using Utility;

    public class ACConnection : IFactory
    {
        public SqlConnection Connection(string ConnectionType)
        {
            return new SqlConnection(Tools.ConfigSetting<string>(ConnectionType));
        }
    }
}
