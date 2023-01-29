using Autofac;
using MediatR;
using MeuEccomerce.API.Application.CommandHandlers.Categories;
using MeuEccomerce.API.Application.Commands.Category;
using System.Reflection;

namespace MeuEccomerce.API.Infrastructure.AutoFacModules;

public class MediatorModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(typeof(CreateCategoryCommandHandler).GetTypeInfo().Assembly)
           .AsClosedTypesOf(typeof(IRequestHandler<,>));
        builder.RegisterAssemblyTypes(typeof(CreateCategoryCommand).GetTypeInfo().Assembly)
              .AsClosedTypesOf(typeof(IRequestHandler<,>));


    }
}
