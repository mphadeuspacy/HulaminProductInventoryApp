using Gijima.Hulamin.Core.Validation.Abstracts;

namespace Gijima.Hulamin.Core.Persistence
{
    public interface IRepositoryFactory<TEntity>
    {
        IRepository CreateRepository(ISetUpSpecificationHandler setUpSpecificationHandler, string connectionString);
    }
}
