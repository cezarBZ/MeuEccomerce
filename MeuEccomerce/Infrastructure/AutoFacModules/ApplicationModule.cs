using Autofac;
using MeuEccomerce.API.Validators;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using MeuEccomerce.Domain.AggregatesModel.OrderAggregate;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;
using MeuEccomerce.Domain.AggregatesModel.ShoppingCartAggregate;
using MeuEccomerce.Domain.Core.Data;
using MeuEccomerce.Infrastructure.Repositories;

namespace MeuEccomerce.API.Infrastructure.AutoFacModules
{
    public class ApplicationModule : Module
    {
        public IConfiguration _configuration { get; }

        public ApplicationModule(IConfiguration configuration)
        { 
            
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
               .As<IUnitOfWork>()
               .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<,>))
               .As(typeof(IRepository<,>))
               .InstancePerLifetimeScope();

            builder.RegisterType<CategoryRepository>()
                .As<ICategoryRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ShoppingCartItemsRepository>()
                .As<IShoppingCartItemRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<OrderRepository>()
               .As<IOrderRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<ShoppingCartItemsRepository>()
               .As<IShoppingCartItemRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<HttpContextAccessor>()
                .As<IHttpContextAccessor>()
                .SingleInstance();

            builder.RegisterType<ProductValidator>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CategoryValidator>()
                .InstancePerLifetimeScope();
        }    
    }
}
