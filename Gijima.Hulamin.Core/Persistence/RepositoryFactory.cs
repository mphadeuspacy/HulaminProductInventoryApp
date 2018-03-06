using Gijima.Hulamin.Core.Validation.Abstracts;

namespace Gijima.Hulamin.Core.Persistence
{
    public class RepositoryFactory<TEntity> : IRepositoryFactory<TEntity>
    {
        public IRepository CreateRepository(ISetUpSpecificationHandler setUpSpecificationHandler, string connectionString)
        {
            return new StandardRepository<TEntity>(setUpSpecificationHandler, connectionString);
        }
    }
}
