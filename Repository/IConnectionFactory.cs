namespace Repository
{
    using System.Data;

    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}
