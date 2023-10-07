using Autofac;
using UA.Application.Services;
using UA.Application.Services.Interfaces;

namespace UA.Application;

public sealed class ApplicationRegistrationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UserAppService>().As<IUserAppService>();
    }
}