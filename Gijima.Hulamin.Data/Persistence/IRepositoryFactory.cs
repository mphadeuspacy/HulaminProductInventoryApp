namespace Gijima.Hulamin.Data.Persistence
{
    public interface IRepositoryFactory
    {
        IRepository CreateRepositoy(string connectionString);
    }
}
