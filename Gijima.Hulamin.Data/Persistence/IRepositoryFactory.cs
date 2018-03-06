using Gijima.Hulamin.Core.Validation.Abstracts;

namespace Gijima.Hulamin.Data.Persistence
{
    public interface IRepositoryFactory<TEntity>
    {
        IRepository<TEntity> CreateRepository(ISetUpSpecificationHandler setUpSpecificationHandler, string connectionString);
    }
}
