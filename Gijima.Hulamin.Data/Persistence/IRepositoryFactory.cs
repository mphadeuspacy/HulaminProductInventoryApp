using Gijima.Hulamin.Core.Validation.Abstracts;

namespace Gijima.Hulamin.Data.Persistence
{
    public interface IRepositoryFactory
    {
        IRepository CreateRepositoy(ISetUpSpecificationHandler setUpSpecificationHandler, string connectionString);
    }
}
