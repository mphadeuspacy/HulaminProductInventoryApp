using Gijima.Hulamin.Core.DomainServices;
using Gijima.Hulamin.Core.Entities;
using Gijima.Hulamin.Core.Persistence;
using Gijima.Hulamin.Core.Validation.Abstracts;
using Gijima.Hulamin.Core.Validation.Concretes;
using Ninject.Activation;
using Ninject.Modules;

namespace Gijima.Hulamin.UnitTests
{
    public class UnitTestModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISetUpSpecificationHandler>().To<StandardSetUpSpecificationHandler>();
            Bind<IRepositoryFactory<Supplier>>().To<RepositoryFactory<Supplier>>();
            Bind<IRepository>().ToProvider(new UnitTestRepositoryProvider());
            Bind<SpecificationHandler>().To<SupplierSpecificationHandler>();
            

            Bind<ISupplierService>().To<SupplierService>();
        }
    }

    public class UnitTestRepositoryProvider : Provider<IRepository>
    {
        protected override IRepository CreateInstance(IContext context)
        {
            return new StandardRepository<Supplier>( new StandardSetUpSpecificationHandler(), @"Data Source =.\; Initial Catalog = Northwind; Persist Security Info=True;User ID = sa; Password=Khsph01@gmailcom");
        }
    }
   
}
