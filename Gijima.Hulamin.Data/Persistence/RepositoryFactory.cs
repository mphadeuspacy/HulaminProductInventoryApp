using Gijima.Hulamin.Core.Validation.Abstracts;

namespace Gijima.Hulamin.Data.Persistence
{
    public class RepositoryFactory<TEntity> : IRepositoryFactory<TEntity>
    {
        public IRepository<TEntity> CreateRepositoy(ISetUpSpecificationHandler setUpSpecificationHandler, string connectionString)
        {
            return new StandardRepository<TEntity>(setUpSpecificationHandler, connectionString);
        }
    }
}
