namespace Service.ConnectionFactory
{
    using System.Data.SqlClient;

    public abstract class ConnectionsFactory
    {
        /// <summary>
        /// Create object instance based on connection type
        /// </summary>
        /// <param name="ConnectionType">Type of Sql connection that need to establish</param>
        /// <returns></returns>
        public abstract IFactory GetConnection(string ConnectionType);
    }
}
