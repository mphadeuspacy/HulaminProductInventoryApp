using System.Configuration;
using Autofac;
using Gijima.Hulamin.Core.Entities;
using Gijima.Hulamin.Core.Validation.Abstracts;
using Gijima.Hulamin.Core.Validation.Concretes;
using Gijima.Hulamin.Data.Persistence;

namespace Gijima.Hulamin.WebApi.App_Start
{
    public static class DependencyInjectorConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            RegisterCommonBindings(builder);
        }

        private static void RegisterCommonBindings(ContainerBuilder builder)
        {
            Initialize();

            builder.RegisterType<StandardSetUpSpecificationHandler>().As<ISetUpSpecificationHandler>();

            builder.Register(x => new StandardRepository<Category>(x.Resolve<ISetUpSpecificationHandler>(), ConnectionString));

            builder.RegisterType<RepositoryFactory<Category>>().As<IRepositoryFactory<Category>>();
        }

        private static void Initialize()
        {
            InitializeBaseConfiguration();
        }

        private static void InitializeBaseConfiguration()
        {
            ConnectionString = GetAppSetting(nameof(ConnectionString));
        }

        private static string ConnectionString { get; set; }

        private static string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
