using Gijima.Hulamin.Core.Validation.Abstracts;

namespace Gijima.Hulamin.Data.Persistence
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IRepository CreateRepositoy(ISetUpSpecificationHandler setUpSpecificationHandler, string connectionString)
        {
            return new StandardRepository(setUpSpecificationHandler, connectionString);
        }
    }
}
