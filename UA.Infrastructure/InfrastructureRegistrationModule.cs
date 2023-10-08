using Autofac;
using UA.Infrastructure.Services;
using UA.Infrastructure.Services.Interfaces;

namespace UA.Infrastructure;

public sealed class InfrastructureRegistrationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CryptoService>().As<ICryptoService>();
    }
}