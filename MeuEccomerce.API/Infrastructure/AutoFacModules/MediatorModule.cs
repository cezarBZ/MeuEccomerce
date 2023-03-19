using Autofac;
using MediatR;
using System.Reflection;

namespace MeuEccomerce.API.Infrastructure.AutoFacModules;

public class MediatorModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
            .AsImplementedInterfaces();
    }
}
