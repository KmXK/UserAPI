using Autofac;
using UA.Data.Core;
using UA.Data.Core.Interfaces;

namespace UA.Data;

public sealed class DataRegistrationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
    }
}