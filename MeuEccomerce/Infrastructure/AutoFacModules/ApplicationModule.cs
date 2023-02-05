using Autofac;
using MeuEccomerce.Domain.Core.Data;
using MeuEccomerce.Infrastructure.Repositories;

namespace MeuEccomerce.API.Infrastructure.AutoFacModules
{
    public class ApplicationModule : Module
    {
        public string ConnectionString { get; }

        public ApplicationModule(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
               .As<IUnitOfWork>()
               .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<,>))
               .As(typeof(IRepository<,>))
               .InstancePerLifetimeScope();
            
            //builder.RegisterType<CategoryRepository>()
            //    .As<ICategoryRepository>()
            //    .InstancePerDependency();

            //builder.RegisterType<ProductRepository>()
            //    .As<IProductRepository>()
            //    .InstancePerDependency();
        }    
    }
}
