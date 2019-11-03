namespace Service.ConnectionFactory
{
    using System.Data.SqlClient;
    using Utility;

    public class HomeConnection : IFactory
    {
        public SqlConnection Connection(string ConnectionType)
        {
            return new SqlConnection(Tools.ConfigSetting<string>(ConnectionType));
        }
    }
}
