namespace Gijima.Hulamin.Data.Persistence
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IRepository CreateRepositoy(string connectionString)
        {
            return new StandardRepository(connectionString);
        }
    }
}
