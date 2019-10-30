namespace Repository
{
    public interface IUnitOfWork
    {
        void Dispose();

        void SaveChanges();
    }
}
