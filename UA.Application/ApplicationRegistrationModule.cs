using Autofac;
using UA.Application.Interfaces;
using UA.Application.Services;

namespace UA.Application;

public sealed class ApplicationRegistrationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UserAppService>().As<IUserAppService>();
    }
}