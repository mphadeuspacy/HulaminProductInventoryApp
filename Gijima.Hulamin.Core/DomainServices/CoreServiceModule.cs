using Gijima.Hulamin.Core.Entities;
using Gijima.Hulamin.Core.Persistence;
using Gijima.Hulamin.Core.Validation.Abstracts;
using Gijima.Hulamin.Core.Validation.Concretes;
using Ninject.Modules;

namespace Gijima.Hulamin.Core.DomainServices
{
    public class CoreServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepositoryFactory<Supplier>>().To<RepositoryFactory<Supplier>>();
            Bind<SpecificationHandler>().To<SupplierSpecificationHandler>();
            Bind<ISetUpSpecificationHandler>().To<StandardSetUpSpecificationHandler>();
            Bind<ISupplierService>().To<SupplierService>();
        }
    }
}
