using System.Data.SqlClient;

namespace Service.ConnectionFactory
{
    public interface IFactory
    {
        SqlConnection Connection(string ConnectionType);
    }
}
